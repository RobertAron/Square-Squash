using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PathModel),typeof(SimpleLineRenderer))]
public class PathDrawer : MonoBehaviour {
  PathModel pathModel;
	SimpleLineRenderer lineRenderer;
	new Renderer renderer;

  void Start()
  {
    pathModel = GetComponent<PathModel>();
		lineRenderer = GetComponent<SimpleLineRenderer>();
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
		for(int i=0;i<pathLocations.Count;i++){
			lineRenderer.SetNewPath(pathLocations.ToArray());
		}
	}
	public void ClearLine(){
		lineRenderer.SetNewPath(new Vector3[0]);
	}
}
