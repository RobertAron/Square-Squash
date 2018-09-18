using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathModel : MonoBehaviour
{

  private List<TileSlot> path = new List<TileSlot>();
  private DotPalette pathColor = DotPalette.None;

  public void SetInitialSlot(TileSlot initialSlot)
  {
		DotPalette itemType = initialSlot.GetItemType();
		path.Clear();
		if(itemType==DotPalette.None) return;
		path.Add(initialSlot);
		pathColor = itemType;
  }
	public void AttemptAddPath(TileSlot newTile)
	{
		DotPalette itemType = newTile.GetItemType();
		TileSlot lastSlot = path[path.Count-1];
		if(lastSlot==newTile) return;
		if(path.Count == 0) return;
		if(itemType!=DotPalette.All&&itemType!=pathColor) return;
		if(!lastSlot.adjacentTiles.Contains(newTile)) return;
		path.Add(newTile);
	}
	public void PathRelease()
	{
		// TODO: add logic for full square
		pathColor = DotPalette.None;
		foreach(TileSlot slot in path){
			slot.ClearTileItem();
		}
		path.Clear();
	}

  public List<Vector3> GetPathLocations()
  {
    List<Vector3> pathLocationList = new List<Vector3>();
    foreach(TileSlot slot in path){
			pathLocationList.Add(slot.transform.position);
		}
    return pathLocationList;
  }
	public DotPalette GetPathColor(){
		return pathColor;
	}
}
