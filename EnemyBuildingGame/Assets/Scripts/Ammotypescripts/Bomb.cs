using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public float fuseLength;
	protected float throwTime;
	protected bool exploded = false;
	public GameObject explosion;
	public float damage;

	// Use this for initialization
	void Start () {
		throwTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > (throwTime+fuseLength))
		{
			Explode();
		}
	}

	public void Explode()
	{
		if (exploded) return;

		if (explosion != null)
		{
			GameObject go = Instantiate(explosion.gameObject, transform.position, Quaternion.identity) as GameObject;
			Explosion exp = go.GetComponent<Explosion>();
			exp.damage=damage;
		}
		
		Destroy(gameObject);
		exploded = true;
	}
}
