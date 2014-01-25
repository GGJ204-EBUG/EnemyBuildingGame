using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour {
	public GameObject robotPrefab;

	public Transform player1Start;
	public Transform player2Start;

	public Player Winner { get; private set; }

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.Instantiate(robotPrefab, player1Start.position, player1Start.rotation) as GameObject;
		go.transform.parent = EBG.P1.transform;
		EBG.P1.robot = go.GetComponent<Robot>();

		go = GameObject.Instantiate(robotPrefab, player2Start.position, player2Start.rotation) as GameObject;
		go.transform.parent = EBG.P2.transform;
		EBG.P2.robot = go.GetComponent<Robot>();

		EBG.CurrentState = EBG.GameState.Playing;
	}


	void Update()
	{
		if (EBG.CurrentState == EBG.GameState.Playing)
		{
			if (EBG.P1.robot == null)
			{
				EBG.CurrentState = EBG.GameState.GameOver;
				Winner = EBG.P1;
			}
			if (EBG.P2.robot == null)
			{
				EBG.CurrentState = EBG.GameState.GameOver;
				Winner = EBG.P2;
			}
		}
	}

	void OnGUI()
	{
		if (EBG.CurrentState == EBG.GameState.GameOver)
		{
			if (GUI.Button(new Rect(Screen.width * 0.5f - 200, Screen.height * 0.5f - 50, 400, 100), Winner.PlayerName + " was defeated.\n" + Winner.PlayerName + " wins!\nRestart?"))
			{
				RestartGame();
			}
		}
	}

	void RestartGame()
	{
		if (EBG.P1.robot != null) Destroy(EBG.P1.robot.gameObject);
		if (EBG.P2.robot != null) Destroy(EBG.P2.robot.gameObject);
		Application.LoadLevel(Application.loadedLevel);
	}
}
