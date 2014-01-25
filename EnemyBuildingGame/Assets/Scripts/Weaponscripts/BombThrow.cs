using UnityEngine;
using System.Collections;

public class BombThrow : MonoBehaviour {

	public Bomb ammoPrefab;
	public Transform ammoSpawnPos;
	public float fuse;
	public float expRadius;
	public float expDamage;

	public float coolDown;
	private float lastFired;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time>lastFired+coolDown) {
			Throw();
			lastFired=Time.time;

		}
	}

	void Throw () {
		GameObject go = Instantiate(ammoPrefab.gameObject, ammoSpawnPos.position, ammoSpawnPos.rotation) as GameObject;

		
	}
}
