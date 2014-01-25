using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Part : MonoBehaviour {
	abstract public Slot[] Slots{
		get;
	}
}
