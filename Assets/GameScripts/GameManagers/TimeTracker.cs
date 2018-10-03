using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTracker : MonoBehaviour {

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

	[SerializeField]
	float timeRemaining = 300;

	void FixedUpdate() {
		timeRemaining-= Time.fixedDeltaTime;
		if(timeRemaining<0)
			Debug.Log("TODO: end the game");
	}

	public void IncreaseRemainingTime(float increase)
	{
		timeRemaining += increase;
	}
	public float GetTimeRemaining(){
		return timeRemaining;
	}
}
