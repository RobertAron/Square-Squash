using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text),typeof(SpringyMove))]
public class MultiplierText : MonoBehaviour {
	Text text;
	Vector3 startPos;
	Vector3 topPoint;
	Vector3 centerPoint;
	Coroutine currentCoroutine;
	SpringyMove springyMove;
	public RectTransform parentRect;

	private void Start() {
		text = GetComponent<Text>();
		springyMove = GetComponent<SpringyMove>();
		float width = Screen.width;
		float height = Screen.height;
		startPos = transform.position;
		topPoint = new Vector3(width/2,height*1.25f,transform.position.z);
		centerPoint = new Vector3(width/2,height/2,transform.position.z);
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
		transform.position = topPoint;
		springyMove.StartMove(centerPoint);
		yield return new WaitForSeconds(1f);
		springyMove.StartMove(startPos);
	}
}
