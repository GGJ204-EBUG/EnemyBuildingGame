using UnityEngine;
using System.Collections;

public class MoveGizmo : MonoBehaviour 
{
	public bool isPlayerOne = true;

	public Transform targetMoveGizmo;
	public Transform realMoveGizmo;

	[HideInInspector]
	public bool isReversing;

	private Player p;

	private float targetAcceleration;
	private float targetDirection;


	void Awake()
	{
		if (Application.platform != RuntimePlatform.Android &&
			Application.platform != RuntimePlatform.IPhonePlayer &&
			Application.platform != RuntimePlatform.WP8Player
		    )
		{
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlayerOne) p = EBG.P1;
		else p = EBG.P2;

		if (p != null && p.robot != null)
		{
			p.robot.TurnTowards(targetDirection);
			if (isReversing) p.robot.AccelerateTowards(- 0.75f * targetAcceleration);
			else p.robot.AccelerateTowards(targetAcceleration);

			realMoveGizmo.localEulerAngles = Vector3.forward * (360 - p.robot.CurrentHeading);
		}

		isReversing = false;
	}

	void OnTouch(Vector2 position)
	{
		OnTouch(new Vector3(position.x, position.y, 0));
	}

	void OnTouch(Vector3 position)
	{
		targetMoveGizmo.position = position;

		if (p != null && p.robot != null)
		{
			float speed = targetMoveGizmo.localPosition.magnitude * 1.5f;
			if (speed < 0.25f)
			{
				targetAcceleration = 0;
				targetMoveGizmo.localPosition = Vector3.zero;
			}
			else
			{
				targetAcceleration = speed;

				if (targetMoveGizmo.localPosition.x >= 0) targetDirection = Vector3.Angle(targetMoveGizmo.localPosition, Vector3.up);
				else targetDirection = 360 - Vector3.Angle(targetMoveGizmo.localPosition, Vector3.up);
			}
		}
	}
}
