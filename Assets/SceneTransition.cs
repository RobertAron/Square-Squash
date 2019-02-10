using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
  float maxScale = 3;
  public void TransitionOut(float time)
  {
    StartCoroutine(TransitionOutCoroutine(time));
  }

  IEnumerator TransitionOutCoroutine(float timeTillDone)
  {
    float currentScale = 0;
		transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    yield return new WaitForSeconds(timeTillDone * .1f);
    float updatePerDelta = maxScale / timeTillDone * .9f * Time.deltaTime;
    while (currentScale < maxScale)
    {
      currentScale += updatePerDelta;
      transform.Rotate(Vector3.forward * 100 * Time.deltaTime);
      transform.localScale = new Vector3(currentScale, currentScale, currentScale);
      yield return null;
    }
  }
  public void TransitionIn(float time)
  {
    StartCoroutine(TransitionInCoroutine(time));
  }

  IEnumerator TransitionInCoroutine(float timeTillDone)
  {
    float currentScale = maxScale;
		transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    yield return new WaitForSeconds(timeTillDone * .1f);
    float updatePerDelta = maxScale / timeTillDone * .9f * Time.deltaTime;
    while (currentScale > 0)
    {
      currentScale -= updatePerDelta;
      transform.Rotate(Vector3.forward * -100 * Time.deltaTime);
      transform.localScale = new Vector3(currentScale, currentScale, currentScale);
      yield return null;
    }
    transform.localScale = new Vector3(0, 0, 0);
  }

}
