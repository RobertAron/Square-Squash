using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuGameState : MonoBehaviour
{
  
	int playerLevel;
  int playerExp;
  string playerID;
  string playerName;
  int playerBestScore;
	
  #region  Singleton
  public static MainMenuGameState instance;
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
		playerLevel = PlayerPrefs.GetInt(PrefKeys.playerLevel, 1);
    playerExp = PlayerPrefs.GetInt(PrefKeys.playerExp, 0);
    playerID = PlayerPrefs.GetString(PrefKeys.playerID,System.Guid.NewGuid().ToString());
    playerName = PlayerPrefs.GetString(PrefKeys.playerName,"Anonymous");
    playerBestScore = PlayerPrefs.GetInt(PrefKeys.bestScore, 0);
		PlayerPrefs.SetInt(PrefKeys.playerLevel, playerLevel);
    PlayerPrefs.SetInt(PrefKeys.playerExp, playerExp);
    PlayerPrefs.SetString(PrefKeys.playerID, playerID);
    PlayerPrefs.SetString(PrefKeys.playerName,playerName);
    PlayerPrefs.SetInt(PrefKeys.bestScore,playerBestScore);
  }

  #endregion

  public int GetPlayerLevel(){
    return playerLevel;
  }
  public int GetExp(){
    return playerExp;
  }

  [ContextMenu("Destory All Prefs")]
	public void ResetPrefs(){
		PlayerPrefs.DeleteAll();
	}

  private void Update() {
    if(Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
  }

}
