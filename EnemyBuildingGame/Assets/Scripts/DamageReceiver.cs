﻿using UnityEngine;
using System.Collections;

public class DamageReceiver : MonoBehaviour
{
	public float health;
	public GameObject deathEffect;
	public float shakeAmount = 0.1f;

	public float Damage { get; private set; }

	public void TakeDamage(Damage newDamage)
	{
		Debug.Log(gameObject.name + " got " + newDamage.amount + " damage from " + newDamage.source.gameObject.name);

		TakeDamage(newDamage.amount);
	}

	private void TakeDamage(float amount)
	{
		if (EBG.CurrentState != EBG.GameState.Playing) return;

		Damage += amount;

		if (Damage >= health)
		{
			GameCamera.Shake(shakeAmount);
			Die();
		}
		else
		{
			GameCamera.Shake(shakeAmount * amount / health);
		}
	}

	public void Die()
	{
		if (deathEffect != null)
		{
			GameObject go = Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject;
			if (go.audio != null) go.audio.PlayScheduled(MusicEventManager.Instance.GetNext());
			Destroy(go, 10);
		}
		Destroy(gameObject);
	}
}
