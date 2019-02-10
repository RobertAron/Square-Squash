using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreDisplay : MonoBehaviour {

	private Text textComonent;
	private Coroutine currentCoroutine;
	private float speed = 0;
	float currentScore = 0;
	private void Awake() {
		textComonent = GetComponent<Text>();
	}

	public void UpdateScore(int newScore){
		if(!this.isActiveAndEnabled) return;
		if(currentCoroutine!=null){
      StopCoroutine(currentCoroutine);
    }
    currentCoroutine = StartCoroutine(UpdateAnimation((float)newScore));
	}

	public void HardSet(int newScore){
		SetScoreText(newScore);
	}

	IEnumerator UpdateAnimation(float updateTo){
		speed = (updateTo-currentScore)*5;
		while(currentScore!=updateTo){
			currentScore = Mathf.MoveTowards(currentScore,updateTo,speed*Time.deltaTime);
			SetScoreText((int)Mathf.Floor(currentScore));
			yield return null;
		}
	}

	void SetScoreText(int scoreValue){
		if(!this.isActiveAndEnabled) return;
		textComonent.text = "Score: " + scoreValue;
	}
}
