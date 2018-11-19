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
		playerLevel = PlayerPrefs.GetInt("PlayerLevel", 1);
    playerExp = PlayerPrefs.GetInt("PlayerEXP", 0);
  }

  #endregion

  public int GetPlayerLevel(){
    return playerLevel;
  }
  public int GetExp(){
    return playerExp;
  }

}
