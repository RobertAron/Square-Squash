using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
  [SerializeField]
  ScoreDisplay scoreDisplay;
  [SerializeField]
  int itemsCleared = 0;
  TimeTracker timeTracker;

	#region  Singleton
  public static PointSystem instance;
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
    if(scoreDisplay==null) throw new System.Exception("Point system is missing score display object.");
  }
	#endregion

  private void Start() {
    timeTracker = TimeTracker.instance;
    scoreDisplay.UpdateScore(itemsCleared);
  }

  public void AddPoint()
  {
    itemsCleared += 1;
    timeTracker.IncreaseRemainingTime(0.01f);
    scoreDisplay.UpdateScore(itemsCleared);
  }

}
