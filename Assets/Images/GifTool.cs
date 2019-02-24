using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class GifTool : MonoBehaviour {
	Image image;
	[SerializeField] Sprite[] frames;
	[SerializeField] float framesPerSecond;
	float time;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		int index = (int) Mathf.Floor(time*framesPerSecond);
		index = index % frames.Length;
		image.sprite = frames[index];
	}
}
