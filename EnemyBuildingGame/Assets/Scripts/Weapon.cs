using UnityEngine;
using System.Collections;

public class Weapon : Part {
	public float fireInterval = 1;
	public float burstFireInterval = 0.25f;
	public float burstSize = 0;

	public int beatOffset = 0;
	/*public int secondShotOffset = 2;
	public int beatCount = 8;*/
	public ParticleSystem fireParticles;
	private AudioSource audioSource;
	public float recoil = 0;
	Rigidbody attachedRigidbody;

	public float lastFiredTime;
	public int burstCount = 0;

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
	
	protected virtual void OnBeat(int count, int totalBeats, double time)
	{
		if (EBG.CurrentState != EBG.GameState.Playing) return;

		if (beatOffset > 0 && count % 2 == 0) return;
		else if (beatOffset <= 0 && count % 2 == 1) return;

		if (burstCount < burstSize)
		{
			if (Time.time > lastFiredTime + burstFireInterval)
			{
				lastFiredTime = Time.time;
				burstCount ++;
				Fire (time);
			}
		}
		else if (Time.time > lastFiredTime + fireInterval)
		{
			burstCount = 1;
			lastFiredTime = Time.time;
			Fire (time);
		}

		/*
		if (EBG.CurrentState != EBG.GameState.Playing) return;
		if ((totalBeats + beatOffset) % beatCount == 0) 
		{	

			Fire (time);
		}
		else if ((totalBeats + beatOffset) % beatCount == secondShotOffset)  Fire (time);

*/
		//if ((count + beatCount) % MusicEventManager.Instance.countTo == beatOffset) Fire(time);
		//else if ((count + beatCount + secondShotOffset) % MusicEventManager.Instance.countTo == beatOffset) Fire(time);
	}

	public virtual void Fire(double time)
	{
		if (audioSource != null)
		{
			audioSource.PlayScheduled(time);
		}

		if (fireParticles != null)
		{
			fireParticles.Play();
		}

		if (!Mathf.Approximately(recoil, 0))
		{
			if (attachedRigidbody == null)
			{
				Transform tr = transform.parent;
				while (tr != null && attachedRigidbody == null)
				{
					attachedRigidbody = tr.rigidbody;
					tr = tr.parent;
				}
			}
			else
			{
				attachedRigidbody.AddRelativeForce(-Vector3.forward * recoil);
			}
		}
	}
}
