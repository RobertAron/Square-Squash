using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpAnimator : MonoBehaviour {
	[SerializeField] Text levelText;
	[SerializeField] Image expRaidal;
	[SerializeField] Text expText;
	// Use this for initialization
	public void LevelUpAnimation(int startingLevel,int startingExp,int expGained){
		StartCoroutine(LevelUpAnimationCoroutine(startingLevel,startingExp,expGained));
	}

	IEnumerator LevelUpAnimationCoroutine(int startingLevel,int startingExp,int expGained){
		int expRemaining = expGained;
		int expCurrent = startingExp;
		int currentLevel = startingLevel;
		int totalExpToLevel = StaticCalcs.experienceToLevel(startingLevel);
		int diffPerFrame = expGained/60;
		while(expRemaining>0){
			int expTillLevelUp = totalExpToLevel-expCurrent;
			int expThisFrame = Mathf.Min(expTillLevelUp,diffPerFrame,expRemaining);
			expRemaining -= expThisFrame;
			expCurrent += expThisFrame;

			levelText.text = currentLevel.ToString();
			expText.text = expCurrent+"/"+totalExpToLevel;
			expRaidal.fillAmount = (float)expCurrent/(float)totalExpToLevel;
			yield return new WaitForFixedUpdate(); 
		}
	}
}
