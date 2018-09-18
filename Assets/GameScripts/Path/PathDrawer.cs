using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PathModel),typeof(LineRenderer))]
public class PathDrawer : MonoBehaviour {
  PathModel pathModel;
	LineRenderer lineRenderer;
	Renderer renderer;

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
		Debug.Log(fingerPosition);

		Color currentColor = ColorSchema.GetColor(pathModel.GetPathColor());
		
		renderer.material.color =  currentColor;
		lineRenderer.positionCount = pathLocations.Count;
		for(int i=0;i<pathLocations.Count;i++){
			lineRenderer.SetPosition(i,pathLocations[i]);
		}
		Debug.Log(lineRenderer.positionCount);
	}
	private void OnPostRender() {
		Debug.Log("post render");
	}
}
