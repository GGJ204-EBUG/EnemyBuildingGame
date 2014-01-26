using UnityEngine;
using System.Collections;

public class Weapon : Part {
	public int beatOffset = 0;
	public int secondShotOffset = 2;
	public int beatCount = 8;
	
	private AudioSource audioSource;

	protected virtual void Awake()
	{
		audioSource = audio;
		
		if (audioSource != null && transform.position.x < 0) 
		{
			beatOffset = 2;
			audioSource.pitch = 1.2f;
		}
	}

	protected virtual void OnEnable()
	{
		MusicEventManager.OnBeat += OnBeat;
	}
	
	protected virtual void OnDisable()
	{
		MusicEventManager.OnBeat -= OnBeat;
	}
	
	protected virtual void OnBeat(int count, double time)
	{
		if ((count + beatCount) % MusicEventManager.Instance.countTo == beatOffset) Fire(time);
		else if ((count + beatCount + secondShotOffset) % MusicEventManager.Instance.countTo == beatOffset) Fire(time);
	}

	public virtual void Fire(double time)
	{
		if (audioSource != null)
		{
			audioSource.PlayScheduled(time);
		}
	}
}
