using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputManager : MonoBehaviour
{
	public Button leftInput, rightInput;
	public Character character;
	
	// Update is called once per frame
	void Update ()
	{
		if (!character.lastStepIsLeft.HasValue) {
			leftInput.interactable = true;
			rightInput.interactable = true;
		} else {
			leftInput.interactable = !character.lastStepIsLeft.Value;
			rightInput.interactable = character.lastStepIsLeft.Value;
		}
	}
}
