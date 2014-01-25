using UnityEngine;
using System.Collections;

public struct Slot {
	public Slot(Vector3 position, Quaternion direction){
		part = null;
		this.position = position;
		this.direction = direction;
	}
	Part part;
	Vector3 position;
	Quaternion direction;
}
