using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileItem : MonoBehaviour {
	public abstract TileItem GetItem();
	public abstract void OnDestroy();
	public abstract bool canLink(TileItem originalItem);
	public abstract void OnDrawGizmos();
}
