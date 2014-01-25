using UnityEngine;
using System.Collections;

public class GrowOnMove : MonoBehaviour {

	float lifetime;
	float createtime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.localScale *= 1.01f;

	}
}
