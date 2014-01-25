using UnityEngine;
using System.Collections;
using System;

public class Slot : MonoBehaviour{ 
	public PartType type;
	private Part attachment;

	public Part Attachment {
		set {
			if(CanReplace (value)){
				attachment = value;
			}else{
				throw new Exception("Mitä jäbä duunaa?");
			}
		}
		get {
			return attachment;
		}
	}

	public bool CanSet (Part part)
	{
		return part.type == type;
	}

	public bool CanReplace (Part part){
		return part == null || part.type == type;
	}

	public enum PartType{
		Upper = 0, Lower = 1, Weapon = 2
	}
}
