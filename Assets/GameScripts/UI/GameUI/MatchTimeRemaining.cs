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
    TimeSpan timeSpan = TimeSpan.FromSeconds(timeTracker.GetTimeRemaining());
    timeText.text = String.Format("{0:0}:{1:00}:{2:D2}",
                                  timeSpan.Minutes,
                                  timeSpan.Seconds,
                                  timeSpan.Milliseconds / 10);
  }
}
