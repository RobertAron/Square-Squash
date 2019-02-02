using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileItem : MonoBehaviour
{
  public ColorPalette itemColor;
  protected TileSlot tileSlot;
  public abstract TileItem GetItemFromItem();
  public abstract void ClearItem();
  public abstract void DrawItemGizmo(Vector3 position);
  public abstract void EmphasizeItem();
  
  
  public virtual void SetTileSlot(TileSlot tileSlot){
    this.tileSlot = tileSlot;
  }
}
