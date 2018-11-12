using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class MultiplierRadial : MonoBehaviour {
	Image radialImage;
	private void Awake() {
		radialImage = GetComponent<Image>();
	}

	public void SetFillAmount(float fillAmount){
		radialImage.fillAmount = fillAmount;
	}
}
