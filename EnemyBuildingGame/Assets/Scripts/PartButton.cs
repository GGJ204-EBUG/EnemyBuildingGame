using UnityEngine;
using System.Collections.Generic;

public class PartButton : MonoBehaviour, Button {
	public Robot robot;
	public Part part;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ButtonPressed ()
	{
		Stack<Part> stack = new Stack<Part>();
		stack.Push (robot.part);
		Debug.Log (robot.part.Slots.Length);
		while(stack.Peek() != null){
			Part temp = stack.Pop();
			foreach(Slot slot in temp.Slots){
				Debug.Log (slot + " " + slot.Attachment);
				if(slot.CanSet(part) && slot.Attachment == null){
					slot.Attachment = Instantiate (part) as Part;
					foreach(MonoBehaviour script in slot.Attachment.GetComponents<MonoBehaviour>()){
						script.enabled = true;
					}
					slot.Attachment.transform.parent = slot.transform;
					slot.Attachment.transform.localPosition = Vector3.zero;
					slot.Attachment.transform.localRotation = Quaternion.identity;
					return;
				}
				stack.Push(slot.Attachment);
			}
		}
	}
}

