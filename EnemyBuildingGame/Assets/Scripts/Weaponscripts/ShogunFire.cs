using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShogunFire : Part
{
	// Shogun is like a shotgun, but with more oof. And lasers. Random but plentiful spread.

	public float ammoDamage;
	public float ammoSpeed;
	public int amountOfLazers = 10;

	public float activeTime = 0.5f;

	LineRenderer line;

	//public Lazer ammoPrefab;
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
								
				GameObject go = Instantiate(ammoPrefab.gameObject, ammoSpawnPos.position, ammoSpawnPos.rotation) as GameObject;
				Lazer bullet = go.GetComponent<Lazer>();
				//bullet.speed = ammoSpeed;
				//bullet.damage = ammoDamage;
				lastFired = Time.time;

			}
			lastFired = Time.time;
		}
	}
}
