using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileItem : MonoBehaviour
{
  public DotPalette dotColor;
  protected TileSlot tileSlot;
  public abstract TileItem GetItemFromItem();
  public abstract void OnClearItem();
  public abstract void DrawItemGizmo(Vector3 position);
  
  
  public virtual void SetTileSlot(TileSlot tileSlot){
    this.tileSlot = tileSlot;
  }
}
