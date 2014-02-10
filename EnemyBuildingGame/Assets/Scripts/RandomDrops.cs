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

	void Start () {
		Invoke("Drop", startTime + Random.Range(minInterval, maxInterval)); 
	}

	void Drop()
	{
		Vector3 pos = new Vector3(
			Random.Range(-areaRadius, areaRadius),
			height,
			Random.Range(-areaRadius, areaRadius)
			) + transform.position;

		Instantiate(dropPrefab, pos, Quaternion.identity);

		if (EBG.CurrentState == EBG.GameState.Playing)
		{
			Invoke("Drop", Random.Range(minInterval, maxInterval)); 
		}
	}
}
