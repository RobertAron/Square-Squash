using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
