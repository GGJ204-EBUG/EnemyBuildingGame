using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour 
{
	private static AudioManager instance;
	public static AudioManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = EBG.Instance.gameObject.GetComponent<AudioManager>();
			}
			return instance;
		}
	}

	public int maxAudioClips = 10;

	private AudioSource music;

	private List<AudioSource> audioSources;

	private Queue<QueuedSound> queue;

	private AudioClip nextMusic;
	private bool nextMusicLoop;

	void Awake()
	{
		audioSources = new List<AudioSource>();
		queue = new Queue<QueuedSound>();

		GameObject go = new GameObject("Music");
		go.transform.parent = transform;
		music = go.AddComponent<AudioSource>();

		for (int i = 0; i < maxAudioClips; i++)
		{
			GameObject source = new GameObject("Audio Source " + i);
			source.transform.parent = transform;
			audioSources.Add(source.AddComponent<AudioSource>());
		}
	}

	public void PlayMusic(AudioClip clip, bool loop)
	{
		if (music.isPlaying)
		{
			nextMusic = clip;
			nextMusicLoop = loop;
		}
		else
		{
			music.clip = clip;
			music.loop = loop;
			music.Play();
		}
	}

	void Update()
	{
		while (queue.Count > 0 && NextFree() != null)
		{
			AudioSource source = NextFree();

			QueuedSound qs = queue.Dequeue();

			if (Time.time - qs.queueTime > 0.5f)
			{
				continue;
			}

			source.clip = qs.clip;
			source.volume = qs.volume;
			source.pitch = qs.pitch;
			source.Play();
		}

		if (nextMusic != null)
		{
			if (!music.isPlaying || music.volume <= 0)
			{
				music.clip = nextMusic;
				nextMusic = null;
				music.volume = 0.01f;
				music.loop = nextMusicLoop;
				music.Play();
			}
			else
			{
				music.volume -= Time.deltaTime;
			}
		}
		else if (music.volume < 1)
		{
			music.volume += Time.deltaTime * 4;
		}
	}

	AudioSource NextFree()
	{
		for (int i = 0; i < audioSources.Count; i++)
		{
			if (!audioSources[i].isPlaying)
			{
				return audioSources[i];
			}
		}

		return null;
	}

	public void PlayOneOffSound(AudioClip clip, float volume, float pitch)
	{
		AudioSource source = NextFree();

		if (source != null)
		{
			source.clip = clip;
			source.volume = volume;
			source.pitch = pitch;
			source.Play();
		}
		else
		{
			// No source available, queue
			QueuedSound qs = new QueuedSound();
			qs.clip = clip;
			qs.queueTime = Time.time;
			qs.volume = volume;
			qs.pitch = pitch;
			queue.Enqueue(qs);
		}
	}

	private class QueuedSound
	{
		public AudioClip clip;
		public float volume;
		public float pitch;
		public float queueTime;
	}

}