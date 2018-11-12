using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameOverController : MonoBehaviour {

  #region  Singleton
  public static GameOverController instance;
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
  }

  #endregion

  TimeTracker timeTracker;
  public GameObject gameOverScreen;
  bool isGameOver = false;
  private void Start() {
    timeTracker = TimeTracker.instance;
    if(gameOverScreen==null) throw new System.Exception("Game Over Controller Missing UI Components");
  }

	public void EndGame()
	{
		timeTracker.SetTimerRunning(false);
    gameOverScreen.SetActive(true);
    isGameOver = true;
	}

  public bool IsGameOver(){
    return isGameOver;
  }

}
