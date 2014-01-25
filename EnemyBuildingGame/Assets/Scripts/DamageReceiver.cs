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
		damage += amount;
		if (damage >= health)
		{
			Die();
		}
	}

	public void Die()
	{
		if (deathEffect != null)
		{
			GameObject go = Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject;
			Destroy(go, 10);
		}
		Destroy(gameObject);
	}
}
