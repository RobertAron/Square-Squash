using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuGameState : MonoBehaviour
{
  
	int playerLevel;
  int playerExp;
	
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
		PlayerPrefs.SetInt(PrefKeys.playerLevel, playerLevel);
    PlayerPrefs.SetInt(PrefKeys.playerExp, playerExp);
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

}
