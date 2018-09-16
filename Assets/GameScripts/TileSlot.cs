using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class TileSlot : MonoBehaviour {
	public AdjacentTiles adjacentTiles;
	public TileItem tileItem;
	private void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position,transform.localScale);
		if(tileItem!=null)
			tileItem.OnDrawGizmos();
	}


}

[System.Serializable]
public class AdjacentTiles
{
  public TileSlot left;
	public TileSlot right;
	public TileSlot above;
	public TileSlot bellow;
}