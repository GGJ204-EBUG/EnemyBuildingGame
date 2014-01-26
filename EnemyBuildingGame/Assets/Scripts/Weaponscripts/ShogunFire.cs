using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShogunFire : Part
{
	// Shogun is like a shotgun, but with more oof. And lasers. Random but plentiful spread.

	public float ammoDamage = 200;
	public float ammoSpeed;
	
	public float ammoActiveTime = 0.1f;

	public int amountOfLazers = 10;
		
	//LineRenderer line;

	public Lazer ammoPrefab;
	public Transform ammoSpawnPos;
	public float coolDown = 1.0f;
	private float lastFired;

	// Update is called once per frame
	void Update () {
		Fire ();
	}
	
	public void Fire()
	{
		if (Time.time > lastFired + coolDown)
		{
			for (int n=1; n<=amountOfLazers; n++) 
			{
				Debug.Log("Firing!");				
				GameObject go = Instantiate(ammoPrefab.gameObject) as GameObject;
				Lazer bullet = go.GetComponent<Lazer>();
				bullet.origin = ammoSpawnPos.position;
				//bullet.speed = ammoSpeed;
				bullet.damage = ammoDamage;
				bullet.lifetime = ammoActiveTime;
				bullet.loc = ammoSpawnPos;
				bullet.transform.parent = transform;

				/*
				float offset = Random.Range(-40.0f,40.0f);
				if(offset>0) {
					Transform route = ammoSpawnPos.transform;
					bullet.loc = route.Rotate(Vector3.right*offset);
				} else {
					Transform route = ammoSpawnPos.transform;
					bullet.loc = route.Rotate(Vector3.left*offset);
				}
				*/

			}
			lastFired = Time.time;
		}
	}
}
