using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreDisplay : MonoBehaviour {

	private Text textComonent;

	private void Awake() {
		textComonent = GetComponent<Text>();
	}

	public void UpdateScore(int newScore){
		textComonent.text = "Score: " + newScore;
	}
}
