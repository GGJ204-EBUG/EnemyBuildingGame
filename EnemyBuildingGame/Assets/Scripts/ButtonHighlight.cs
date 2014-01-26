using UnityEngine;
using System.Collections;

public class ButtonHighlight : MonoBehaviour {

	public SpriteRenderer buttonBg;
	public Color activeColor = Color.red;
	public Color selectedColor = Color.green;
	private Color inActiveColor;
	private float pressTime;
	private bool selected = false;

	public void Select()
	{
		selected = true;
	}

	public void UnSelect()
	{
		selected = false;
	}

	// Use this for initialization
	void Start () {
		inActiveColor = buttonBg.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (!selected) buttonBg.color = Color.Lerp(buttonBg.color, inActiveColor, Time.time - pressTime);
		else buttonBg.color = selectedColor;
	}
	
	void OnTouch(Vector2 position)
	{
		OnTouch(new Vector3(position.x, position.y, 0));
	}
	
	void OnTouch(Vector3 position)
	{
		pressTime = Time.time;
		if (!selected) buttonBg.color = activeColor;
	}
}
