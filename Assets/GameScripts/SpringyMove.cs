using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringyMove : MonoBehaviour
{
	[SerializeField]
	float acceleration = 1;
  [SerializeField]
  int bounceAmount = 1;
  float currentSpeed = 0;
  private Coroutine currentCoroutine;

  public void StartMove(Vector3 finalPosition){
    if(currentCoroutine!=null){
      StopCoroutine(currentCoroutine);
    }
    currentCoroutine = StartCoroutine(MoveTo(finalPosition));
  }

	IEnumerator MoveTo(Vector3 finalPosition){
    Vector3 startPostion = transform.position;
    int bouncesLeft = bounceAmount;
		while(bouncesLeft>=0){
      currentSpeed += acceleration * Time.fixedDeltaTime;
			transform.position = Vector3.MoveTowards(transform.position,finalPosition,currentSpeed);
      if(transform.position.Equals(finalPosition)){
        currentSpeed /= 6;
        transform.position = Vector3.MoveTowards(transform.position,startPostion,currentSpeed);
        bouncesLeft-=1;
        currentSpeed *= -1;
      }
			yield return new WaitForFixedUpdate();
		}
    transform.position = finalPosition;
	}
}
