using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShogunFire : Part
{
	// Shogun is like a shotgun, but with more oof. And lasers. Random but plentiful spread.

	public float ammoDamage;
	public float ammoSpeed;
	
	public float ammoActiveTime = 1.0f;

	public int amountOfLazers = 10;

	LineRenderer line;

	public Lazer ammoPrefab;
	public Transform ammoSpawnPos;
	public float coolDown = 2.0f;
	private float lastFired;
	
	
	private Slot[] slots = {};
	override public Slot[] Slots {
		get {
			return slots;
		}
	}
	
	// Use this for initialization
	void Start () {
		line = gameObject.GetComponent<LineRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
		Fire ();
	}
	
	public void Fire()
	{
		if (Time.time > lastFired + coolDown)
		{
			for (int n=1; n<amountOfLazers; n++) 
			{
								
				GameObject go = Instantiate(ammoPrefab.gameObject) as GameObject;
				Lazer bullet = go.GetComponent<Lazer>();
				bullet.origin = ammoSpawnPos.position;
				//bullet.speed = ammoSpeed;
				bullet.damage = ammoDamage;
				bullet.lifetime = ammoActiveTime;
				bullet.loc = ammoSpawnPos;


			}
			lastFired = Time.time;
		}
	}
}
