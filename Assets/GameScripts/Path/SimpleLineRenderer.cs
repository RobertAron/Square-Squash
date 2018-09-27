using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// [RequireComponent(typeof(MeshRenderer))]
[ExecuteInEditMode]
public class SimpleLineRenderer : MonoBehaviour
{

  public float lineWidth = 1;
  [SerializeField]
  Vector3[] path = new Vector3[0];

  MeshFilter mf;
  Mesh mesh;

  void RebuildPathMash()
  {
    float lineHalf = lineWidth / 2;
    Vector3[] vertices = new Vector3[path.Length * 4];
    int[] triangles = new int[6 * path.Length];
    Vector2[] uvs = new Vector2[path.Length * 4];

    Vector2 uvA = new Vector2(0, 1);
    Vector2 uvB = new Vector2(0, 0);
    Vector2 uvC = new Vector2(1, 1);
    Vector2 uvD = new Vector2(1, 0);

    for (int i = 0; i < path.Length - 1; i++)
    {
      Vector3 start = path[i];
      Vector3 end = path[i + 1];
      // Todo: not sure if fowards or backwards
      Vector3 side = Vector3.Cross(Vector3.back, end - start).normalized;

      Vector3 a = start + side * lineHalf;
      Vector3 b = start + side * lineHalf * -1;
      Vector3 c = end + side * lineHalf;
      Vector3 d = end + side * lineHalf * -1;

      int aIndex = 4 * i;
      int bIndex = 4 * i + 1;
      int cIndex = 4 * i + 2;
      int dIndex = 4 * i + 3;

      vertices[aIndex] = a;
      vertices[bIndex] = b;
      vertices[cIndex] = c;
      vertices[dIndex] = d;

      triangles[6 * i] = aIndex;
      triangles[6 * i + 1] = bIndex;
      triangles[6 * i + 2] = cIndex;
      triangles[6 * i + 3] = cIndex;
      triangles[6 * i + 4] = bIndex;
      triangles[6 * i + 5] = dIndex;

      uvs[aIndex] = uvA;
      uvs[bIndex] = uvB;
      uvs[cIndex] = uvC;
      uvs[dIndex] = uvD;
    }
    mesh.Clear();
    mesh.vertices = vertices;
    mesh.triangles = triangles;
    mesh.uv = uvs;
    mesh.RecalculateNormals();

  }

  private void OnValidate()
  {
    if (mesh != null)
      RebuildPathMash();
  }

  // Use this for initialization
  void Awake()
  {
    mesh = new Mesh();
    mf = GetComponent<MeshFilter>();
    mf.mesh = mesh;
		RebuildPathMash();
  }

  public void SetNewPath(Vector3[] path)
  {
    this.path = path;
    RebuildPathMash();
  }
}
