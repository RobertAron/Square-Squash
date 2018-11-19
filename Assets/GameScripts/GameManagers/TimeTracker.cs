using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour
{

  #region  Singleton
  public static TimeTracker instance;
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
  }
  #endregion

  GameOverController gameOverController;
  float timeRemaining;
  bool runTimer = true;
  public float timePerLevel = 10;

  private void Start()
  {
    gameOverController = GameOverController.instance;
    timeRemaining = timePerLevel * PlayerPrefs.GetInt(PrefKeys.playerLevel);
  }


  void FixedUpdate()
  {
    if (runTimer)
      UpdateTimer();
  }

  void UpdateTimer()
  {
    if (timeRemaining > 0)
    {
      if (runTimer) timeRemaining -= Time.fixedDeltaTime;
    }
    else
    {
      gameOverController.EndGame();
      timeRemaining = 0;
    }
  }

  public void IncreaseRemainingTime(float increase)
  {
    timeRemaining += increase;
  }
  public float GetTimeRemaining()
  {
    return timeRemaining;
  }
  public void SetTimerRunning(bool runTimer)
  {
    this.runTimer = runTimer;
  }
}
