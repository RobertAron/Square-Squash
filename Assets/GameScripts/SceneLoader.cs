using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	[SerializeField] SceneTransition sceneTransition;
	[SerializeField] float timeTillChange = .5f;
	public string sceneToLoad;

	private void Awake() {
		if(sceneTransition==null) throw new System.Exception("Scene Loader Missing Scene Transition");
	}

	public void ChangeChangeScene(){
		StartCoroutine(DelayedSceneChange());
	}

	IEnumerator DelayedSceneChange(){
		sceneTransition.TransitionOut(timeTillChange);
		yield return new WaitForSeconds(timeTillChange);
		SceneManager.LoadScene(sceneToLoad);
	}
}
