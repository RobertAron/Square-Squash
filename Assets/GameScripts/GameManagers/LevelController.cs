using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	#region  Singleton
  public static LevelController instance;
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

	private void Start() {
		GameObject slotsParent = Instantiate(levels[currentLevelIndex].gameObject);
		specialActions = SpecialActions.instance;
		specialActions.SetTileSlots(slotsParent);
	}
}
