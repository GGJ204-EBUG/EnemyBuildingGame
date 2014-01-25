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
	double interval = 0.08;
	int totalBeats;
	int count = 0;
	float lastBeat = 0;
	double firstTime = -1;
	
	public void SetBPM(double bpm)
	{
		interval = 60.0 / bpm;
	}

	void Update()
	{
		if (Time.realtimeSinceStartup >= totalBeats * interval + firstTime)
		{
			Beat();
		}
	}

	void Beat()
	{
		if (firstTime < 0) firstTime = Time.realtimeSinceStartup;
		count ++;
		totalBeats ++;
		if (count >= countTo) count = 0;

		lastBeat = Time.realtimeSinceStartup;

		if (OnBeat != null) OnBeat(count, totalBeats * interval + firstTime - Time.realtimeSinceStartup);
	}
}
