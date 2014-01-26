using UnityEngine;
using System.Collections;

public class HealthText : MonoBehaviour {
	public TextMesh text;
	public DamageReceiver robot;


	// Update is called once per frame
	void Update () {
		if (robot != null)
		{
			float perc = 1 - robot.Damage / robot.health;
			text.text = Mathf.RoundToInt(perc * 100).ToString() + "%";
		}
	}

	void LateUpdate()
	{
		transform.LookAt(Camera.main.transform.position);
	}
}
