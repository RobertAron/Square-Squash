using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PathModel))]
public class PathController : MonoBehaviour
{
  PathModel pathModel;
  TileSlot lastPressed = null;


  private void Start()
  {
    pathModel = GetComponent<PathModel>();
  }

  public void InitialPress(Vector3 pressLocation)
  {
    TileSlot tileSlot = RaycastForTileSlot(pressLocation);
    if(tileSlot==null) return;
    lastPressed = tileSlot;
    pathModel.SetInitialSlot(tileSlot);
  }
  public void OnHeld(Vector3 pressLocation)
  {
    TileSlot tileSlot = RaycastForTileSlot(pressLocation);
    if(lastPressed==tileSlot) return;
    lastPressed = tileSlot;
    if(tileSlot==null) return;
    Debug.Log("attemp called");
    pathModel.AttemptAddPath(tileSlot);
  }
  public void OnRelease()
  {
    pathModel.PathRelease();
  }

  private TileSlot RaycastForTileSlot(Vector3 location)
  {
    RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(location);
    Physics.Raycast(ray, out hit, 100.0f);
    if(hit.transform==null) return null;
    return hit.transform.GetComponent<TileSlot>();
  }
}
