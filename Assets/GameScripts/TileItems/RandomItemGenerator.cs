using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemGenerator : TileItem
{
  public TileItem[] possibleItems;
  private int dotsSpawned = 0;

  public override bool CanLinkPath(DotPalette originalColor,Vector2Int previousPosition)
  {
    return false;
  }

  public override bool CanStartPath()
  {
    return false;
  }

  public override void DrawItemGizmo(Vector3 position)
  {
      Gizmos.color = Color.black;
    Gizmos.DrawCube(position, transform.localScale);
  }

  public override TileItem GetItem()
  {
    Vector3 dotSpawnLocation = transform.position;
    dotSpawnLocation.y += (dotsSpawned * transform.localScale.x);
    dotsSpawned++;
    TileItem itemType = possibleItems[Random.Range(0, possibleItems.Length)];
    GameObject newItem = Instantiate(itemType.gameObject,dotSpawnLocation,transform.rotation);
    return newItem.GetComponent<TileItem>();
  }

  public override void OnClearItem()
  {
    // Do nothing
  }
  private void FixedUpdate() {
    dotsSpawned = 0;
  }
}
