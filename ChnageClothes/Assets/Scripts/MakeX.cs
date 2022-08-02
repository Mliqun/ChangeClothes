using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeX : MonoBehaviour
{
    Mesh mesh;
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    Color c = Color.blue;
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        mesh = meshFilter.mesh;
        VertexHelper vh = new VertexHelper();

        int n = 100;
        int r = 1;
        float ang = Mathf.PI * 2 / n;
        vh.AddVert(new Vector3(0, 0, 0), c, Vector2.zero);
        for (int i = 1; i < n+1; i++)
        {
            float x = Mathf.Sin(ang*i)*2*r;
            float y = Mathf.Cos(ang*i)*2*r;
            vh.AddVert(new Vector3(x, y, 0), c, Vector2.zero);
        }
        for (int i = 0; i < n; i++)
        {
            if (i==0)
            {
                vh.AddTriangle(0, n, 1);
            }
            else
            {
                vh.AddTriangle(0,i,i+1);
            }
        }

        //vh.AddVert(new Vector3(0,0,0), c,Vector2.zero);
        //vh.AddVert(new Vector3(0,1,0), c,Vector2.zero);
        //vh.AddVert(new Vector3(1,1,0), c,Vector2.zero);
        //vh.AddTriangle(0, 1, 2);

        vh.FillMesh(mesh);
        mesh.RecalculateBounds();

        Material material = new Material(Shader.Find("Standard"));
        material.color = Color.red;
        meshRenderer.material = material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
