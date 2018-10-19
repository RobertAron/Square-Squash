using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneLoader : MonoBehaviour {

	public string otherSceneName;
	public void ChangeChangeScene(){
		SceneManager.LoadScene(otherSceneName);
	}
}
