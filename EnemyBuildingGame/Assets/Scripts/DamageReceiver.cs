using UnityEngine;
using System.Collections;

public class DamageReceiver : MonoBehaviour
{
	public float health;
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
		Destroy(gameObject);
	}
}
