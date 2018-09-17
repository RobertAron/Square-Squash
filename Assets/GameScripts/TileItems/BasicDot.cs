using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BasicDot : TileItem
{
  public DotPalette dotColor;

  private void Awake() {
    GameObject child = transform.GetChild(0).gameObject;
    child.GetComponent<Renderer>().material.color =  ColorSchema.GetColor(dotColor);
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
    Gizmos.color = ColorSchema.GetColor(dotColor);
    Gizmos.DrawWireSphere(position, transform.localScale.x / 2);
  }

  public override bool CanLinkPath(DotPalette originalColor,Vector2Int previousPosition)
  {
    if(originalColor!=dotColor) return false;
    if((previousPosition-tileSlot.tilePosition).magnitude>1) return false;
    return true;
  }

  public override bool CanStartPath()
  {
    return true;
  }
}