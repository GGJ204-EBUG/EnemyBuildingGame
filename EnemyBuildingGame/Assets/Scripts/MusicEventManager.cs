using UnityEngine;
using System.Collections;

public class MusicEventManager : MonoBehaviour
{
	private static MusicEventManager instance;
	public static MusicEventManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = EBG.Instance.GetComponent<MusicEventManager>();
			}
			return instance;
		}
	}

	public delegate void OnMusicBeatHandler(int count, double time);
	public static event OnMusicBeatHandler OnBeat;

	public int countTo = 16;
	double interval = 0.075;
	int totalBeats;
	int count = 0;
	double nextBeat = 0;
	double firstTime = -1;
	double gameTime;

	public void SetBPM(double bpm)
	{
		interval = 60.0 / bpm;
	}

	void Update()
	{
		gameTime = AudioSettings.dspTime;
		if (gameTime >= nextBeat)
		{
			Beat();
		}
	}

	void Beat()
	{
		if (firstTime <= 0) firstTime = gameTime;
		count ++;
		totalBeats ++;
		if (count >= countTo) count = 0;

		nextBeat = firstTime + totalBeats * interval;

		if (OnBeat != null) OnBeat(count, nextBeat);
	}

	public double GetNext()
	{
		if (nextBeat - gameTime > 0.1f) return nextBeat;
		else return nextBeat + interval;
	}
}
