using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
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
  }
	#endregion

  private void Start() {
    timeTracker = TimeTracker.instance;
  }

  public void AddPoint()
  {
    itemsCleared += 1;
    timeTracker.IncreaseRemainingTime(0.01f);
  }

}
