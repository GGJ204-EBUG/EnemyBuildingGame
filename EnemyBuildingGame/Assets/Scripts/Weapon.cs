using UnityEngine;
using System.Collections;

public class Weapon : Part {
	public int beatOffset = 0;
	public int secondShotOffset = 2;
	public int beatCount = 8;
	public ParticleSystem fireParticles;
	private AudioSource audioSource;
	public float recoil = 0;
	Rigidbody attachedRigidbody;

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
		if (EBG.CurrentState != EBG.GameState.Playing) return;
		if ((count + beatOffset) % beatCount == 0) Fire (time);
		else if ((count + beatOffset + secondShotOffset) % beatCount == 0) Fire (time);
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
