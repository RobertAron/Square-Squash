using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileItem : MonoBehaviour
{
  public TileSlot tileSlot;
  public abstract TileItem GetItem();
  public abstract void OnClearItem();
  public abstract bool canLink(TileItem originalItem);
  public abstract void DrawItemGizmo(Vector3 position);

  private void FixedUpdate()
  {
    transform.position = Vector3.MoveTowards(transform.position, tileSlot.transform.position, Time.fixedDeltaTime);
  }
}
