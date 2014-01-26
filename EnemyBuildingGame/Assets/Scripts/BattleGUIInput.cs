using UnityEngine;
using System.Collections;

public class BattleGUIInput : MonoBehaviour 
{
	public Camera cam;

	void Update ()
	{
		for (int i = 0; i < Input.touchCount; i++)
		{
			RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.touches[i].position), Vector3.forward);
			if (hit != null && hit.collider != null)
			{
				if (Input.touches[i].phase == TouchPhase.Ended)
				{
					hit.collider.SendMessage("OnTouchEnd", SendMessageOptions.DontRequireReceiver);
				}
				else
				{
					hit.collider.SendMessage("OnTouch", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
		if (Input.touchCount == 0 && Input.GetMouseButton(0) || Input.GetMouseButtonUp(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
			if (hit != null && hit.collider != null)
			{
				if (Input.GetMouseButtonUp(0))
				{
					hit.collider.SendMessage("OnTouchEnd", SendMessageOptions.DontRequireReceiver);
				}
				else
				{
					hit.collider.SendMessage("OnTouch", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}
