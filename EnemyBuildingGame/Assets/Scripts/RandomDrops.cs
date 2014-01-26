using UnityEngine;
using System.Collections;

public class RandomDrops : MonoBehaviour
{
	public GameObject dropPrefab;
	public float minInterval = 2;
	public float maxInterval = 10;
	public float areaRadius = 10;
	public float startTime = 10;
	public float height = 24;
	// Use this for initialization
	void Start () {
		Invoke("Drop", startTime + Random.Range(minInterval, maxInterval)); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Drop()
	{
		Vector3 pos = new Vector3(
			Random.Range(-areaRadius, areaRadius),
			height,
			Random.Range(-areaRadius, areaRadius)
			) + transform.position;

		GameObject go = Instantiate(dropPrefab, pos, Quaternion.identity) as GameObject;

		if (EBG.CurrentState == EBG.GameState.Playing)
		{
			Invoke("Drop", Random.Range(minInterval, maxInterval)); 
		}
	}
}
