using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemGenerator : TileItem
{
  public TileItem[] possibleItems;

  public override bool canLink(TileItem originalItem)
  {
    throw new System.NotImplementedException();
  }

  public override void DrawItemGizmo(Vector3 position)
  {
      Gizmos.color = Color.black;
    Gizmos.DrawCube(position, transform.localScale);
  }

  public override TileItem GetItem()
  {
    TileItem itemType = possibleItems[Random.Range(0, possibleItems.Length)];
    GameObject newItem = Instantiate(itemType.gameObject,transform.position,transform.rotation);
    return newItem.GetComponent<TileItem>();
  }

  public override void OnClearItem()
  {
    // Do nothing
  }
}
