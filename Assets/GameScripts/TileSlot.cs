using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileSlot : MonoBehaviour
{
  public AdjacentTiles adjacentTiles;
  // Public for editor reasons, but should not be manually changed.
  [SerializeField]
  private TileItem tileItem;
  
	private void OnDrawGizmos()
  {
    Gizmos.DrawWireCube(transform.position, transform.localScale);
    if (tileItem != null)
      tileItem.DrawItemGizmo(transform.position);
  }

  private void Awake()
  {
    if (tileItem != null)
    {
      GameObject initialItem = Instantiate(tileItem.gameObject, transform.position, transform.rotation);
      TileItem initialTileItem = initialItem.GetComponent<TileItem>();
      tileItem = initialTileItem;
      tileItem.tileSlot = this;
    }
    else
      throw new System.Exception("Item slot is missing item on Awake.");
  }

  private void SetNewItem(TileItem newItem)
  {
    tileItem = newItem;
    newItem.tileSlot = this;
  }
  
	public void ObtainNewTileItem()
  {
    TileItem newItem = adjacentTiles.above.GetItemFromSlot();
    SetNewItem(newItem);
  }
  
	public TileItem GetItemFromSlot()
  {
    return tileItem.GetItemFromItem();
  }
  
	public DotPalette GetItemType()
  {
    return tileItem.dotColor;
  }

	public void ClearTileItem(){
		tileItem.OnClearItem();
	}
}

[System.Serializable]
public class AdjacentTiles
{
  public TileSlot left;
  public TileSlot right;
  public TileSlot above;
  public TileSlot below;
  public bool Contains(TileSlot testTile)
  {
    bool leftB = testTile.Equals(left);
    bool rightB = testTile.Equals(right);
    bool aboveB = testTile.Equals(above);
    bool belowB = testTile.Equals(below);
    return leftB | rightB | aboveB | belowB;
  }
}