using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGeneratorController : MonoBehaviour
{

  #region  Singleton
  public static ItemGeneratorController instance;
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
  }

  #endregion

  public TileItem[] possibleItems;
  
  [SerializeField]
  private List<ColorPalette> availableColors = new List<ColorPalette>();

  private void Start() {
    ResetAvailableColors();
  }

  public TileItem GetNewItem()
  {
    // TODO: fix this behemouth
    if(availableColors.Count==0){
      Debug.Log("this shouldn't happen.... the todo needs to be done");
      return possibleItems[0];
    }
    while(true){
      TileItem attemptItem = possibleItems[Random.Range(0, possibleItems.Length)];
      if(availableColors.Contains(attemptItem.itemColor)){
        return attemptItem;
      }
    }
  }

  public void PreventColorSpawn(ColorPalette color)
  {
    availableColors.Remove(color);
    if(availableColors.Count==0){
      ResetAvailableColors();
    }
  }
  private void ResetAvailableColors(){
    availableColors.Clear();
    foreach(TileItem item in possibleItems){
      availableColors.Add(item.itemColor);
    }
  }
}
