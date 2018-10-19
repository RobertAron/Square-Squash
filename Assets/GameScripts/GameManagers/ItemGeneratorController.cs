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
  public float spawnTimeCooldown = 10;
  Dictionary<ColorPalette, float> colorCooldowns = new Dictionary<ColorPalette, float>();

  public TileItem GetNewItem()
  {
    // TODO: WHOOPS. The cooldowns should be on items....not colors.
    List<TileItem> currrentlyPossibleItems = new List<TileItem>(possibleItems);
    List<TileItem> currrentlyPossibleItems2 = new List<TileItem>(possibleItems);
    if(colorCooldowns.Count==currrentlyPossibleItems.Count){
      // TODO Bonus points here?
      colorCooldowns.Clear();
    }
    List<ColorPalette> colorCooldownColors = new List<ColorPalette>(colorCooldowns.Keys);
    foreach(ColorPalette color in colorCooldownColors)
    {
      foreach(TileItem item in currrentlyPossibleItems2)
      {
        if(item.itemColor == color) currrentlyPossibleItems.Remove(item);
      }
    }
    TileItem returnItem;
    if(currrentlyPossibleItems.Count <1) returnItem = possibleItems[Random.Range(0, possibleItems.Length)];
    else returnItem = currrentlyPossibleItems[Random.Range(0, currrentlyPossibleItems.Count)];
    return returnItem;
  }

  private void FixedUpdate()
  {
    List<ColorPalette> colors = new List<ColorPalette>(colorCooldowns.Keys);
    foreach (ColorPalette color in colors)
    {
      float newTime = colorCooldowns[color] - Time.fixedDeltaTime;
      if (newTime < 0)
      {
        colorCooldowns.Remove(color);
      }
      else
      {
        colorCooldowns[color] = newTime;
      }
    }
  }

  public void PreventColorSpawn(ColorPalette color)
  {
    colorCooldowns[color] = spawnTimeCooldown;
  }

  public Dictionary<ColorPalette, float> GetCooldownValues()
  {
    return new Dictionary<ColorPalette, float>(colorCooldowns);
  }
}
