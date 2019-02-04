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

  MetaGameStateController metaGameStateController;
  float timeRemaining;
  public float timePerLevel = 10;

  private void Start()
  {
    metaGameStateController = MetaGameStateController.instance;
    timeRemaining = timePerLevel * PlayerPrefs.GetInt(PrefKeys.playerLevel);
  }


  void FixedUpdate()
  {
    if(timeRemaining < 0)
    {
      metaGameStateController.EndGame();
      timeRemaining = 0;
    }
    else if (!metaGameStateController.IsGamePaused())
    {
      timeRemaining -= Time.fixedDeltaTime;
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
}
