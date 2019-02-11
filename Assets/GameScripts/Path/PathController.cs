using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PathModel))]
public class PathController : MonoBehaviour
{
  PathModel pathModel;
  TileSlot lastHoverHeld = null;
  SpecialActions specialActions;


  private void Start()
  {
    pathModel = GetComponent<PathModel>();
    specialActions = SpecialActions.instance;
  }

  public void InitialPress(Vector3 pressLocation)
  {
    TileSlot tileSlot = RaycastForTileSlot(pressLocation);
    if(tileSlot==null || tileSlot.GetItemType() == ColorPalette.None) return;
    lastHoverHeld = tileSlot;
    pathModel.SetInitialSlot(tileSlot);
  }
  public void OnHeld(Vector3 pressLocation)
  {
    TileSlot tileSlot = RaycastForTileSlot(pressLocation);
    if(lastHoverHeld==tileSlot) return;
    lastHoverHeld = tileSlot;
    if(tileSlot==null) return;
    pathModel.AttemptAddPath(tileSlot);
  }
  public void OnRelease()
  {
    if(pathModel.ContainsLoop()){
			specialActions.ClearAllColor(pathModel.GetPathColor());
      specialActions.ClearAllColor(ColorPalette.All);
    }
    else if (pathModel.ContainsLongPath())
			pathModel.ClearPathItems();
    pathModel.PathReset();
  }
  private TileSlot RaycastForTileSlot(Vector3 location)
  {
    RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(location);
    Physics.Raycast(ray, out hit, 200.0f);
    if(hit.transform==null) return null;
    return hit.transform.GetComponent<TileSlot>();
  }
}
