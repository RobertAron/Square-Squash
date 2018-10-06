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

  [SerializeField]
  float timeRemaining = 300;
  GameOverController gameOverController;
  bool runTimer = true;

  private void Start()
  {
    gameOverController = GameOverController.instance;
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
