using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	public bool isPlayerOne;
	public Renderer bar;

	private Vector3 origScale;
	private Vector3 origPos;
	private Player p;
	private DamageReceiver damageReceiver;

	void Start()
	{
		if (isPlayerOne) p = EBG.P1;
		else p = EBG.P2;

		origScale = bar.transform.localScale;
		origPos = bar.transform.localPosition;
	}
	// Update is called once per frame
	void Update ()
	{
		if (p.robot != null)
		{
			if (damageReceiver == null) damageReceiver = p.robot.GetComponent<DamageReceiver>();

			bar.enabled = true;

			float pPercentage = 1 - damageReceiver.Damage / damageReceiver.health;

			float barPercentage = Mathf.Log(pPercentage);

			bar.transform.localScale = new Vector3(origScale.x * pPercentage, origScale.y, origScale.z);
			bar.transform.localPosition = origPos - Vector3.right * barPercentage * origScale.x * 0.5f;
		}
		else
		{
			bar.enabled = false;
		}

	}
}
