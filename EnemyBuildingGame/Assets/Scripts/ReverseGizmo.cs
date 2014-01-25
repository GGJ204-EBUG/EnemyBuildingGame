using UnityEngine;
using System.Collections;

public class ReverseGizmo : MonoBehaviour
{
	public SpriteRenderer buttonBg;
	public MoveGizmo mover;

	public Color activeColor = Color.red;
	private Color inActiveColor;
	private float pressTime;

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
		inActiveColor = buttonBg.color;
	}
	
	// Update is called once per frame
	void Update () {
		buttonBg.color = Color.Lerp(buttonBg.color, inActiveColor, Time.time - pressTime);
	}

	void OnTouch(Vector2 position)
	{
		OnTouch(new Vector3(position.x, position.y, 0));
	}

	void OnTouch(Vector3 position)
	{
		pressTime = Time.time;
		mover.isReversing = true;
		buttonBg.color = activeColor;
	}
}
