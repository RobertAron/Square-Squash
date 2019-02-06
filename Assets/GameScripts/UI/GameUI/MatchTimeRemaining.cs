using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Text))]
public class MatchTimeRemaining : MonoBehaviour
{
  TimeTracker timeTracker;
  Text timeText;
  private void Start()
  {
    timeTracker = TimeTracker.instance;
    timeText = GetComponent<Text>();
  }

  private void Update()
  {
    float timeRemaining = timeTracker.GetTimeRemaining();
    if (timeRemaining != Mathf.Infinity)
    {
      TimeSpan timeSpan = TimeSpan.FromSeconds(timeRemaining);
      timeText.text = String.Format("{0:0}:{1:00}:{2:D2}",
                                    timeSpan.Minutes,
                                    timeSpan.Seconds,
                                    timeSpan.Milliseconds / 10);
    }
    else{
      timeText.text = "";
    }
  }
}
