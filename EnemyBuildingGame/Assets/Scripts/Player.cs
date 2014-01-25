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
			float input;
			if (isPlayerOne)
			{
				input = Input.GetAxis("Player One Turn");
			}
			else
			{
				input = Input.GetAxis("Player Two Turn");
			}
			robot.Turn(input);
		}
	}

	void FixedUpdate()
	{
		if (robot != null)
		{
			float input;
			if (isPlayerOne)
			{
				input = Input.GetAxis("Player One Forward");
			}
			else
			{
				input = Input.GetAxis("Player Two Forward");
			}
			robot.Accelerate(input);
		}
	}
}
