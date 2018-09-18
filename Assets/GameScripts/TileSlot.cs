using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileSlot : MonoBehaviour
{
  public AdjacentTiles adjacentTiles;
  // Public for editor reasons, but should not be manually changed.
  [SerializeField]
  private TileItem _tileItem;
  
	private void OnDrawGizmos()
  {
    Gizmos.DrawWireCube(transform.position, transform.localScale);
    if (_tileItem != null)
      _tileItem.DrawItemGizmo(transform.position);
  }

  private void Awake()
  {
    if (_tileItem != null)
    {
      GameObject initialItem = Instantiate(_tileItem.gameObject, transform.position, transform.rotation);
      TileItem initialTileItem = initialItem.GetComponent<TileItem>();
      _tileItem = initialTileItem;
      _tileItem.tileSlot = this;
    }
    else
      throw new System.Exception("Item slot is missing item on Awake.");
  }

  private void SetNewItem(TileItem newItem)
  {
    _tileItem = newItem;
    newItem.tileSlot = this;
  }
  
	public void ObtainNewTileItem()
  {
    TileItem newItem = adjacentTiles.above.GetItemFromSlot();
    SetNewItem(newItem);
  }
  
	public TileItem GetItemFromSlot()
  {
    return _tileItem.GetItemFromItem();
  }
  
	public DotPalette GetItemType()
  {
    return _tileItem.dotColor;
  }

	public void ClearTileItem(){
		_tileItem.OnClearItem();
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