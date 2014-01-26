using UnityEngine;
using System.Collections;

public class GenericButton : MonoBehaviour 
{
	public event System.Action<GenericButton, Vector2> OnTouched;
	public event System.Action<GenericButton> OnTouchEnded;

	public void OnTouch(Vector2 point)
	{
		if (OnTouched != null) OnTouched(this, point);
	}

	public void OnTouchEnd()
	{
		if (OnTouchEnded != null) OnTouchEnded(this);
	}
}
