using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {
	public GenericButton backButton;

	void OnEnable()
	{
		backButton.OnTouchEnded += OnButtonPress;
	}

	void OnDisable()
	{
		backButton.OnTouchEnded -= OnButtonPress;
	}

	void OnButtonPress(GenericButton button)
	{
		Application.LoadLevel(2);
	}
}
