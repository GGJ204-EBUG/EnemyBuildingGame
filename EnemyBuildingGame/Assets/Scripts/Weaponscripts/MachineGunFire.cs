using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MachineGunFire : Part
{
	public float ammoDamage;
	public float ammoSpeed;

	public Bullet ammoPrefab;
	public Transform ammoSpawnPos;
	public float coolDown = 0.25f;
	private float lastFired;

	public int beatOffset = 0;
	public int secondShotOffset = 2;
	public int beatCount = 8;
	public AudioClip fireSound;

	private AudioSource audioSource;

	void Awake()
	{
		audioSource = audio;
		if (transform.position.x < 0) 
		{
			beatOffset = 2;
			audioSource.pitch = 1.2f;
		}
	}

	void OnEnable()
	{
		MusicEventManager.OnBeat += OnBeat;
	}

	void OnDisable()
	{
		MusicEventManager.OnBeat -= OnBeat;
	}

	void OnBeat(int count, double time)
	{
		if ((count + beatOffset) % MusicEventManager.Instance.countTo == beatCount) Fire(time);
		else if ((count + beatOffset + secondShotOffset) % MusicEventManager.Instance.countTo == beatCount) Fire(time);
	}

	public void Fire(double time)
	{
		if (fireSound != null)
		{
			if (audioSource == null)
			{
				audioSource = gameObject.AddComponent<AudioSource>();
			}
			audioSource.clip = fireSound;
			//Debug.Log(time);
			audioSource.PlayScheduled(time);
		}

		if (ammoPrefab != null)
		{
			GameObject go = Instantiate(ammoPrefab.gameObject, ammoSpawnPos.position, ammoSpawnPos.rotation) as GameObject;
			Bullet bullet = go.GetComponent<Bullet>();
			bullet.speed = ammoSpeed;
			bullet.damage = ammoDamage;
			lastFired = Time.time;	
		}


	}
}
