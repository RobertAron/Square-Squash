using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePopulator : MonoBehaviour {

	[SerializeField] ScoreCard scoreCard;

	public void AddNewScore(int placement,string playerName,int score){
		GameObject returnedObject = Instantiate(scoreCard.gameObject,transform);
		returnedObject.GetComponent<ScoreCard>().SetText(placement,playerName,score);
	}
}
