using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public string PlayerName;

	public bool isPlayerOne = true;
	public Robot robot;
	
	public Robot protoType;

	bool isTouchPlatform;

	void Awake()
	{
		if (!Application.isEditor &&
		    (
			Application.platform == RuntimePlatform.Android ||
		    Application.platform == RuntimePlatform.IPhonePlayer ||
		    Application.platform == RuntimePlatform.WP8Player)
		    )
		{
			isTouchPlatform = true;
		}
		else
		{
			isTouchPlatform = false;
		}
	}

	private Vector2 input;

	public void SetProtoType(Robot proto)
	{
		if (protoType != null && protoType != proto) Destroy(protoType);

		Part[] parts = proto.GetComponentsInChildren<Part>();
		for (int i = 0; i < parts.Length; i++)
		{
			parts[i].enabled = true;
		}
		proto.gameObject.SetActive(false);
		protoType = proto;
	}

	public void MakeRobot()
	{
		if (protoType == null) return;

		if (robot != null) Destroy(robot.gameObject);

		GameObject go = Instantiate(protoType.gameObject) as GameObject;
		go.SetActive(true);
		robot = go.GetComponent<Robot>();
	}

	void Update()
	{
		if (robot != null && !isTouchPlatform)
		{
			bool reverse = false;
			if (isPlayerOne)
			{

				input.x = Input.GetAxis("Player One Turn");
				input.y = Input.GetAxis("Player One Forward");

				if (Input.GetKey(KeyCode.LeftShift)) reverse = true;
			}
			else
			{
				input.x = Input.GetAxis("Player Two Turn");
				input.y = Input.GetAxis("Player Two Forward");

				if (Input.GetKey(KeyCode.RightShift)) reverse = true;
			}

			if (Mathf.Approximately(input.magnitude, 0))
			{
				robot.AccelerateTowards(0);
			}
			else
			{

				robot.TurnTowards(Quaternion.LookRotation(new Vector3(input.x, 0, input.y)).eulerAngles.y);
				if (reverse) robot.AccelerateTowards(-1);
				else robot.AccelerateTowards(1);
			}
		}
	}
}
