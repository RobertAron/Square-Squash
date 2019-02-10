using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpringyMove))]
public class SpringOnEnabled : MonoBehaviour {

	SpringyMove springyMove;
	private void Awake() {
		springyMove = GetComponent<SpringyMove>();
	}
	private void OnEnable() {
		Vector3 getTo = transform.position;
		transform.position = new Vector3(transform.position.x,10,transform.position.z);
		springyMove.StartMove(getTo);
	}
}
