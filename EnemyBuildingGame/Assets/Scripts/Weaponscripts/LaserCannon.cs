using UnityEngine;
using System.Collections;

public class LaserCannon : Weapon
{
	public float damage;
	public Transform startPos;
	public LineRenderer line;

	private float range = 100;

	bool isFiring =	false;

	void Update()
	{
		if (isFiring)
		{
			Ray ray = new Ray(startPos.position, startPos.forward);
			RaycastHit hit;
			Vector3 hitPos;
			if (Physics.Raycast(ray, out hit, range))
			{
				hitPos = hit.point;

				GameObject target;
				if (hit.collider.attachedRigidbody != null) target = hit.collider.attachedRigidbody.gameObject;
				else target = hit.collider.gameObject;
				DamageReceiver receiver = target.GetComponent<DamageReceiver>();
				if (receiver != null)
				{
					Damage dam = new Damage();
					dam.amount = Time.deltaTime * damage;
					dam.targetCollider = hit.collider;
					dam.source = this;
					receiver.TakeDamage(dam);
				}
			}
			else
			{
				hitPos = startPos.position + startPos.forward * range;
			}

			line.SetPosition(0, startPos.position);
			line.SetPosition(1, hitPos);
		}
	}

	public override void Fire(double time)
	{
		base.Fire(time);

		isFiring = !isFiring;

		if (isFiring)
		{
			line.gameObject.SetActive(true);
		}
		else
		{
			line.gameObject.SetActive(false);
		}
	}
}
