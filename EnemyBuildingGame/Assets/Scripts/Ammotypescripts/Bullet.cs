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

	void OnTriggerEnter(Collider col)
	{

		if (!destroyed)
		{
			destroyed = true;

			GameObject target;
			if (col.attachedRigidbody != null) 
			{
				target = col.attachedRigidbody.gameObject;
			}
			else
			{
				target = col.gameObject;
			}
			Damage dam = new Damage();
			dam.amount = damage;
			dam.source = this;
			dam.targetCollider = col;

			DamageReceiver receiver = target.GetComponent<DamageReceiver>();
			if (receiver != null)
			{
				receiver.TakeDamage(dam);
			}

			Destroy(gameObject);
		}
	}
}
