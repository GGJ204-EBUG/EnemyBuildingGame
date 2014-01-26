using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponSelection : MonoBehaviour {
	private Player Current;

	public TextMesh label;
	public List<GenericButton> buttons;
	public List<GameObject> buttonWeapons;
	public GenericButton doneButton;
	private GenericButton selected;
	private GameObject tempWeapon;
	public AudioClip music;

	public GenericButton creditsButtons;

	public GenericButton introButton;

	void Start()
	{
		label.text = EBG.P1.PlayerName;
		label.color = EBG.P1.playerColor;

		Current = EBG.P2;

		if (music != null) AudioManager.Instance.PlayMusic(music, true);
	}

	void OnEnable()
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			buttons[i].OnTouchEnded += OnButtonPress;
		}
		doneButton.OnTouchEnded += OnButtonPress;
		creditsButtons.OnTouchEnded += OnButtonPress;
		introButton.OnTouchEnded += OnButtonPress;
	}

	void OnButtonPress(GenericButton button)
	{
		if (button == selected) 
		{
			selected.GetComponent<ButtonHighlight>().UnSelect();
			selected = null;
		}
		else if (buttons.Contains(button))
		{
			if (selected != null)
			{
				selected.GetComponent<ButtonHighlight>().UnSelect();
				selected = null;
			}
			selected = button;
			selected.GetComponent<ButtonHighlight>().Select();
			SetWeapon(button);
		}
		else if (button == doneButton) Done();
		else if (button == introButton) Application.LoadLevel(1);
		else if (button == creditsButtons) Application.LoadLevel("Credits");
	}

	void OnDisable()
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			buttons[i].OnTouchEnded -= OnButtonPress;
		}
		doneButton.OnTouchEnded -= OnButtonPress;
		creditsButtons.OnTouchEnded -= OnButtonPress;
		introButton.OnTouchEnded -= OnButtonPress;
	}

	void Update()
	{
		if (selected != null) doneButton.gameObject.SetActive(true);
		else doneButton.gameObject.SetActive(false);
	}

	void SetWeapon(GenericButton button)
	{
		if (tempWeapon != null) Destroy(tempWeapon);

		Transform parent = Current.prototype.primaryPlace;

		int j = 0;
		while (parent.childCount > 0)
		{
			j++;
			Destroy(parent.GetChild(0).gameObject);
			if (j > 4) break;
		}

		int index = buttons.IndexOf(button);
		tempWeapon = Instantiate(buttonWeapons[index], parent.position, parent.rotation) as GameObject;
		tempWeapon.transform.parent = parent;
	}

	void Done()
	{
		if (Current == EBG.P2)
		{
			label.text = EBG.P2.PlayerName;
			//EBG.P2.SetProtoType(EBG.P2.robot);
			Current = EBG.P1;
			tempWeapon = null;
			label.color = EBG.P2.playerColor;
			if (selected != null)
			{
				selected.GetComponent<ButtonHighlight>().UnSelect();
				selected = null;
			}
		}
		else
		{
			//EBG.P1.SetProtoType(EBG.P1.robot);
			Application.LoadLevel("Battle_forest");
		}
	}
}
