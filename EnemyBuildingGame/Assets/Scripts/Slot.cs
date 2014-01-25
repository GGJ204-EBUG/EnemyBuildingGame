using UnityEngine;
using System.Collections;
using System;

public class Slot{ 
	public Slot(Type type, Vector3 position, Quaternion direction){
		part = null;
		this.position = position;
		this.direction = direction;
		this.type =  type;
	}
	private Type type;
	Part part{
		set{
			if(type.IsAssignableFrom(value.GetType())){
				part = value;
			}else{
				throw new Exception("Mitä jäbä duunaa?");
			}
		}
		get{
			return part;
		}
	}
	Vector3 position;
	Quaternion direction;
}
