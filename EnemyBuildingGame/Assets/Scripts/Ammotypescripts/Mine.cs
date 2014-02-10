using UnityEngine;
using System.Collections;

public class Mine : Bomb {

	public float minFuseLength = 1;

	void OnCollisionEnter(Collision col)
	{
		if (Time.time < throwTime + minFuseLength || exploded) return;

		Explode();
	}
}
