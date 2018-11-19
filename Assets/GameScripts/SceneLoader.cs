using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	public Object sceneToLoad;
	public void ChangeChangeScene(){
		SceneManager.LoadScene(sceneToLoad.name);
	}
}
