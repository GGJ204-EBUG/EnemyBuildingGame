using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Body : Part {
	private Slot[] slots = {
		new Slot(typeof(Upper), new Vector3(0, 10, 0), Quaternion.identity),
		new Slot(typeof(Lower), new Vector3(0, -10, 0), Quaternion.Euler(0, 90, 0))};
	override public Slot[] Slots {
		get {
			return slots;
		}
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
