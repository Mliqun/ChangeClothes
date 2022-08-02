using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMesh : MonoBehaviour
{
    Mesh mesh;//网格
    MeshFilter meshFilter;//网格过滤器
    MeshRenderer meshRenderer;//网格渲染器

    Vector3[] vertices;//顶点坐标数组
    int[] triangles;//绘制顺序数组
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        mesh = meshFilter.mesh;

        vertices = new Vector3[8];
        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(0, 1, 0);
        vertices[2] = new Vector3(1, 0, 0);
        vertices[3] = new Vector3(1, 1, 0);
        vertices[4] = new Vector3(1, 0, 1);
        vertices[5] = new Vector3(1, 1, 1);
        vertices[6] = new Vector3(0, 0, 1);
        vertices[7] = new Vector3(0, 1, 1);

        triangles = new int[36];
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 1;
        triangles[4] = 3;
        triangles[5] = 2;
        //------------------
        triangles[6] = 2;
        triangles[7] = 3;
        triangles[8] = 4;

        triangles[9] = 3;
        triangles[10] = 5;
        triangles[11] = 4;
        //------------------

        triangles[12] = 4;
        triangles[13] = 5;
        triangles[14] = 6;

        triangles[15] = 5;
        triangles[16] = 7;
        triangles[17] = 6;
        //------------------

        triangles[18] = 7;
        triangles[19] = 1;
        triangles[20] = 6;

        triangles[21] = 6;
        triangles[22] = 1;
        triangles[23] = 0;

        //------------------

        triangles[24] = 1;
        triangles[25] = 7;
        triangles[26] = 5;
        
        triangles[27] = 1;
        triangles[28] = 5;
        triangles[29] = 3;

        //------------------

        triangles[30] = 4;
        triangles[31] = 6;
        triangles[32] = 0;

        triangles[33] = 4;
        triangles[34] = 0;
        triangles[35] = 2;


        //u3d中绘制图形都是三角形绘制法 顺时针 所以现在记录全部的点，然后确定三角形绘制的顺序
        //创建三角形的三个顶点
        //vertices=new Vector3[4];
        //vertices[0] = new Vector3(0, 0, 0);
        //vertices[1] = new Vector3(0, 1, 0);
        //vertices[2] = new Vector3(1, 0, 0);
        //vertices[3] = new Vector3(1, 1, 0);
        ////确定三角形的绘制的顺序
        //triangles = new int[6];
        //triangles[0] = 0;
        //triangles[1] = 1;
        //triangles[2] = 2;

        //triangles[3] = 1;
        //triangles[4] = 3;
        //triangles[5] = 2;


        //圆形
        //int n = 10;
        //int r = 1;
        //float angle = Mathf.PI * 2 / n;

        //vertices = new Vector3[n+ 1];
        //vertices[0] = new Vector3(0, 0, 0);
        //for (int i = 1; i < vertices.Length; i++)
        //{
        //    float x = Mathf.Sin(angle * i) * 2 * r;
        //    float y = Mathf.Cos(angle * i) * 2 * r;
        //    vertices[i] = new Vector3(x, y, 0);
        //}
        //triangles = new int[n * 3];
        //for (int i = 0; i < n; i++)
        //{
        //    if (i==0)
        //    {
        //        triangles[i * 3] = 0;
        //        triangles[i * 3+1] = n;
        //        triangles[i * 3+2] = i+1;
        //    }
        //    else
        //    {
        //        triangles[i * 3] = 0;
        //        triangles[i * 3 + 1] = i;
        //        triangles[i * 3 + 2] = i + 1;
        //    }
        //}

        //清理网格
        mesh.Clear();
        //为网格添加顶点
        mesh.vertices = vertices;
        //为网格添加绘制顺序
        mesh.triangles = triangles;
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
