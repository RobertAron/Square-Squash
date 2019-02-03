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
		transform.position = new Vector3(transform.position.x,Screen.height,Screen.width);
		springyMove.StartMove(getTo); 
  }
}
