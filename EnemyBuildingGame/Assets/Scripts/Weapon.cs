using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	public float ammoDamage;
	public float ammoSpeed;

	public Bullet ammoPrefab;
	public Transform ammoSpawnPos;
	public float coolDown = 0.25f;
	private float lastFired;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Fire ();
	}

	public void Fire()
	{
		if (Time.time > lastFired + coolDown)
		{
			GameObject go = Instantiate(ammoPrefab.gameObject, ammoSpawnPos.position, ammoSpawnPos.rotation) as GameObject;
			Bullet bullet = go.GetComponent<Bullet>();
			bullet.speed = ammoSpeed;
			bullet.damage = ammoDamage;
			lastFired = Time.time;
		}
	}
}
