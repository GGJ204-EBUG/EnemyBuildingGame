using UnityEngine;
using System.Collections;

public class PartList : MonoBehaviour, ButtonList {
	public float width;
	public Robot robot;
	public PartButton button;
	public Part[] parts;
	private PartButton[] buttons;
	private float allChange;
	private Vector3 pos;

	// Use this for initialization
	void Start () {
		this.pos = transform.position;
		buttons = new PartButton[parts.Length];
		Vector3 pos = new Vector3(0, 0, -parts.Length / 2 * width);
		foreach(Part part in parts){
			PartButton b = Instantiate (button) as PartButton;
			b.robot = robot;
			b.transform.parent = this.transform;
			b.transform.localPosition = pos;
			b.part = Instantiate(part) as Part;
			foreach(MonoBehaviour script in b.part.GetComponents<MonoBehaviour>()){
				script.enabled = false;
			}
			b.part.transform.parent = b.transform;
			b.part.transform.localPosition = Vector3.zero;
			pos.z += width;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void RelativeChange (Vector3 change)
	{
		//Debug.Log ("RelativeChange: " + change.y);
		Vector3 newPos = transform.localPosition + Vector3.forward * change.z;
		newPos.z = Mathf.Clamp(newPos.z, -width * parts.Length, width * parts.Length);
		transform.localPosition = newPos;
		//allChange += change.y;
		//allChange = Mathf.Max (allChange, -width * parts.Length);
		//allChange = Mathf.Min(allChange, width * parts.Length);
		//transform.position.Set(pos.x, pos.y, pos.z + allChange);
	}
}
