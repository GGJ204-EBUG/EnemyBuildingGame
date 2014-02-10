using UnityEngine;
using System.Collections;

public class BombThrow : Part {

	public Bomb ammoPrefab;
	public Transform ammoSpawnPos;
	public float fuse;
	public float expRadius;
	public float expDamage;
	public float expTime;
	public Vector3 throwForce = new Vector3(0, 70, 150);

	public float coolDown;
	private float lastFired;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time>lastFired+coolDown && EBG.CurrentState == EBG.GameState.Playing) {
			Throw();
			lastFired=Time.time;

		}
	}

	void Throw () {
		if(ammoPrefab != null) {
			GameObject go = Instantiate(ammoPrefab.gameObject, ammoSpawnPos.position, ammoSpawnPos.rotation) as GameObject;
			go.rigidbody.AddRelativeForce(throwForce);
			Bomb bomb = go.GetComponent<Bomb>();
			bomb.fuseLength = fuse;
			bomb.damage = expDamage;
		}
			
	}
}
