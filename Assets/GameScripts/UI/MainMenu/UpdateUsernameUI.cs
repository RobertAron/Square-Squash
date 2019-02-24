using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUsernameUI : MonoBehaviour {
	[SerializeField] Text newUsername;
	[SerializeField] UpdatePlayerData upd;
	// Use this for initialization
	public void UpdateUsername(){
		Debug.Log("called to update user name with...");
		Debug.Log(newUsername.text);
		PlayerPrefs.SetString(PrefKeys.playerName,newUsername.text);
		upd.SetPlayerName(newUsername.text);
	}
}
