﻿using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {

	public float fuseLength;
	public float minFuseLength = 1;
	public float throwTime;
	bool exploded = false;
	public GameObject explosion;

	public Explosion damageInstance;

	public float damage;
	public float damageradius;
	public float damageTime;

	// Use this for initialization
	void Start () {
		throwTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time>(throwTime+fuseLength) && exploded == false) {
			Explode();
		}
	}

	void Explode()
	{
		if (explosion != null)
		{
			GameObject go = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
			if (go.audio != null) go.audio.PlayScheduled(MusicEventManager.Instance.GetNext());
			Destroy(go, 10);
		}
		
		if(damageInstance != null) {
			
			GameObject go = Instantiate(damageInstance.gameObject, transform.position, transform.rotation) as GameObject;
			Explosion exp = go.GetComponent<Explosion>();
			exp.damage=damage;
			
			
		}
		
		Destroy(gameObject);
		exploded = true;
	}

	void OnCollisionEnter(Collision col)
	{
		if (Time.time < throwTime + minFuseLength) return;

		Explode();
	}
}
