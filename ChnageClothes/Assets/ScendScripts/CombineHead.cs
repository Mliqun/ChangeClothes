using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineHead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //查找子物体的全部网格过滤器
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        //有多少网格就有多少合并实例
        CombineInstance[] combines = new CombineInstance[meshFilters.Length];
        //获取材质球
        Material[] materials = new Material[meshFilters.Length];
        //文理数组
        Texture2D[] texture2Ds = new Texture2D[meshFilters.Length];
        
        //循环赋值纹理
        for (int i = 0; i <meshFilters.Length; i++)
        {
            //获取材质球
            materials[i] = meshFilters[i].gameObject.GetComponent<MeshRenderer>().material;
            //获取纹理
            texture2Ds[i] = materials[i].mainTexture as Texture2D;
        }

        //创建新纹理
        Texture2D texture = new Texture2D(1024, 1024, TextureFormat.ARGB32, false);
        //合并图集并获取突击的uv坐标
        Rect[] rects = texture.PackTextures(texture2Ds, 0);
        //存储原来的uv坐标还原
        List<Vector2[]> old = new List<Vector2[]>();
        for (int i = 0; i < meshFilters.Length; i++)
        {
            //获取网格上所有顶点的uv坐标
            Vector2[] olduv = meshFilters[i].mesh.uv;
            old.Add(olduv);
            //为网格的所有顶点创建新的uv坐标
            Vector2[] newuv = new Vector2[olduv.Length];
            for (int j = 0; j < olduv.Length; j++)
            {
                newuv[j] = new Vector2((olduv[j].x * rects[i].width) + rects[i].x, (olduv[j].y * rects[i].height + rects[i].y));
            }
            meshFilters[i].mesh.uv = newuv;
        }

        //循环创建合并实例
        for (int i = 0; i < meshFilters.Length; i++)
        {
            //添加网格
            combines[i].mesh = meshFilters[i].mesh;
            //添加矩阵信息
            combines[i].transform = meshFilters[i].transform.localToWorldMatrix;
            //关闭原物体
            meshFilters[i].gameObject.SetActive(false);
        }
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = new Mesh();
        meshFilter.mesh.CombineMeshes(combines);
        
        //给新的网格添加新材质
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Standard"));
        meshRenderer.material.mainTexture = texture;
        //还原子物体的uv网格
        for (int i = 0; i < meshFilters.Length; i++)
        {
            meshFilters[i].mesh.uv = old[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
