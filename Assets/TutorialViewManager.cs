using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialViewManager : MonoBehaviour {
	public GameObject tutorialsContainer;
	PointSystem ps;
	Transform[] tutorials;
	public int[] pointsNeeded;
	public SpringyMove camerasSpring;
	MetaGameStateController metaGameStateController;
	int currentIndex = 0;
	// Use this for initialization
	private void Awake() {
		List<Transform> tutorialsL = new List<Transform>();
		foreach (Transform child in tutorialsContainer.transform)
		{
			tutorialsL.Add(child);
		}
		tutorials = tutorialsL.ToArray();
		if(tutorials.Length!=pointsNeeded.Length) throw new System.Exception("Tutorial points does not match tutorial amount");
	}

	void Start () {
		ps = PointSystem.instance;
		metaGameStateController = MetaGameStateController.instance;
		if(metaGameStateController==null) throw new System.Exception("Game State controller not found");
	}
	
	// Update is called once per frame
	void Update () {
		try{
			if(ps.GetCurrentPoints()==pointsNeeded[currentIndex]){
				Vector3 moveTo = new Vector3(tutorials[currentIndex].position.x,Camera.main.transform.position.y,Camera.main.transform.position.z);
				camerasSpring.StartMove(moveTo);
				currentIndex+=1;
			}
		}catch{
			currentIndex = 0;
		}
	}
}
