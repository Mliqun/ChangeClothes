using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateXX : MonoBehaviour
{
    Mesh mesh;
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    Vector3[] vers;
    int[] dd;
    Color c = Color.red;
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        mesh = meshFilter.mesh;

        VertexHelper vh = new VertexHelper();
        //vh.AddVert(new Vector3(0,0,0), c, Vector4.zero);
        //vh.AddVert(new Vector3(0,1,0), c, Vector4.zero);
        //vh.AddVert(new Vector3(1,1,0), c, Vector4.zero);
        //vh.AddVert(new Vector3(1,0,0), c, Vector4.zero);
        //vh.AddVert(new Vector3(1,0,1), c, Vector4.zero);
        //vh.AddVert(new Vector3(1,1,1), c, Vector4.zero);
        //vh.AddVert(new Vector3(0,0,1), c, Vector4.zero);
        //vh.AddVert(new Vector3(0,1,1), c, Vector4.zero);
        //vh.AddTriangle(0, 1, 2);
        //vh.AddTriangle(0, 2, 3);
        //vh.AddTriangle(3, 2, 4);
        //vh.AddTriangle(2, 5, 4);
        //vh.AddTriangle(5, 6, 4);
        //vh.AddTriangle(5, 7, 6);
        //vh.AddTriangle(7, 1, 6);
        //vh.AddTriangle(1, 0, 6);
        //vh.AddTriangle(1, 7, 5);
        //vh.AddTriangle(1, 5, 2);
        //vh.AddTriangle(4, 6, 0);
        //vh.AddTriangle(4, 0, 3);

        int n = 100;
        int r = 1;
        float angle = Mathf.PI * 2 / n;
        vh.AddVert(new Vector3(0, 0), c, Vector4.zero);
        for (int i = 1; i < n + 1; i++)
        {
            float x = Mathf.Sin(angle * i) * 2 * r;
            float y = Mathf.Cos(angle * i) * 2 * r;
            vh.AddVert(new Vector3(x, y), c, Vector4.zero);
        }
        for (int i = 0; i < n; i++)
        {
            if (i == 0)
            {
                vh.AddTriangle(0, n, 1);
            }
            else
            {
                vh.AddTriangle(0, i, i + 1);
            }
        }
        vh.FillMesh(mesh);
        mesh.RecalculateBounds();

        //vers = new Vector3[3];
        //vers[0] = new Vector3(0,0,0);
        //vers[1] = new Vector3(0,1,0);
        //vers[2] = new Vector3(1,1,0);
        //dd = new int[3];
        //dd[0] = 0;
        //dd[1] = 1;
        //dd[2] = 2;
        //mesh.Clear();
        ////为网格添加顶点
        //mesh.vertices = vers;
        ////为网格添加绘制顺序
        //mesh.triangles = dd;
        //mesh.RecalculateBounds();


        Material material = new Material(Shader.Find("Standard"));
        material.color = Color.green;
        meshRenderer.material = material;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
