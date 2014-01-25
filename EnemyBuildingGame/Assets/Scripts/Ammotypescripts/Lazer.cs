using UnityEngine;
using System.Collections;

public class Lazer : MonoBehaviour {
	
	public float damage=1;
	public float offset;
	public float lifetime=3.0f;
	public float timecreated;

	LineRenderer line;

	
	// Use this for initialization
	void Start () {
		
		timecreated = Time.time;
		line = gameObject.GetComponent <LineRenderer>();
		line.enabled = true;


	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > timecreated+lifetime)
		{
			line.enabled = false;
			Destroy (gameObject);
		}
//		transform.Translate(Vector3.forward * Time.deltaTime * speed);
		
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
		dam.amount = damage;
		dam.source = this;
		dam.targetCollider = col;
		
		DamageReceiver receiver = target.GetComponent<DamageReceiver>();
		if (receiver != null)
		{
			Debug.Log("bum");
			receiver.TakeDamage(dam);
		}
		
	}
}
