using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour 
{
	public float time = .5f;
	Color col;

	void Start()
	{
		col = Color.white;

	}

	// Update is called once per frame
	void Update () {
		if (col.a <= 0) Application.LoadLevel(1);
	}

	void OnGUI()
	{
		GUIStyle style = new GUIStyle(GUI.skin.label);
		style.fontSize = 50;
		style.alignment = TextAnchor.MiddleCenter;

		if (Time.time > 2f) col.a -= Time.deltaTime;

		GUI.color = col;

		GUI.Label(new Rect(0,0,Screen.width,Screen.height), "EBG", style);

		GUI.color = Color.white;
	}

}
