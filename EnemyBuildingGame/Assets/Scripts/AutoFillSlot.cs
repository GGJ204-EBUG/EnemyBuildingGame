using UnityEngine;
using System.Collections;

public class AutoFillSlot : MonoBehaviour {
	public GameObject prefab;
	private GameObject instance;

	void Start ()
	{
		if (instance == null) 
		{
			instance = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
			instance.transform.parent = transform;
		}
	}
}
