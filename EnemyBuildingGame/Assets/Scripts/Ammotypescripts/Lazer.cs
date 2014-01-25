using UnityEngine;
using System.Collections;

public class Lazer : MonoBehaviour {
	
	public float damage;
	public float lifetime = 0.2f;	
	public float timecreated;
	public Vector3 origin;
	public Transform loc;
	//public 

	LineRenderer line;

		
	// Use this for initialization
	void Start () {

		//Debug.Log("Laser luotu");

		timecreated = Time.time;
		line = gameObject.GetComponent <LineRenderer>();

		//Transform temp = loc;

		float offset = Random.Range (-2.0f,2.0f);
		loc.Rotate(Vector3.up*offset, Space.World);

		Ray ray = new Ray(loc.position, loc.forward);

		RaycastHit hit;
		if(Physics.Raycast (ray, out hit)) {

		line.SetPosition(0, loc.position);
		line.SetPosition (1, hit.point);
		line.enabled = true;

		Damage dam = new Damage();
		dam.amount = damage;
		dam.source = this;
		dam.targetCollider = hit.collider;

			Debug.Log ("Damage! "+dam.amount);
		if(hit.collider.attachedRigidbody != null) {
			DamageReceiver receiver = hit.collider.attachedRigidbody.GetComponent<DamageReceiver>();
		if (receiver != null)
		{
			//Debug.Log("bum");
			receiver.TakeDamage(dam);
		} 
			}
		}
		else {
			line.SetPosition(0, loc.position);
			line.SetPosition (1, loc.forward*100);
			line.enabled = true;
			
			//line.enabled = false;
		}

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


}
