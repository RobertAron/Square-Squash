using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPath : MonoBehaviour
{

  private List<TileItem> path = new List<TileItem>();
  private BasicDot initialDot;

  public void initialPress(Vector3 pressLocation)
  {
    RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(pressLocation);
    if (Physics.Raycast(ray, out hit, 100.0f))
    {
      initialDot = hit.transform.GetComponent<BasicDot>();
      if (initialDot != null)
      {
        path.Add(initialDot);
      }
    }
  }
  public void OnHeld(Vector3 pressLocation){
    if(path.Count==0) return;
    RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(pressLocation);
    if (Physics.Raycast(ray, out hit, 100.0f))
    {
      TileItem newItem = hit.transform.GetComponent<TileItem>();
      if(newItem==null) return;
      if(path.Contains(newItem)) return;
      DotPalette intialType = initialDot.dotColor;
      Vector2Int lastPosition = path[path.Count-1].tileSlot.tilePosition;
      if(newItem.CanLinkPath(intialType,lastPosition)){
        path.Add(newItem);
      }
    }
  }
  public void OnRelease()
  {
    if (path.Count > 1)
    {
      foreach (TileItem item in path)
      {
        item.OnClearItem();
      }
    }
    path.Clear();
    initialDot = null;
  }
}
