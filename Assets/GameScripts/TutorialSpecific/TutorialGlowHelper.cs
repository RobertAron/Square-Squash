using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class TutorialGlowHelper : MonoBehaviour {
	[SerializeField] float playAt;
	[SerializeField] float loopTime;
	float countedTime;
	ParticleSystem ps;
	// Use this for initialization
	private void Awake() {
		countedTime = loopTime - playAt;
		ps = GetComponent<ParticleSystem>();
	}
	private void FixedUpdate() {
		countedTime+=Time.fixedDeltaTime;
		if(countedTime>=loopTime){
			countedTime-=loopTime;
			ps.Stop();
			ps.Clear();
			ps.Play();
		}
	}
}
