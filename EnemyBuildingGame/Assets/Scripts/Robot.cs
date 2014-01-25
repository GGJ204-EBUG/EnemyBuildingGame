using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Robot : MonoBehaviour {
	public Part part;

	public float rotateSpeed = 10;
	public float acceleration = 10;

	public float TargetHeading { get; set; }
	public float TargetAcceleration { get; set; }
	private Vector3 targetDirection;

	public float CurrentHeading { get; private set; }
	public float CurrentAcceleration { get; private set; }

	public Transform MoveTarget { get; private set;}

	void Start()
	{
		GameObject go = new GameObject("Move target dummy");
		go.transform.parent = transform;
		MoveTarget = go.transform;
	}
	void Update()
	{
		if (CurrentHeading > TargetHeading + 180) CurrentHeading -= 360;
		else if (CurrentHeading < TargetHeading - 180) CurrentHeading += 360;
		CurrentHeading = Mathf.MoveTowards(CurrentHeading, TargetHeading, rotateSpeed * Time.deltaTime);
		Quaternion toAngle = Quaternion.AngleAxis(CurrentHeading, Vector3.up);
		transform.localRotation = toAngle;
	}

	void FixedUpdate()
	{
		float dot = Vector3.Dot(MoveTarget.forward, transform.forward);

		if (dot > 0.7f)
		{
			CurrentAcceleration = Mathf.MoveTowards(CurrentAcceleration, TargetAcceleration, acceleration * Time.deltaTime);
			rigidbody.AddRelativeForce(Vector3.forward * CurrentAcceleration);
		}
		else if (dot < -0.85f)
		{
			CurrentAcceleration = Mathf.MoveTowards(CurrentAcceleration, TargetAcceleration, acceleration * Time.deltaTime);
			rigidbody.AddRelativeForce(-Vector3.forward * CurrentAcceleration);
		}
	}

	public void AccelerateTowards(float targetAcceleration)
	{
		Debug.Log("targetAcceleration: " + targetAcceleration);
		targetAcceleration = Mathf.Clamp(targetAcceleration, -0.5f * acceleration, acceleration);
		TargetAcceleration = targetAcceleration * acceleration;
	}

	public void TurnTowards(float targetHeading)
	{
		Debug.Log("TurnTowards: " + targetHeading);
		this.TargetHeading = targetHeading;
		MoveTarget.eulerAngles = Vector3.up * TargetHeading;
	}
}
