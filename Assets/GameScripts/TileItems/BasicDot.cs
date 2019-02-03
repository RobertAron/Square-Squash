using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpringyMove))]
public class BasicDot : TileItem
{
  float acceleration = 20f;
  private PointSystem pointSystem;
  private SpringyMove springyMove;
  private ParticleSystem[] ps;

  private void Awake() {
    ps = GetComponentsInChildren<ParticleSystem>();
    springyMove = GetComponent<SpringyMove>();
    Color color = ColorSchema.GetColor(itemColor);
    GameObject child = transform.GetChild(0).gameObject;
    child.GetComponent<Renderer>().material.color =  color;
    
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
    if(pointSystem!=null) pointSystem.AddPoint();
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
    springyMove.StartMove(tileSlot.transform.position);
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

  [ContextMenu("emphsize item")]
  public override void EmphasizeItem()
  {
    for(int i=0;i<ps.Length;i++){
      ps[i].Emit(1);
    }
  }

  [ContextMenu("set particle coloring")]
  public void SetParticleColor(){
    ps = GetComponentsInChildren<ParticleSystem>();
    GameObject child = transform.GetChild(0).gameObject;
    Color color = ColorSchema.GetColor(itemColor);
    var col = ps[0].colorOverLifetime;
    Gradient grad = new Gradient();
    grad.SetKeys(new GradientColorKey[] { new GradientColorKey(color, 0.0f), new GradientColorKey(color, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.0f), new GradientAlphaKey(1.0f, 0.1f),new GradientAlphaKey(1.0f, 0.7f), new GradientAlphaKey(0.0f, 1.0f) } );
    col.color = grad;
  }
}