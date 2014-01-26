using UnityEngine;
using System.Collections;

public class EBG : MonoBehaviour
{
	public enum GameState
	{
		Unknown = 0,
		Building = 1,
		Playing = 2,
		MatchOver = 3,
		GameOver = 4,
		MatchIntro = 5,
	}

	public GameState CurrentGameState { get; set; }
	public static GameState CurrentState
	{
		get
		{
			return Instance.CurrentGameState;
		}
		set
		{
			Instance.CurrentGameState = value;
		}
	}

	private static EBG instance;
	public static EBG Instance
	{
		get
		{
			if (instance == null)
			{
				GameObject go = GameObject.Instantiate(Resources.Load("EBG")) as GameObject;
				instance = go.GetComponent<EBG>();
			}
			return instance;
		}
	}

	[SerializeField]
	private Player player1;
	public Player Player1
	{
		get
		{
			return player1;
		}
	}

	[SerializeField]
	private Player player2;
	public Player Player2
	{
		get
		{
			return player2;
		}
	}

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		Application.targetFrameRate = 60;
	}

	#region static convenience methods
	public static Player P1
	{
		get { return Instance.Player1; }
	}

	public static Player P2
	{
		get { return Instance.Player2; }
	}
	#endregion
}
