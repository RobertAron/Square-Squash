using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpringyMove))]
public class BasicDot : TileItem
{
  float acceleration = 20f;
  private PointSystem pointSystem;
  private SpringyMove springyMove;

  private void Awake() {
    GameObject child = transform.GetChild(0).gameObject;
    child.GetComponent<Renderer>().material.color =  ColorSchema.GetColor(itemColor);
    springyMove = GetComponent<SpringyMove>();
  }
  private void Start() {
    pointSystem = PointSystem.instance;
  }

  public override TileItem GetItemFromItem()
  {
    tileSlot.ObtainNewTileItem();
    return this;
  }

  public override void ClearItem()
  {
    pointSystem.AddPoint();
    Debug.Log(tileSlot);
    tileSlot.ObtainNewTileItem();
		Destroy(this.gameObject);
  }

  public override void DrawItemGizmo(Vector3 position)
  {
    Gizmos.color = ColorSchema.GetColor(itemColor);
    MeshFilter mf = GetComponentInChildren<MeshFilter>();
    Gizmos.DrawMesh(mf.sharedMesh,position,mf.transform.rotation,mf.transform.lossyScale);
  }

  public override void SetTileSlot(TileSlot tileSlot){
    base.SetTileSlot(tileSlot);
    springyMove.startMove(tileSlot.transform.position);
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