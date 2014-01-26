using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour {
	public Transform player1Start;
	public Transform player2Start;
	public float introTime = 5;
	public AudioClip music;
	public AudioClip fanfare;
	private float gameTimer = 0;
	public TextMesh counter;

	public Player Winner { get; private set; }

	// Use this for initialization
	void Start () {
		EBG.P1.MakeRobot();
		EBG.P2.MakeRobot();

		EBG.P1.robot.transform.position = player1Start.position;
		EBG.P1.robot.transform.rotation = player1Start.rotation;
		EBG.P2.robot.transform.position = player2Start.position;
		EBG.P2.robot.transform.rotation = player2Start.rotation;

		EBG.CurrentState = EBG.GameState.MatchIntro;

		if (music != null) AudioManager.Instance.PlayMusic(music, true);
	}

	void Update()
	{
		if (EBG.CurrentState == EBG.GameState.MatchIntro)
		{
			gameTimer += Time.deltaTime;

			if (gameTimer > introTime)
			{
				EBG.CurrentState = EBG.GameState.Playing;
				counter.gameObject.SetActive(false);
			}
			else
			{
				counter.text = "-" + Mathf.CeilToInt(introTime - gameTimer) + "-";
			}
		}

		if (EBG.CurrentState == EBG.GameState.Playing)
		{
			if (EBG.P1.robot == null)
			{
				EBG.CurrentState = EBG.GameState.GameOver;
				Winner = EBG.P1;
				if (fanfare != null) AudioManager.Instance.PlayMusic(fanfare, false);
			}
			if (EBG.P2.robot == null)
			{
				EBG.CurrentState = EBG.GameState.GameOver;
				Winner = EBG.P2;
				if (fanfare != null) AudioManager.Instance.PlayMusic(fanfare, false);
			}
		}
	}

	void OnGUI()
	{
		if (EBG.CurrentState == EBG.GameState.GameOver)
		{
			if (GUI.Button(new Rect(Screen.width * 0.5f - 200, Screen.height * 0.5f - 50, 400, 100), Winner.PlayerName + " was defeated.\n" + Winner.PlayerName + " wins!\nRematch?"))
			{
				RestartGame();
			}
		}
	}

	void RestartGame()
	{
		if (EBG.P1.robot != null) Destroy(EBG.P1.robot.gameObject);
		if (EBG.P2.robot != null) Destroy(EBG.P2.robot.gameObject);
		Application.LoadLevel(1);
	}
}
