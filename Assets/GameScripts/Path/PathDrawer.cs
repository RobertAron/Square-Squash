using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PathModel),typeof(LineRenderer))]
public class PathDrawer : MonoBehaviour {
  PathModel pathModel;
	LineRenderer lineRenderer;
	Renderer renderer;
	Vector3 scaleVector = new Vector3(.1f,.1f,.1f);

  void Start()
  {
    pathModel = GetComponent<PathModel>();
		lineRenderer = GetComponent<LineRenderer>();
		renderer = GetComponent<Renderer>();
	}

	public void DrawDebugPath(Vector3 fingerPosition)
	{
		var pos = Camera.main.ScreenToWorldPoint(fingerPosition);
  	pos.z = transform.position.z;
		List<Vector3> pathLocations= pathModel.GetPathLocations();
		pos.z = 0;
		pathLocations.Add(pos);

		Color currentColor = ColorSchema.GetColor(pathModel.GetPathColor());
		
		renderer.material.color =  currentColor;
		lineRenderer.positionCount = pathLocations.Count*2-1;
		for(int i=0;i<pathLocations.Count;i++){
			if(i!=0){
				Vector3 newDirectionSmall = Vector3.Scale(pathLocations[i] - pathLocations[i-1],scaleVector);
				Debug.Log(newDirectionSmall);
				lineRenderer.SetPosition(i*2-1,pathLocations[i-1]+newDirectionSmall);
			}
			lineRenderer.SetPosition(i*2,pathLocations[i]);
		}
		Debug.Log(lineRenderer.positionCount);
	}
	public void ClearLine(){
		lineRenderer.positionCount = 0;
	}
}
