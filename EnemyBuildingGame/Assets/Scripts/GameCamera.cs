using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour {
	public static GameCamera Instance { get; private set; }

	public Camera cam;

	public float maxShake = 2;
	private float currentShake = 0;
	public float shakeFalloff = 0.5f;

	void Awake()
	{
		Instance = this;
	}

	public static void Shake(float amount)
	{
		if (Instance != null) Instance.ShakeCamera(amount);
	}

	public void ShakeCamera(float amount)
	{
		amount = Mathf.Clamp01(amount);
		currentShake = Mathf.Clamp(currentShake + amount * maxShake, 0, maxShake);
	}

	// Update is called once per frame
	void Update () {
		currentShake = Mathf.MoveTowards(currentShake, 0, shakeFalloff * Time.deltaTime);
	}

	void LateUpdate()
	{
		Vector3 shake;
		shake.x = Random.value - 0.5f;
		shake.y = Random.value - 0.5f;
		shake.z = Random.value - 0.5f;
		cam.transform.localPosition = shake * currentShake;
	}
}
