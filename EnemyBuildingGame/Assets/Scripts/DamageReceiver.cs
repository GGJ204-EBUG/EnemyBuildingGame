using UnityEngine;
using System.Collections;

public class DamageReceiver : MonoBehaviour
{
	public float health;
	public GameObject deathEffect;

	private float damage;

	public void TakeDamage(Damage newDamage)
	{
		TakeDamage(newDamage.amount);
	}

	public void TakeDamage(float amount)
	{
		if (EBG.CurrentState != EBG.GameState.Playing) return;
		damage += amount;
		if (damage >= health)
		{
			GameCamera.Shake(1);
			Die();
		}
		else
		{
			GameCamera.Shake(amount / health);
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
