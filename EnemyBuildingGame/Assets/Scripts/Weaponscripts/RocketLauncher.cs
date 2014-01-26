using UnityEngine;
using System.Collections;

public class RocketLauncher : Weapon
{
	public GameObject ammoPrefab;
	public Transform ammoSpawnPos;
	
	public override void Fire(double time)
	{
		base.Fire (time);
		
		if (ammoPrefab != null)
		{
			Instantiate(ammoPrefab.gameObject, ammoSpawnPos.position, ammoSpawnPos.rotation);
		}
	}
}
