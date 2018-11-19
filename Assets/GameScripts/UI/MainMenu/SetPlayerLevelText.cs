using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SetPlayerLevelText : MonoBehaviour {
	[SerializeField]
	string playerLevelBaseText = "Level : ";
	// Use this for initialization
	void Start () {
		GetComponent<Text>().text = playerLevelBaseText + MainMenuGameState.instance.GetPlayerLevel();
	}
}
