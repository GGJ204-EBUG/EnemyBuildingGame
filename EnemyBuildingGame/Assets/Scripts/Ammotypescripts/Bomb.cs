using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	float fuselength;
	float throwtime;

	// Use this for initialization
	void Start () {
		throwtime = Time.time;


	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time>(throwtime+fuselength) {

			Debug.Log("Boom!!");
			//Create explosion


		}
	}
}
