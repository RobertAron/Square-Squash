using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{

	#region  Singleton
  public static PointSystem instance;
  private void Awake()
  {
    if (instance == null)
    {
      instance = this;
    }
  }
	#endregion

  [SerializeField]
  int itemsCleared = 0;
  public void AddPoint()
  {
    itemsCleared += 1;
  }

}
