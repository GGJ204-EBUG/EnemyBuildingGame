using UnityEngine;
using System.Collections;
using System;

public class Slot{ 
	Vector3 position;
	Quaternion direction;
	private Type type;
	private Part attachment;

	public Slot(Type type, Vector3 position, Quaternion direction){
		this.position = position;
		this.direction = direction;
		this.type =  type;
	}

	public Part Attachment {
		set {
			if(value == null || type.IsAssignableFrom(value.GetType())){
				attachment = value;
			}else{
				throw new Exception("Mitä jäbä duunaa?");
			}
		}
		get {
			return attachment;
		}
	}
}
