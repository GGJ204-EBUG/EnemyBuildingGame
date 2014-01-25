using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlasmaBallFire : Part
{
	public float ammoDamage;
	public float ammoSpeed;
	public float ammoLifeTime = 3;

	public Plasma ammoPrefab;
	public Transform ammoSpawnPos;
	public float coolDown = 0.25f;
	private float lastFired;
	
<<<<<<< HEAD
	/*
	private Slot[] slots = {};
	override public Slot[] Slots {
		get {
			return slots;
		}
	}
	*/

=======
>>>>>>> d65dbad7dae417eb4b6892eb07502a8269565d16
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



			Plasma bullet = go.GetComponent<Plasma>();
			bullet.speed = ammoSpeed;
			bullet.damage = ammoDamage;
			//bullet.timecreated = Time;
			bullet.lifetime = ammoLifeTime;
			lastFired = Time.time;
		}
	}
}
