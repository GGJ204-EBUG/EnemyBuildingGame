using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Explosion : MonoBehaviour {

	public float damage;
	public float damageTime;
	public float timestamp;
	public GameObject visualPrefab;

	private float radius;

	private List<GameObject> targets;

	// Use this for initialization
	void Start () {
		timestamp = Time.time;
		if (visualPrefab != null)
		{
			GameObject go = Instantiate(visualPrefab, transform.position, Quaternion.identity) as GameObject;
			Destroy(go, 10);
		}
		targets = new List<GameObject>();
		radius = GetComponent<SphereCollider>().radius;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time>timestamp+damageTime) {
			Destroy (gameObject);
		}

	}

	void OnTriggerStay(Collider col) 
	{
		
		GameObject target;
		if (col.attachedRigidbody != null) 
		{
			target = col.attachedRigidbody.gameObject;
		}
		else
		{
			target = col.gameObject;
		}

		if (!targets.Contains(target))
		{
			targets.Add(target);
			float dist = (target.transform.position - transform.position).magnitude;

			Damage dam = new Damage();
			dam.amount = damage * radius / (dist + 1);
			dam.source = this;
			dam.targetCollider = col;
			
			DamageReceiver receiver = target.GetComponent<DamageReceiver>();
			if (receiver != null)
			{
				receiver.TakeDamage(dam);
			}

			if (target.rigidbody != null)
			{
				target.rigidbody.AddExplosionForce(damage * 100, transform.position, radius);
			}
		}

		
	}
}
