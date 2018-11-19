using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PointSystem : MonoBehaviour
{
  [SerializeField]
  ScoreDisplay scoreDisplay;
  [SerializeField]
  MultiplierRadial multiplierRadial;
  [SerializeField]
  MultiplierText multiplierText;
  [SerializeField]
  int pointValue = 0;
  TimeTracker timeTracker;
  int currentMultiplier = 1;
  float currentMultiplierTime = float.PositiveInfinity;
  float maxMultiplierTime = float.PositiveInfinity;


	#region  Singleton
  
  
  public static PointSystem instance;
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
    if(scoreDisplay==null||multiplierRadial==null||multiplierText==null) throw new System.Exception("Point system is missing score display object.");
  }
	#endregion

  private void Start() {
    timeTracker = TimeTracker.instance;
    scoreDisplay.UpdateScore(pointValue);
  }

  public void AddPoint()
  {
    pointValue += 1*currentMultiplier;
    timeTracker.IncreaseRemainingTime(0.01f);
    scoreDisplay.UpdateScore(pointValue);
  }

  private void FixedUpdate() {
    currentMultiplierTime -= Time.fixedDeltaTime;
    if(currentMultiplierTime<0){
      currentMultiplier -= 1;
      UpdateMultiplierTime();
    }
    multiplierRadial.SetFillAmount(currentMultiplierTime/maxMultiplierTime);
  }
  
  void UpdateMultiplierTime(){
    if(currentMultiplier==1) {
      currentMultiplierTime =  float.PositiveInfinity;
    }
    else {
      currentMultiplierTime = 15 - currentMultiplier;
    }
    maxMultiplierTime = currentMultiplierTime;
    multiplierText.SetMultiplierText(currentMultiplier);
  }

  public void IncreaseMultiplier(){
    currentMultiplier+=1;
    UpdateMultiplierTime();
  }

  public int GetCurrentPoints(){
    return pointValue;
  }
}
