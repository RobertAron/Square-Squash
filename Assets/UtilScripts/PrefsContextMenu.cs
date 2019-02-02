using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsContextMenu : MonoBehaviour {

	[ContextMenu("Destory All Prefs")]
	public void ResetPrefs(){
		PlayerPrefs.DeleteAll();
	}
}
