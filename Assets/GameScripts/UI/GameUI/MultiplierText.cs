using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text),typeof(SpringyMove))]
public class MultiplierText : MonoBehaviour {
	Text text;
	Coroutine currentCoroutine;
	SpringyMove springyMove;
	public RectTransform parentRect;

	private void Start() {
		text = GetComponent<Text>();
		springyMove = GetComponent<SpringyMove>();
		
	}

	[ContextMenu("Test Move")]
	void TestEmphasis(){
		SetMultiplierText(2);
	}

	public void SetMultiplierText(int multiplierNum){
		text.text = multiplierNum + "x";
		if(currentCoroutine!=null){
      StopCoroutine(currentCoroutine);
    }
    currentCoroutine = StartCoroutine(emphasizeMult());
	}

	IEnumerator emphasizeMult(){
		Vector3 startPos = transform.position;
		Vector3 centerPoint = parentRect.localPosition;
		Vector3 topPoint = new Vector3(centerPoint.x,centerPoint.y+10f,transform.position.z);
		transform.position = topPoint;
		springyMove.StartMove(centerPoint);
		yield return new WaitForSeconds(1f);
		springyMove.StartMove(startPos);
	}
}
