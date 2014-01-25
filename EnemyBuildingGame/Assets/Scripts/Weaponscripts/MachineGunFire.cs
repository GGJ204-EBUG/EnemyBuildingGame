using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MachineGunFire : Part
{
	public float ammoDamage;
	public float ammoSpeed;

	public Bullet ammoPrefab;
	public Transform ammoSpawnPos;
	public float coolDown = 0.25f;
	private float lastFired;


	private Slot[] slots = {};
	override public Slot[] Slots {
		get {
			return slots;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Fire ();
	}

	public void Fire()
	{
		if (Time.time > lastFired + coolDown)
		{
			GameObject go = Instantiate(ammoPrefab.gameObject, ammoSpawnPos.position, ammoSpawnPos.rotation) as GameObject;
			Bullet bullet = go.GetComponent<Bullet>();
			bullet.speed = ammoSpeed;
			bullet.damage = ammoDamage;
			lastFired = Time.time;
		}
	}
}
