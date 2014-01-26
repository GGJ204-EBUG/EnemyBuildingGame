using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour
{
	public Robot prototype;
	public PartList partList;
	public TextMesh label;
	public GenericButton doneButton;

	private Player Current;

	void Start ()
	{
		Current = EBG.P2;
		label.text = EBG.P1.PlayerName;
		//doneButton.gameObject.SetActive(false);

		prototype = Current.prototype;
		prototype.gameObject.SetActive(true);
		Current.SetPrototypeWeaponsEnabled(false);
		partList.robot = prototype;
	}

	void OnEnable()
	{
		doneButton.OnTouchEnded += HandleOnTouchEnded;
	}

	void OnDisable()
	{
		doneButton.OnTouchEnded -= HandleOnTouchEnded;
	}

	void HandleOnTouchEnded (GenericButton arg1)
	{
		Done ();
	}

	void Done()
	{
		Current.SetProtoType(prototype);

		if (Current == EBG.P2)
		{
			Current = EBG.P1;
			Current.SetPrototypeWeaponsEnabled(false);
			label.text = EBG.P2.PlayerName;

			prototype = Current.prototype;
			prototype.gameObject.SetActive(true);
			partList.robot = prototype;
		}
		else
		{
			Application.LoadLevel("Battle_forest");
		}
	}
}
