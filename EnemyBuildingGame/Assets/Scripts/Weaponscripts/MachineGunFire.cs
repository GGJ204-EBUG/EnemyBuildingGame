using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MachineGunFire : Weapon
{
	public float ammoDamage;
	public float ammoSpeed;

	public Bullet ammoPrefab;
	public Transform ammoSpawnPos;
	
	public override void Fire(double time)
	{
		base.Fire (time);

		if (ammoPrefab != null)
		{
			GameObject go = Instantiate(ammoPrefab.gameObject, ammoSpawnPos.position, ammoSpawnPos.rotation) as GameObject;
			Bullet bullet = go.GetComponent<Bullet>();
			bullet.speed = ammoSpeed;
			bullet.damage = ammoDamage;
		}
	}
}
