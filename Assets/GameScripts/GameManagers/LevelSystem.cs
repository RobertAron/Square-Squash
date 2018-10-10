using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{

	#region  Singleton
  public static LevelSystem instance;
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
  }
	#endregion

	[SerializeField]
	List<Level> levels = new List<Level>();
	[SerializeField]
	int currentLevelIndex = 0;
	SpecialActions specialActions;
  int pointsRequiredToLevel = 0;
  GameObject currentLevel;
  int itemsCleared = 0;

	private void Start() {
		specialActions = SpecialActions.instance;
    UpdateLevel();
	}
  public void AddPoint()
  {
    itemsCleared += 1;
    if(itemsCleared>pointsRequiredToLevel && currentLevelIndex< levels.Count-1) LevelUp();
  }

  void LevelUp(){
    currentLevelIndex++;
    Destroy(currentLevel);
    UpdateLevel();
  }

  void UpdateLevel()
  {
    currentLevel = Instantiate(levels[currentLevelIndex].gameObject);
    specialActions.SetTileSlots(currentLevel);
    pointsRequiredToLevel += levels[currentLevelIndex].pointsToAdvance;    
  }

}
