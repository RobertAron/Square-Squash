using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDot : TileItem {
	public Color dotColor;

  public override bool canLink(TileItem originalItem)
  {
    throw new System.NotImplementedException();
  }

  public override TileItem GetItem()
  {
    throw new System.NotImplementedException();
  }

  public override void OnDestroy()
  {
    throw new System.NotImplementedException();
  }

  public override void OnDrawGizmos()
  {
		Debug.Log(dotColor);
		Gizmos.color = dotColor;
    Gizmos.DrawWireSphere(transform.position,transform.localScale.x/2);
  }
}
