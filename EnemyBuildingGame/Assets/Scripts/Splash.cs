using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour 
{
	public float time = .5f;

	// Update is called once per frame
	void Update () {
		if (Time.time > time) Application.LoadLevel(1);
	}

	void OnGUI()
	{
		GUIStyle style = new GUIStyle(GUI.skin.label);
		style.fontSize = 50;
		style.alignment = TextAnchor.MiddleCenter;

		GUI.Label(new Rect(0,0,Screen.width,Screen.height), "EBG", style);
	}

}
