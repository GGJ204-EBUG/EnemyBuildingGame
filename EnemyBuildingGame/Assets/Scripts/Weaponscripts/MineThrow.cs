using UnityEngine;
using System.Collections;

public class MineThrow : Weapon {

	public Mine ammoPrefab;
	public Transform ammoSpawnPos;
	public float fuse;
	public float expRadius;
	public float expDamage;
	public float expTime;
	public Vector3 throwForce; // = new Vector3(0, 70, 150);

	public float coolDown;
	private float lastFired;
	

	public override void Fire(double time) {
		if(ammoPrefab != null) {
			GameObject go = Instantiate(ammoPrefab.gameObject, ammoSpawnPos.position, ammoSpawnPos.rotation) as GameObject;
			go.rigidbody.AddRelativeForce(throwForce);
			Mine bomb = go.GetComponent<Mine>();
			bomb.fuseLength = fuse;
		}
			
	}
}
