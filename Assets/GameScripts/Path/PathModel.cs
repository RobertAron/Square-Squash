using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathModel : MonoBehaviour
{
  [SerializeField]
  public List<TileSlot> path = new List<TileSlot>();
  private ColorPalette pathColor = ColorPalette.None;
  private SpecialActions specialActions;

  private void Start() {
    specialActions = SpecialActions.instance;
  }
  void AddToPath(TileSlot slot){
    path.Add(slot);
    slot.GetItem().EmphasizeItem();
    ResetPathColor();
  }
  public void SetInitialSlot(TileSlot initialSlot)
  {
    ColorPalette itemType = initialSlot.GetItemType();
    path.Clear();
    if (itemType == ColorPalette.None) return;
    AddToPath(initialSlot);
    pathColor = itemType;
    AndroidVibrate.Vibrate(40);
  }

  void ResetPathColor(){
    pathColor = ColorPalette.All;
    foreach(TileSlot ts in path){
      if(ts.GetItemType()!=ColorPalette.All){
        pathColor = ts.GetItemType();
        break;
      }
    }
  }
  public void AttemptAddPath(TileSlot newTile)
  {
    ResetPathColor();
    // Don't add to empty path
    if (path.Count == 0) return;
    // No doubling back
    if (path.Count > 1 && path[path.Count - 2] == newTile) return;
    
    ColorPalette itemType = newTile.GetItemType();
    TileSlot lastSlot = path[path.Count - 1];
    // Item must be the same color as the path, or must be 'all'
    if (itemType != ColorPalette.All && (itemType != pathColor && pathColor!= ColorPalette.All)) return;
    // If last item, remove last item
    if (lastSlot == newTile && path.Count > 1)
    {
      path.RemoveAt(path.Count - 1);
      ResetPathColor();
      AndroidVibrate.Vibrate(40);
      return;
    }

    // Don't add more items on loop
    if (ContainsLoop()) return;
    // Check if the new tile is adjacent our current one.
    if (!lastSlot.adjacentTiles.Contains(newTile)) return;
    AddToPath(newTile);
    if(ContainsLoop()) {
      specialActions.EmphasizeColor(pathColor);
      AndroidVibrate.Vibrate(new long []{0,40,20,40},-1);
    }
    // if(ContainsLoop()) AndroidVibrate.Vibrate(70);
    else AndroidVibrate.Vibrate(30);
  }
  public void PathReset()
  {
    pathColor = ColorPalette.None;
    path.Clear();
  }
  public void ClearPathItems()
  {
    List<TileItem> itemsToRemove = new List<TileItem>();
    foreach (TileSlot slot in path)
    {
      itemsToRemove.Add(slot.GetItem());
    }
    foreach (TileItem item in itemsToRemove)
    {
      item.ClearItem();
    }
  }

  public List<Vector3> GetPathLocations()
  {
    List<Vector3> pathLocationList = new List<Vector3>();
    foreach (TileSlot slot in path)
    {
      pathLocationList.Add(slot.transform.position);
    }
    return pathLocationList;
  }
  public ColorPalette GetPathColor()
  {
    return pathColor;
  }

  public bool ContainsLongPath()
  {
    if (path.Count > 1) return true;
    return false;
  }

  public bool ContainsLoop()
  {
    if(path.Count<2) return false;
    TileSlot lastSlot = path[path.Count - 1];
    List<TileSlot> butLast = new List<TileSlot>(path);
    butLast.RemoveAt(butLast.Count - 1);
    return butLast.Contains(lastSlot);
  }
}
