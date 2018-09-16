using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class TileSlot : MonoBehaviour {
	public AdjacentTiles adjacentTiles;
	// Public for editor reasons, but should not be manually changed.
	public TileItem _tileItem;
	private void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position,transform.localScale);
		if(_tileItem!=null)
			_tileItem.DrawItemGizmo(transform.position);
	}

	private void Awake() {
		if(_tileItem!=null){
			GameObject initialItem =  Instantiate(_tileItem.gameObject,transform.position,transform.rotation);
			TileItem initialTileItem = initialItem.GetComponent<TileItem>();
			_tileItem = initialTileItem;
			_tileItem.tileSlot = this;
		}
		else
			throw new System.Exception("Item slot is missing item on Awake.");
	}

	private void SetNewItem(TileItem newItem){
		_tileItem = newItem;
		newItem.tileSlot = this;
	}
	public void RemoveTileItem(){
		TileItem newItem = adjacentTiles.above.GetItem();
		SetNewItem(newItem);
	}
	public TileItem GetItem(){
		return _tileItem.GetItem();
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