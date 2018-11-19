using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class RadialController : MonoBehaviour {

	float initialTime = 0;
	Image radialImage;
	
	private void Awake() {
		radialImage = GetComponent<Image>();
	}


	public void SetTimeRemaining(float remainingTime)
	{
		if(initialTime==0) initialTime = remainingTime;
		radialImage.fillAmount = remainingTime/initialTime;
	}
	public void Initialize(Color color)
	{
		radialImage.color = color;
	}
}
