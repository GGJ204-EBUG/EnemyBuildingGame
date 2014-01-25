using UnityEngine;
using System.Collections;

public class Plasma : MonoBehaviour {

	public float damage=1;
	public float speed;
	public float lifetime=3;
	public float timecreated;


	// Use this for initialization
	void Start () {
	
		timecreated = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
		
		if(Time.time > timecreated+lifetime)
			Destroy(gameObject);

		transform.Translate(Vector3.forward * Time.deltaTime * speed);
		transform.localScale *= 1.015f;

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
		Damage dam = new Damage();
		dam.amount = damage/((Time.time/timecreated)+1.0f);
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
