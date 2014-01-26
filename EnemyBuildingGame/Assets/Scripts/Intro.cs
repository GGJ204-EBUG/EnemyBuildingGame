using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour
{
	public AudioClip music;

	private Animator anim;

	void Start()
	{
		anim = GetComponent<Animator>();
		AudioManager.Instance.PlayMusic(music, true);
	}

	public void Finish()
	{
		anim.StopPlayback();

		Invoke("Finally", 1f);
	}

	void Finally()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
