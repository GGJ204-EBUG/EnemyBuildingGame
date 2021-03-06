﻿using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
	public float propulsion;
	public float fuel;
	public float timer;
	public GameObject explosion;
	public float minFuse = 0.5f;
	
	public ParticleSystem engineParticles;

	private float startTime;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}	
	
	// Update is called once per frame
	void Update () {
		if (Time.time > startTime + timer)
		{
			Explode();
		}
		else if (Time.time > startTime + fuel)
		{
			propulsion = 0;
			rigidbody.useGravity = true;
			if (engineParticles != null) engineParticles.Stop();
		}
	}

	void FixedUpdate()
	{
		if (propulsion > 0) rigidbody.AddRelativeForce(Vector3.forward * propulsion, ForceMode.Acceleration);
	}

	void OnCollisionEnter(Collision col)
	{
		if (Time.time > startTime + minFuse && col.relativeVelocity.sqrMagnitude > 1) 
		{
			Explode();
		}
	}

	void Explode()
	{
		Instantiate(explosion, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
