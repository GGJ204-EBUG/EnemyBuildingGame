using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public bool isPlayerOne = true;
	public Transform robot;
	public float rotateSpeed = 10;
	public float acceleration = 10;
	
	private Rigidbody rigid;
	
	void Awake()
	{
		this.rigid = robot.rigidbody;
	}
	
	void Start ()
	{
	
	}
	
	void Update ()
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
			robot.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * input);
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
			
			rigid.AddRelativeForce(Vector3.forward * acceleration * input);
		}

	}
}
