using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BasicDot : TileItem
{
  public float acceleration = 2f;
  private Coroutine currentCoroutine;
  public bool wtf = false;

  private void Awake() {
    GameObject child = transform.GetChild(0).gameObject;
    child.GetComponent<Renderer>().material.color =  ColorSchema.GetColor(dotColor);
  }

  public override TileItem GetItemFromItem()
  {
    tileSlot.ObtainNewTileItem();
    return this;
  }

  public override void OnClearItem()
  {
    tileSlot.ObtainNewTileItem();
		Destroy(this.gameObject);
  }

  public override void DrawItemGizmo(Vector3 position)
  {
    Gizmos.color = ColorSchema.GetColor(dotColor);
    Gizmos.DrawWireSphere(position, transform.localScale.x / 2);
  }

  public override void SetTileSlot(TileSlot tileSlot){
    base.SetTileSlot(tileSlot);
    if(currentCoroutine!=null){
      StopCoroutine(currentCoroutine);
    }
    currentCoroutine = StartCoroutine(MoveToNewSlot(tileSlot));
  }

  IEnumerator MoveToNewSlot(TileSlot tileSlot){
    Vector3 targetLocation = tileSlot.transform.position;
    float timeSinceInitial = 0f;
    while(Vector3.Distance(transform.position,targetLocation)>Mathf.Epsilon){
      timeSinceInitial+= Time.fixedDeltaTime;
      float distance = acceleration * timeSinceInitial * Time.fixedDeltaTime;
      transform.position = Vector3.MoveTowards(transform.position,targetLocation,distance);
      yield return new WaitForFixedUpdate();
    }
    transform.position = targetLocation;
  }
}