using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoneItemGetter : TileItem
{
  
  int dotsSpawned = 0;
  ItemGeneratorController itemGenerator;

  public override void DrawItemGizmo(Vector3 position)
  {
    Gizmos.color = Color.black;
    Gizmos.DrawCube(position, transform.localScale);
  }

  public override TileItem GetItemFromItem()
  {
    Vector3 dotSpawnLocation = transform.position;
    dotSpawnLocation.y += (dotsSpawned * transform.localScale.x);
    dotsSpawned++;
    GameObject newItem = Instantiate(this.gameObject, dotSpawnLocation, transform.rotation);
    return newItem.GetComponent<TileItem>();
  }

  public override void ClearItem()
  {
    // Do nothing
  }

  private void FixedUpdate()
  {
    dotsSpawned = 0;
  }

  public override void EmphasizeItem()
  {
    // Item getters don't need to be emphaised
  }
}
