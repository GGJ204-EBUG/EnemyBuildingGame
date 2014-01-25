using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Robot : MonoBehaviour {
	public Part part;

	public float rotateSpeed = 10;
	public float acceleration = 10;

	public float TargetHeading { get; set; }
	public float TargetAcceleration { get; set; }

	public float CurrentHeading { get; private set; }
	public float CurrentAcceleration { get; private set; }

	void Update()
	{
		CurrentHeading = Mathf.MoveTowards(CurrentHeading, TargetHeading, rotateSpeed * Time.deltaTime);

	}

	void FixedUpdate()
	{
		CurrentAcceleration = Mathf.MoveTowards(CurrentAcceleration, TargetAcceleration, acceleration * Time.deltaTime);
	}

	public void AccelerateTowards(float targetAcceleration)
	{
		TargetAcceleration = targetAcceleration;
	}

	public void TurnTowards(float targetHeading)
	{
		this.TargetHeading = targetHeading;
	}

	public void Accelerate(float amount)
	{		
		rigidbody.AddRelativeForce(Vector3.forward * acceleration * amount, ForceMode.Acceleration);
	}

	public void Turn(float amount)
	{
		transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * amount);
	}
}
