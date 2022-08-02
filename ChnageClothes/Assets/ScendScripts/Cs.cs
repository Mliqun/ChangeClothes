using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cs : MonoBehaviour
{
    public GameObject body;
    public Texture2D face;
    // Start is called before the first frame update
    void Start()
    {
        
        //查找子物体的全部网格过滤器
        SkinnedMeshRenderer[] skinnedMeshRenderers = body.GetComponentsInChildren<SkinnedMeshRenderer>();
        //有多少网格就有多少合并实例
        CombineInstance[] combines = new CombineInstance[skinnedMeshRenderers.Length];
        //获取材质球
        //文理数组
        Texture2D[] texture2Ds = new Texture2D[skinnedMeshRenderers.Length];

        //循环赋值纹理
        for (int i = 0; i < skinnedMeshRenderers.Length; i++)
        {
            //获取纹理
            texture2Ds[i] = skinnedMeshRenderers[i].material.GetTexture("_BackTex") as Texture2D;
        }

        //创建新纹理
        Texture2D texture = new Texture2D(1024, 1024, TextureFormat.ARGB32, false);
        //合并图集并获取突击的uv坐标
        Rect[] rects = texture.PackTextures(texture2Ds, 0);
        //存储原来的uv坐标还原
        List<Vector2[]> old = new List<Vector2[]>();
        for (int i = 0; i < skinnedMeshRenderers.Length; i++)
        {
            //获取网格上所有顶点的uv坐标
            Vector2[] olduv = skinnedMeshRenderers[i].sharedMesh.uv;
            old.Add(olduv);
            //为网格的所有顶点创建新的uv坐标
            Vector2[] newuv = new Vector2[olduv.Length];
            for (int j = 0; j < olduv.Length; j++)
            {
                newuv[j] = new Vector2((olduv[j].x * rects[i].width) + rects[i].x, (olduv[j].y * rects[i].height + rects[i].y));
            }
            skinnedMeshRenderers[i].sharedMesh.uv = newuv;
        }
        //循环创建合并实例
        for (int i = 0; i < skinnedMeshRenderers.Length; i++)
        {
            //添加网格
            combines[i].mesh = skinnedMeshRenderers[i].sharedMesh;
            //添加矩阵信息
            combines[i].transform = skinnedMeshRenderers[i].transform.localToWorldMatrix;
            //关闭原物体
        }
        SkinnedMeshRenderer skinnedMesh = gameObject.AddComponent<SkinnedMeshRenderer>();
        skinnedMesh.sharedMesh = new Mesh();
        skinnedMesh.sharedMesh.CombineMeshes(combines, true, false);
        skinnedMesh.material = new Material(Shader.Find("Custom/Face"));
        skinnedMesh.material.SetTexture("_BackTex", texture);
        skinnedMesh.material.SetTexture("_MainTex", face);
        skinnedMesh.material.SetFloat("_Pos", 8);
        Transform[] bone = gameObject.GetComponentsInChildren<Transform>(true);
        Dictionary<string, Transform> bonedic = new Dictionary<string, Transform>();
        for (int i = 0; i < bone.Length; i++)
        {
            bonedic.Add(bone[i].name, bone[i]);
        }
        List<Transform> allbone = new List<Transform>();
        for (int i = 0; i < skinnedMeshRenderers.Length; i++)
        {
            for (int j = 0; j < skinnedMeshRenderers[i].bones.Length; j++)
            {
                if (bonedic.ContainsKey(skinnedMeshRenderers[i].bones[j].name))
                {
                    allbone.Add(bonedic[skinnedMeshRenderers[i].bones[j].name]);
                }
            }
        }
        skinnedMesh.bones = allbone.ToArray();


        //还原子物体的uv网格
        for (int i = 0; i < skinnedMeshRenderers.Length; i++)
        {
            skinnedMeshRenderers[i].sharedMesh.uv = old[i];
        }
        body.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
