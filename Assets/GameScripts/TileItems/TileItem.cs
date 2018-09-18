using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileItem : MonoBehaviour
{
  public DotPalette dotColor;
  public TileSlot tileSlot;
  public abstract TileItem GetItemFromItem();
  public abstract void OnClearItem();
  public abstract void DrawItemGizmo(Vector3 position);

  private void FixedUpdate()
  {
    transform.position = Vector3.MoveTowards(transform.position, tileSlot.transform.position, Time.fixedDeltaTime*5);
  }
}
