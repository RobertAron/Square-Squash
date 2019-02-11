using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainboize : MonoBehaviour {
	Material material;
	float speed = 0.4f;
	float sawPosition;
	float sinPosition;
	int modBy;

	private void Start() {
		material = gameObject.GetComponent<Renderer>().material;
		modBy = (int) Mathf.Ceil(100/speed);
	}

	void Update () {
		UpdateSawPosition();
		material.color = Color.HSVToRGB(sawPosition,0.38f,1);
	}
	void UpdateSawPosition(){
		sawPosition = (Time.frameCount % modBy)/(float)modBy;
		if(sawPosition>=1) sawPosition -= 1;
	}
}
