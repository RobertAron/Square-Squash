using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class MetaGameStateController : MonoBehaviour
{

  #region  Singleton
  public static MetaGameStateController instance;
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
  }

  #endregion
  PointSystem pointsSystem;
  [SerializeField] GameObject gameOverScreen;
  [SerializeField] LevelUpAnimator levelUpAnimator;
  [SerializeField] PauseButton pauseButton;
  [SerializeField] GameObject pauseScreen;

  bool isGamePaused = false;
  private void Start()
  {
    if (gameOverScreen == null) throw new System.Exception("Game Over Controller Missing UI Components");
    pointsSystem = PointSystem.instance;
    if (pointsSystem == null) throw new System.Exception("Game Over Controller unable to reference Points System");
    if (pauseButton == null) throw new System.Exception("Game Over Controller unable to reference Pause Button");
  }

  public void EndGame()
  {
    pauseButton.SetInteractable(false);
    gameOverScreen.SetActive(true);
    int pointsEarned = pointsSystem.GetCurrentPoints();
    int currentLevel = PlayerPrefs.GetInt(PrefKeys.playerLevel);
    int currentExp = PlayerPrefs.GetInt(PrefKeys.playerExp);;
    levelUpAnimator.LevelUpAnimation(currentLevel,currentExp,pointsSystem.GetCurrentPoints());
    UpdatePlayerExp(pointsEarned);
    isGamePaused = true;
  }

  public bool IsGamePaused()
  {
    return isGamePaused;
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
  public void PauseToggle(){
    SetPause(!isGamePaused);
    // textMeshText.text = isGamePaused?"\uf04b":"\uf04c";
    pauseButton.SetImagePause(!isGamePaused);
    pauseScreen.SetActive(isGamePaused);
  }
  public void SetPauseState(bool newPauseState){
    if(newPauseState!=isGamePaused) PauseToggle();
  }
  public void HardSetPause(bool pauseSet){
    isGamePaused = pauseSet;
  }

  void SetPause(bool pauseState){
    isGamePaused = pauseState;
  }

  private void FixedUpdate() {
    if(Input.GetKeyDown(KeyCode.Escape)) SetPauseState(true);
  }
}
