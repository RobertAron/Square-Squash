using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelUpAnimator : MonoBehaviour {
	[SerializeField] Text levelText;
	[SerializeField] Image expRaidal;
	[SerializeField] Text expText;
	// Use this for initialization
	public void LevelUpAnimation(int startingLevel,int startingExp,int expGained){
		StartCoroutine(LevelUpAnimationCoroutine(startingLevel,startingExp,expGained));
	}

	IEnumerator LevelUpAnimationCoroutine(int startingLevel,int startingExp,int expGained){
		float expRemaining = expGained;
		float expCurrent = startingExp;
		int currentLevel = startingLevel;
		float totalExpToLevel = StaticCalcs.experienceToLevel(startingLevel);
		float accPerFrame = expGained/300f;
		float diffPerFrame = 0;
		SetEXPText(currentLevel,expCurrent,totalExpToLevel);
		yield return new WaitForSeconds(1);
		while(expRemaining>0){
			// Level Up Conditional
			diffPerFrame += accPerFrame;
			if(expCurrent==totalExpToLevel){
				diffPerFrame = 0;
				currentLevel += 1;
				totalExpToLevel = StaticCalcs.experienceToLevel(currentLevel);
				expCurrent = 0;
			}
			float expTillLevelUp = totalExpToLevel-expCurrent;
			float expThisFrame = Mathf.Min(expTillLevelUp,diffPerFrame,expRemaining);
			expRemaining -= expThisFrame;
			expCurrent += expThisFrame;
			SetEXPText(currentLevel,expCurrent,totalExpToLevel);
			yield return new WaitForFixedUpdate();
		}
	}

	void SetEXPText(float currentLevel,float expCurrent,float totalExpToLevel){
			expText.text = Math.Floor(expCurrent)+"/"+totalExpToLevel;
			expRaidal.fillAmount = expCurrent/totalExpToLevel;
			levelText.text =currentLevel.ToString();
	}
}
