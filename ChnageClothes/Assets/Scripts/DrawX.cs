using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawX : MonoBehaviour
{
    Mesh mesh;
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    Color color = Color.red;
    Mesh mesh2;
    MeshFilter meshFilter2;
    MeshRenderer meshRenderer2;
    Mesh mesh3;
    MeshFilter meshFilter3;
    MeshRenderer meshRenderer3;
    Color color2 = Color.red;
    public GameObject two;
    public GameObject three;
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        mesh=meshFilter.mesh;
        VertexHelper vh = new VertexHelper();
        vh.AddVert(new Vector3(0, 0, 0), color, Vector2.zero);
        vh.AddVert(new Vector3(0, 1, 0), color, Vector2.zero);
        vh.AddVert(new Vector3(1, 1, 0), color, Vector2.zero);
        vh.AddTriangle(0,1, 2);

        vh.FillMesh(mesh);
        mesh.RecalculateBounds();
        Material material = new Material(Shader.Find("Standard"));
        material.color = color;
        meshRenderer.material = material;

        meshFilter2 = two.AddComponent<MeshFilter>();
        meshRenderer2 = two.AddComponent<MeshRenderer>();
        mesh2 = meshFilter2.mesh;
        VertexHelper vh2 = new VertexHelper();
        vh2.AddVert(new Vector3(0, 0, 0), color2, Vector2.zero);
        vh2.AddVert(new Vector3(0, 1, 0), color2, Vector2.zero);
        vh2.AddVert(new Vector3(1, 1, 0), color2, Vector2.zero);
        vh2.AddVert(new Vector3(1, 0, 0), color2, Vector2.zero);
        vh2.AddTriangle(0,1,2);
        vh2.AddTriangle(2,3,0);
        vh2.FillMesh(mesh2);
        mesh2.RecalculateBounds();
        Material material2 = new Material(Shader.Find("Standard"));
        material2.color = color2;
        meshRenderer2.material = material2;

        meshFilter3 = three.AddComponent<MeshFilter>();
        meshRenderer3 = three.AddComponent<MeshRenderer>();
        mesh3 = meshFilter3.mesh;
        VertexHelper vh3 = new VertexHelper();
        int  n = 100;
        float r = 1;
        float ang = Mathf.PI * 2 / n;
        vh3.AddVert(new Vector3(0, 0, 0), color, Vector2.zero);
        for (int i = 0; i < n; i++)
        {
            float x = Mathf.Sin(ang * i) * 2 * r;
            float y = Mathf.Cos(ang * i) * 2 * r;
            vh3.AddVert(new Vector3(x, y, 0), color, Vector2.zero);
        }
        for (int i = 0; i < n; i++)
        {
            if (i==0)
            {
                vh3.AddTriangle(0, n , 1);
            }
            else
            {
                vh3.AddTriangle(0, i, i+1);
            }
        }
        vh3.FillMesh(mesh3);
        mesh3.RecalculateBounds();
        Material material3 = new Material(Shader.Find("Standard"));
        material3.color = color;
        meshRenderer3.material = material3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
