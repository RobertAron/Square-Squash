using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {

	Button button;
	public Image pauseButton;
	public Image playButton;
	private void Awake() {
		button = GetComponent<Button>();
	}
	public void SetInteractable(bool interactableStatus){
		button.interactable = interactableStatus;
	}

	public void SetImagePause(bool pauseImage){
		pauseButton.transform.gameObject.SetActive(pauseImage);
		playButton.transform.gameObject.SetActive(!pauseImage);
	}

}
