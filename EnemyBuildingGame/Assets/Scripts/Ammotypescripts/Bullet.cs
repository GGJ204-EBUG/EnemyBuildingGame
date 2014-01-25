using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float damage = 1;
	public float speed;

	private bool destroyed = false;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * speed);
	}

	void OnCollisionEnter(Collision col)
	{

		if (!destroyed)
		{
			destroyed = true;

			GameObject target;
			if (col.collider.attachedRigidbody != null) 
			{
				target = col.collider.attachedRigidbody.gameObject;
			}
			else
			{
				target = col.gameObject;
			}
			Damage dam = new Damage();
			dam.amount = damage;
			dam.source = this;
			dam.targetCollider = col.collider;

			DamageReceiver receiver = target.GetComponent<DamageReceiver>();
			if (receiver != null)
			{
				Debug.Log("bum");
				receiver.TakeDamage(dam);
			}

			Destroy(gameObject);
		}
	}
}
