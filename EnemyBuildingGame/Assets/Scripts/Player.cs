using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public bool isPlayerOne = true;
	public Robot robot;
	
	void Update()
	{
		if (robot != null)
		{
			Vector2 input;
			if (isPlayerOne)
			{
				input.x = Input.GetAxis("Player One Turn");
				input.y = Input.GetAxis("Player One Forward");
			}
			else
			{
				input.x = Input.GetAxis("Player Two Turn");
				input.y = Input.GetAxis("Player Two Forward");
			}
			if (Mathf.Approximately(input.magnitude, 0))
			{
				robot.AccelerateTowards(0);
			}
			else
			{
				robot.TurnTowards(Quaternion.LookRotation(new Vector3(input.x, 0, input.y)).eulerAngles.y);
				robot.AccelerateTowards(robot.acceleration);
			}
		}
	}
}
