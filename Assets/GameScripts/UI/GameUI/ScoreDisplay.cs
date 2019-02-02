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
		if(currentCoroutine!=null){
      StopCoroutine(currentCoroutine);
    }
    currentCoroutine = StartCoroutine(UpdateAnimation((float)newScore));
	}

	public void HardSet(int newScore){
		SetScoreTet(newScore);
	}

	IEnumerator UpdateAnimation(float updateTo){
		speed = (updateTo-currentScore)*5;
		while(currentScore!=updateTo){
			currentScore = Mathf.MoveTowards(currentScore,updateTo,speed*Time.deltaTime);
			SetScoreTet((int)Mathf.Floor(currentScore));
			yield return null;
		}
	}

	void SetScoreTet(int scoreValue){
		textComonent.text = "Score: " + scoreValue;
	}
}
