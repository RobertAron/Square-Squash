using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCard : MonoBehaviour {
	[SerializeField] Text placementText;
	[SerializeField] Text playerNameText;
	[SerializeField] Text scoreText;

	public void SetText(int placement, string playerName, int score){
		placementText.text = placement.ToString();
		playerNameText.text = playerName;
		scoreText.text = score.ToString();
	}
}
