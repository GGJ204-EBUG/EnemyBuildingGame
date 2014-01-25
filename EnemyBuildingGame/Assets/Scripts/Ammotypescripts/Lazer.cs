using UnityEngine;
using System.Collections;

public class Lazer : MonoBehaviour {
	
	public float damage=1;
	public float lifetime=3.0f;
	public float timecreated;
	public Vector3 origin;
	public Transform loc;
	//public 

	LineRenderer line;

	
	// Use this for initialization
	void Start () {
		
		timecreated = Time.time;
		line = gameObject.GetComponent <LineRenderer>();

		Ray ray = new Ray(origin, loc.forward);
		RaycastHit hit;
		
		line.SetPosition(0, loc.localPosition);
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


}
