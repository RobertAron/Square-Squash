using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class MultiplierText : MonoBehaviour {
	Text text;
	private void Awake() {
		text = GetComponent<Text>();
	}

	public void SetMultiplierText(int multiplierNum){
		text.text = multiplierNum + "x";
	}
}
