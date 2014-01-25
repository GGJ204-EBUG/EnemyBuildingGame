using UnityEngine;
using System.Collections;

public class InputProcessor : MonoBehaviour
{
		private Vector3 lastVec;
		private GameObject last;
		private bool dissable;
		private float moveDist;


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
				bool didHit = Physics.Raycast (ray, out hit, 100, 1 << LayerMask.NameToLayer("GUI"));
				if (didHit) {
						if (Input.GetMouseButton (0)) {
								moveDist += Vector3.Distance (hit.point, lastVec);
								if (moveDist > 0.1) {
										dissable = true;
								}
								if (hit.collider.attachedRigidbody != null) {
										hit.collider.attachedRigidbody.SendMessage ("RelativeChange", hit.point - lastVec, SendMessageOptions.DontRequireReceiver);
								}
						}
						if (Input.GetMouseButtonDown (0) || Input.GetMouseButtonUp (0)) {
								moveDist = 0;
								GameObject cur = hit.collider.gameObject;
								if (!dissable) {
										if (cur.Equals (last)) {
												cur.SendMessage ("ButtonPressed", SendMessageOptions.DontRequireReceiver);
												last = null;
										} else {
												last = cur;
										}
								}else{
									last = null;
									dissable = false;
								}
						}
						lastVec = hit.point;
						
				}
				//float scroll = Input.GetAxis("Mouse ScrollWheel");
		}
}
