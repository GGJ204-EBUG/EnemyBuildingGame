using UnityEngine;
using System.Collections;

public class InputProcessor : MonoBehaviour
{

		private GameObject last;

		// Use this for initialization
		void Start ()
		{
				Input.simulateMouseWithTouches = true;
		}
	
		// Update is called once per frame
		void Update ()
		{
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				bool didHit = Physics.Raycast (ray, out hit);
				if (didHit) {
						if (Input.GetMouseButtonDown (0) || Input.GetMouseButtonUp (0)) {
								GameObject cur = hit.transform.gameObject;
								if (cur.Equals (last)) {
										cur.SendMessage ("Button.ButtonPressed", SendMessageOptions.DontRequireReceiver);
										last = null;
								} else {
										last = cur;
								}
						}
				}
		}
}
