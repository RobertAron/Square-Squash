using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Text))]
public class MatchTimeRemaining : MonoBehaviour
{

  float displayTime;
  TimeTracker timeTracker;
  Text timeText;
  private void Start()
  {
    timeTracker = TimeTracker.instance;
    timeText = GetComponent<Text>();
  }

  private void Update()
  {
    displayTime -= Time.deltaTime;
    TimeSpan timeSpan = TimeSpan.FromSeconds(displayTime);
    int minutes = timeSpan.Minutes;
    int seconds = timeSpan.Seconds;
    int ms = timeSpan.Milliseconds;
    // timeText.text = minutes + ":" + seconds + ":" + ms;
    timeText.text = String.Format ("{0:00}:{1:00}:{2:00}", 
																	timeSpan.Minutes, 
																	timeSpan.Seconds, 
																	timeSpan.Milliseconds);
  }
  private void FixedUpdate()
  {
    displayTime = timeTracker.GetTimeRemaining();
  }
}
