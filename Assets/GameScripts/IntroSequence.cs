using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSequence : MonoBehaviour {
	// Use this for initialization
	public float transitionTime = 0.9f;
	[SerializeField] SceneTransition st;
	[SerializeField] GameObject[] countDownObjects;
	void Start () {
		StartCoroutine(IntroSequenceCoroutine());
	}
	IEnumerator IntroSequenceCoroutine(){
		MetaGameStateController mgsc = MetaGameStateController.instance;
		if(mgsc!=null){
			mgsc.HardSetPause(true);
		}
		st.TransitionIn(transitionTime);
		yield return new WaitForSeconds(transitionTime*0.8f);
		if(countDownObjects!=null && countDownObjects.Length!=0){
			for(int i=0;i<countDownObjects.Length;i++){
				countDownObjects[i].SetActive(true);
				yield return new WaitForSeconds(0.3f);
			}
			yield return new WaitForSeconds(0.4f);
			for(int i=0;i<countDownObjects.Length;i++){
				countDownObjects[i].SetActive(false);
			}
		}
		if(mgsc!=null){
			mgsc.SetPauseState(false);
		}
	}
}
