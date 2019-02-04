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
		Vector3 getTo = transform.position;
		RectTransform rt =  GetComponent<RectTransform>();
		transform.position = new Vector3(transform.position.x,10,transform.position.z);
		springyMove.StartMove(getTo); 
  }
}
