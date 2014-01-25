using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public float damage;
	public float damageTime;
	public float timestamp;

	// Use this for initialization
	void Start () {
	
		transform.localScale*=5.0f;
		timestamp = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time>timestamp+damageTime) {
	
			Destroy (gameObject);
		}

	}

	void OnTriggerEnter(Collider col) 
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
		Damage dam = new Damage();
		dam.amount = damage;
		dam.source = this;
		dam.targetCollider = col;
		
		DamageReceiver receiver = target.GetComponent<DamageReceiver>();
		if (receiver != null)
		{
			//Debug.Log("bum");
			receiver.TakeDamage(dam);
		}
		
	}
}
