using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlasmaBallFire : Weapon
{
	public float ammoDamage;
	public float ammoSpeed;
	public float ammoLifeTime = 3;

	public Plasma ammoPrefab;
	public Transform ammoSpawnPos;
	
	public override void Fire(double time)
	{
		base.Fire(time);

		GameObject go = Instantiate(ammoPrefab.gameObject, ammoSpawnPos.position, ammoSpawnPos.rotation) as GameObject;

		Plasma bullet = go.GetComponent<Plasma>();
		bullet.speed = ammoSpeed;
		bullet.damage = ammoDamage;
		bullet.lifetime = ammoLifeTime;

	}
}
