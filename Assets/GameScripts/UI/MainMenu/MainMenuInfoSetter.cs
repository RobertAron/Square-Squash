using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuInfoSetter : MonoBehaviour {
	[SerializeField] Text userName;
	[SerializeField] Text levelText;
	[SerializeField] Text topScoreText;
	[SerializeField] Text expText;

	// Use this for initialization
	void Start () {
		string playerName = PlayerPrefs.GetString(PrefKeys.playerName);
		int playerLevel = PlayerPrefs.GetInt(PrefKeys.playerLevel);
		int bestScore = PlayerPrefs.GetInt(PrefKeys.bestScore);
		int playerExp = PlayerPrefs.GetInt(PrefKeys.playerExp);
		userName.text = playerName;
		levelText.text = "Level: " + playerLevel.ToString();
		topScoreText.text = "Best: " + bestScore.ToString();
		expText.text = "EXP: " +playerExp+"/" +StaticCalcs.experienceToLevel(playerLevel);
	}
}
