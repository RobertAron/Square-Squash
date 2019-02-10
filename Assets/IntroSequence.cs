using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSequence : MonoBehaviour {
	// Use this for initialization
	public float transitionTime = 0.5f;
	[SerializeField] SceneTransition st;
	void Start () {
		StartCoroutine(IntroSequenceCoroutine());
	}
	IEnumerator IntroSequenceCoroutine(){
		MetaGameStateController mgsc = MetaGameStateController.instance;
		if(mgsc!=null){
			mgsc.HardSetPause(true);
		}
		st.TransitionIn(transitionTime);
		yield return new WaitForSeconds(transitionTime);
		if(mgsc!=null){
			mgsc.HardSetPause(false);
		}
	}
}
