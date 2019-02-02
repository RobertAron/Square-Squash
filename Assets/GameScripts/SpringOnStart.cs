using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpringyMove))]
public class SpringOnStart : MonoBehaviour {

	SpringyMove springyMove;
	private void Awake() {
		springyMove = GetComponent<SpringyMove>();
	}

  void Start()
  {
		var rectTransform = transform.parent.GetComponent<RectTransform>();
		Vector3 getTo = transform.position;
		transform.position = new Vector3(transform.position.x,transform.position.y+rectTransform.sizeDelta.y/1.5f,transform.position.z);
		springyMove.startMove(getTo); 
  }
}
