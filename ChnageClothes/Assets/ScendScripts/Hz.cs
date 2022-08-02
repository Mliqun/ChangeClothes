using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hz : MonoBehaviour
{
    public GameObject[] tou;
    public GameObject[] yf;
    public GameObject[] leg;
    public Texture2D[] face;
    public GameObject Avatar;
    int touid=0;
    int yfid = 0;
    int legid = 0;
    int faceid = 0;
    int texMax = 1024;
    SkinnedMeshRenderer[] skinneds = new SkinnedMeshRenderer[3];
    Dictionary<string, SkinnedMeshRenderer> bodydic = new Dictionary<string, SkinnedMeshRenderer>();
    // Start is called before the first frame update
    void Start()
    {
        Change();
        for (int i = 1; i < 5; i++)
        {
            Button btn = GameObject.Find("Canvas/Button" + i).GetComponent<Button>();
            int index = i;
            btn.onClick.AddListener(() =>
            {
                print(index);
                if (index == 1)
                {
                    touid++;
                    touid = touid % tou.Length;
                }
                else if (index == 2)
                {
                    yfid++;
                    yfid = yfid % yf.Length;
                }
                else if (index == 3)
                {
                    legid++;
                    legid = legid % leg.Length;
                }
                else if (index == 4)
                {
                    faceid++;
                    faceid = faceid % face.Length;
                }
                Change();
            });
        }
    }
    public SkinnedMeshRenderer GetBody(string name,GameObject prefab)
    {
        if (bodydic.ContainsKey(name))
        {
            return bodydic[name];
        }
        else
        {
            SkinnedMeshRenderer body = Instantiate(prefab.GetComponentInChildren<SkinnedMeshRenderer>());
            bodydic.Add(name, body);
            body.gameObject.SetActive(false);
            return body;
        }
    }
    public void Change()
    {
        skinneds[0] = GetBody(tou[touid].name, tou[touid]);
        skinneds[1] = GetBody(yf[yfid].name, yf[yfid]);
        skinneds[2] = GetBody(leg[legid].name, leg[legid]);

        Texture2D[] texture2Ds = new Texture2D[skinneds.Length];

        //循环赋值纹理
        for (int i = 0; i < skinneds.Length; i++)
        {
            //获取纹理
            texture2Ds[i] = skinneds[i].material.GetTexture("_BackTex") as Texture2D;
        }
        Texture2D texture = new Texture2D(1024, 1024, TextureFormat.ARGB32, false);
        //合并图集并获取突击的uv坐标
        Rect[] rects = texture.PackTextures(texture2Ds, 0);
        //存储原来的uv坐标还原
        List<Vector2[]> old = new List<Vector2[]>();
        for (int i = 0; i < skinneds.Length; i++)
        {
            //获取网格上所有顶点的uv坐标
            Vector2[] olduv = skinneds[i].sharedMesh.uv;
            old.Add(olduv);
            //为网格的所有顶点创建新的uv坐标
            Vector2[] newuv = new Vector2[olduv.Length];
            for (int j = 0; j < olduv.Length; j++)
            {
                newuv[j] = new Vector2((olduv[j].x * rects[i].width) + rects[i].x, (olduv[j].y * rects[i].height + rects[i].y));
            }
            skinneds[i].sharedMesh.uv = newuv;
        }
        CombineInstance[] instances = new CombineInstance[skinneds.Length];
        for (int i = 0; i < skinneds.Length; i++)
        {
            instances[i].mesh = skinneds[i].sharedMesh;
            //添加矩阵信息
            instances[i].transform = skinneds[i].transform.localToWorldMatrix;
        }
        SkinnedMeshRenderer skinnedMesh;
        if (Avatar.GetComponent<SkinnedMeshRenderer>())
        {
            skinnedMesh = Avatar.GetComponent<SkinnedMeshRenderer>();
        }
        else
        {
            skinnedMesh = Avatar.AddComponent<SkinnedMeshRenderer>();
        }
        skinnedMesh.sharedMesh = new Mesh();
        skinnedMesh.sharedMesh.CombineMeshes(instances, true, false);
        skinnedMesh.material = new Material(Shader.Find("Custom/Face"));
        skinnedMesh.material.SetTexture("_BackTex", texture);
        skinnedMesh.material.SetTexture("_MainTex", face[faceid]);
        skinnedMesh.material.SetFloat("_PosX", texture.width/texMax*4);
        skinnedMesh.material.SetFloat("_PosY", texture.height/texMax * 4);

        Transform[] bone = Avatar.GetComponentsInChildren<Transform>(true);
        Dictionary<string, Transform> bonedic = new Dictionary<string, Transform>();
        
        for (int i = 0; i < bone.Length; i++)
        {
            bonedic.Add(bone[i].name, bone[i]);
        }
        List<Transform> allbone = new List<Transform>();
        for (int i = 0; i < skinneds.Length; i++)
        {
            for (int j = 0; j < skinneds[i].bones.Length; j++)
            {
                if (bonedic.ContainsKey(skinneds[i].bones[j].name))
                {
                    allbone.Add(bonedic[skinneds[i].bones[j].name]);
                }
            }
        }
        skinnedMesh.bones = allbone.ToArray();


        //还原子物体的uv网格
        for (int i = 0; i < skinneds.Length; i++)
        {
            skinneds[i].sharedMesh.uv = old[i];
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
