using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Robot : MonoBehaviour {
	public Part part;

	public float rotateSpeed = 10;
	public float acceleration = 10;

	public void Accelerate(float amount)
	{		
		rigidbody.AddRelativeForce(Vector3.forward * acceleration * amount, ForceMode.Acceleration);
	}

	public void Turn(float amount)
	{
		transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * amount);
	}
}
