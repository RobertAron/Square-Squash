using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameOverController : MonoBehaviour
{

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
  PointSystem pointsSystem;
  [SerializeField] GameObject gameOverScreen;
  [SerializeField] LevelUpAnimator levelUpAnimator;


  bool isGameOver = false;
  private void Start()
  {
    timeTracker = TimeTracker.instance;
    if (gameOverScreen == null) throw new System.Exception("Game Over Controller Missing UI Components");
    pointsSystem = PointSystem.instance;
    if (pointsSystem == null) throw new System.Exception("Game Over Controller unable to reference Points System");
  }

  public void EndGame()
  {
    timeTracker.SetTimerRunning(false);
    gameOverScreen.SetActive(true);
    int pointsEarned = pointsSystem.GetCurrentPoints();
    int currentLevel = PlayerPrefs.GetInt(PrefKeys.playerLevel);
    int currentExp = PlayerPrefs.GetInt(PrefKeys.playerExp);;
    levelUpAnimator.LevelUpAnimation(currentLevel,currentExp,pointsSystem.GetCurrentPoints());
    UpdatePlayerExp(pointsEarned);
    isGameOver = true;
  }

  public bool IsGameOver()
  {
    return isGameOver;
  }

  void UpdatePlayerExp(int expGained)
  {
    int playerLevel = PlayerPrefs.GetInt(PrefKeys.playerLevel);
    int totalPointsNeededToLevelUp = StaticCalcs.experienceToLevel(playerLevel);
    int currentExp = PlayerPrefs.GetInt(PrefKeys.playerExp);
    int expAfter = expGained + currentExp;
    if (expAfter >= totalPointsNeededToLevelUp)
    {
      int expTowardsNextLevel = expAfter - totalPointsNeededToLevelUp;
      PlayerPrefs.SetInt(PrefKeys.playerLevel, playerLevel + 1);
      PlayerPrefs.SetInt(PrefKeys.playerExp, 0);
      UpdatePlayerExp(expTowardsNextLevel);
    }
    else
    {
      PlayerPrefs.SetInt(PrefKeys.playerExp, expAfter);
      PlayerPrefs.Save();
    }
  }
}
