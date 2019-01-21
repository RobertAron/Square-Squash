using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpringyMove))]
public class SpringOnStart : MonoBehaviour {
	[SerializeField]
	float offsetX=0,offsetY=0,offsetZ=0;

	SpringyMove springyMove;
	private void Awake() {
		springyMove = GetComponent<SpringyMove>();
	}

  void Start()
  {
		Vector3 getTo = transform.position;
		transform.position = new Vector3(transform.position.x+offsetX,transform.position.y+offsetY,transform.position.z+offsetZ);
		springyMove.startMove(getTo); 
  }
}
