using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour
{
	public float propulsion;
	public float fuel;
	public float turn;
	public float timer;
	public float minFuse = 0.5f;
	public GameObject explosion;
	
	public ParticleSystem engineParticles;

	public Transform target;

	private float startTime;

	bool done = false;

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
			rigidbody.constraints = RigidbodyConstraints.None;
			if (engineParticles != null) engineParticles.Stop();
		}
	}

	void FixedUpdate()
	{
		if (propulsion > 0) 
		{
			rigidbody.AddRelativeForce(Vector3.forward * propulsion, ForceMode.Acceleration);

			if (target != null)
			{
				Quaternion lookRot = Quaternion.LookRotation(target.position - transform.position, Vector3.forward);
				transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, turn);
			}
		}
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
		if (done) return;

		done = true;
		Instantiate(explosion, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
