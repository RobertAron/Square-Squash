using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSlotGenerator : MonoBehaviour
{

  public TileAmount tileAmount;
  public GameObject tileSlotPrefab;

  [ContextMenu("Kill All Children")]
  public void KillChildren()
  {
    while (transform.childCount != 0)
    {
      DestroyImmediate(transform.GetChild(0).gameObject);
    }
  }


  [ContextMenu("Instantiate Tile Slots")]
  public void InstatiateTilesSlots()
  {
    TileSlot[,] tiles = CreateTileArray();
		LinkTileSlots(tiles);
  }

  private TileSlot[,] CreateTileArray()
  {
    TileSlot[,] tiles = new TileSlot[tileAmount.columns, tileAmount.rows];
    for (int x = 0; x < tileAmount.columns; x++)
    {
      for (int y = 0; y < tileAmount.rows; y++)
      {
        GameObject tileSlotGameObject = Instantiate(tileSlotPrefab, new Vector3(x, y, 0), Quaternion.identity, transform);
				tileSlotGameObject.name = "Tile Slot " + x + " " + y;
				tiles[x, y] = tileSlotGameObject.GetComponent<TileSlot>();
      }
    }
    return tiles;
  }
	private void LinkTileSlots(TileSlot[,] tileSlots){
		for (int x = 0; x < tileAmount.columns; x++)
    {
      for (int y = 0; y < tileAmount.rows; y++)
      {
				if(x>0)
					tileSlots[x,y].adjacentTiles.left = tileSlots[x-1,y];
				if(y>0)
					tileSlots[x,y].adjacentTiles.bellow = tileSlots[x,y-1];
				if(x<tileAmount.columns-1)
					tileSlots[x,y].adjacentTiles.right = tileSlots[x+1,y];
				if(y<tileAmount.rows-1)
					tileSlots[x,y].adjacentTiles.above = tileSlots[x,y+1];
			}
		}
	}
}


[System.Serializable]
public class TileAmount
{
  public int rows;
  public int columns;
}