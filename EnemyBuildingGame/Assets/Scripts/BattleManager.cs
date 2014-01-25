using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour {
	public GameObject robotPrefab;

	public Transform player1Start;
	public Transform player2Start;

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.Instantiate(robotPrefab, player1Start.position, player1Start.rotation) as GameObject;
		go.transform.parent = EBG.P1.transform;
		EBG.P1.robot = go.GetComponent<Robot>();

		go = GameObject.Instantiate(robotPrefab, player2Start.position, player2Start.rotation) as GameObject;
		go.transform.parent = EBG.P2.transform;
		EBG.P2.robot = go.GetComponent<Robot>();
	}

}
