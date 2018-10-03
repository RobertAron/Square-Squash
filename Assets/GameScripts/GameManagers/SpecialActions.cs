using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialActions : MonoBehaviour {

	#region  Singleton
  public static SpecialActions instance;
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
  }

  #endregion
	
	public GameObject slotsParent;
	public TimeTracker timeTracker;
	private TileSlot[] tileSlots;
	private ItemGeneratorController itemGenerator;

	void Start () {
		tileSlots = slotsParent.GetComponentsInChildren<TileSlot>();
		itemGenerator = ItemGeneratorController.instance;
		timeTracker = TimeTracker.instance;
	}

	public void ClearAllColor(ColorPalette color){
		timeTracker.IncreaseRemainingTime(1.0f);
		itemGenerator.PreventColorSpawn(color);
		List<TileItem> tileItems = new List<TileItem>();
		foreach(TileSlot tileSlot in tileSlots){
			TileItem item = tileSlot.GetItem();
			if(item.itemColor==color) tileItems.Add(item);
		}
		foreach(TileItem item in tileItems){
			item.ClearItem();
		}
		
	}
}
