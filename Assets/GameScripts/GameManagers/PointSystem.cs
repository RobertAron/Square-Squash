using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PointSystem : MonoBehaviour
{
  [SerializeField]
  ScoreDisplay scoreDisplay;
  [SerializeField]
  MultiplierText multiplierText;
  [SerializeField]
  int pointValue = 0;
  int currentMultiplier = 1;


	#region  Singleton
  
  
  public static PointSystem instance;
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
    if(scoreDisplay==null||multiplierText==null) throw new System.Exception("Point system is missing score display object.");
  }
	#endregion

  private void Start() {
    scoreDisplay.HardSet(pointValue);
  }

  public void AddPoint()
  {
    pointValue += currentMultiplier;
    scoreDisplay.UpdateScore(pointValue);
  }

  public void IncreaseMultiplier(){
    currentMultiplier+=1;
    multiplierText.SetMultiplierText(currentMultiplier);
  }

  public int GetCurrentPoints(){
    return pointValue;
  }
}
