using UnityEngine;
using System.Collections;

public class MissileLauncher : Weapon
{
	public Missile ammoPrefab;
	public Transform ammoSpawnPos;

	private Player enemy;

	public override void Fire(double time)
	{
		base.Fire (time);

		if (ammoPrefab != null)
		{
			if (enemy == null)
			{
				Transform tr = transform;
				while (tr.parent != null && enemy == null)
				{
					Robot r = tr.parent.GetComponent<Robot>();
					if (r != null)
					{
						if (r == EBG.P1.robot) enemy = EBG.P2;
						else enemy = EBG.P1;
						break;
					}
					tr = tr.parent;
				}
			}

			GameObject go = Instantiate(ammoPrefab.gameObject, ammoSpawnPos.position, ammoSpawnPos.rotation) as GameObject;

			if (enemy != null && enemy.robot != null)
			{
				Missile missile = go.GetComponent<Missile>();
				missile.target = enemy.robot.transform;
			}
		}
	}
}
