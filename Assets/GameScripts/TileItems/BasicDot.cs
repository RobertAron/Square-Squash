using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDot : TileItem
{
  public Color dotColor;

  public override bool canLink(TileItem originalItem)
  {
    throw new System.NotImplementedException();
  }

  public override TileItem GetItem()
  {
    tileSlot.RemoveTileItem();
    return this;
  }

	[ContextMenu("Force clear dot")]
  public override void OnClearItem()
  {
    tileSlot.RemoveTileItem();
		Destroy(this.gameObject);
  }

  public override void DrawItemGizmo(Vector3 position)
  {
    Gizmos.color = dotColor;
    Gizmos.DrawWireSphere(position, transform.localScale.x / 2);
  }
}
