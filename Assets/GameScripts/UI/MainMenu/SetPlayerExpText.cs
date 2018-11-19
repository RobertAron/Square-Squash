using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SetPlayerExpText : MonoBehaviour {
	string playerExpBaseText = "/";
	// Use this for initialization
	void Start () {
		MainMenuGameState gameState = MainMenuGameState.instance;
		GetComponent<Text>().text =  gameState.GetExp() + playerExpBaseText + StaticCalcs.experienceToLevel(gameState.GetPlayerLevel());
	}
}
