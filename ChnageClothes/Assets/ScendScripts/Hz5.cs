using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using Newtonsoft.Json;

public class AA
{
    public string icon;
}
public class Hz5 : MonoBehaviour
{
    public GameObject[] tou;   
    public GameObject[] yf;   
    public GameObject[] leg;
    public Texture2D[] face;
    int touid=1;
    int yfid=1;
    int legid=1;
    int faceid=1;
    int texMax = 1024;
    public GameObject gg;
    SkinnedMeshRenderer[] skinneds = new SkinnedMeshRenderer[3];
    Dictionary<string, SkinnedMeshRenderer> bodydic = new Dictionary<string, SkinnedMeshRenderer>();
    int count = 0;
    public Button btn;
    List<AA> lists = new List<AA>();
    // Start is called before the first frame update
    void Start()
    {
        string path = Application.dataPath + "/Json/jj.json";
        btn.onClick.AddListener(() =>
        {
            count++;
            string text=File.ReadAllText(path);
            lists = JsonConvert.DeserializeObject<List<AA>>(text);
            foreach (var item in lists)
            {
                print(item.icon);
            }
            AA newc = new AA();
            newc.icon = count.ToString();
            lists.Add(newc);
            string newjson = JsonConvert.SerializeObject(lists);
            File.WriteAllText(path, newjson);
        });
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
    public SkinnedMeshRenderer GetById(string name,GameObject prefab)
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
        skinneds[0] = GetById(tou[touid].name, tou[touid]);
        skinneds[1] = GetById(yf[yfid].name, yf[yfid]);
        skinneds[2] = GetById(leg[legid].name, leg[legid]);
        Texture2D[] texture2Ds = new Texture2D[skinneds.Length];
        for (int i = 0; i < skinneds.Length; i++)
        {
            texture2Ds[i] = skinneds[i].material.GetTexture("_BackTex") as Texture2D;
        }
        Texture2D texture = new Texture2D(1024, 1024, TextureFormat.ARGB32, false);
        Rect[] rects = texture.PackTextures(texture2Ds, 0);
        List<Vector2[]> old = new List<Vector2[]>();
        for (int i = 0; i < skinneds.Length; i++)
        {
            Vector2[] olduv = skinneds[i].sharedMesh.uv;
            old.Add(olduv);
            Vector2[] newuv = new Vector2[olduv.Length];
            for (int j = 0; j < olduv.Length; j++)
            {
                newuv[j] = new Vector2(olduv[j].x * rects[i].width + rects[i].x, olduv[j].y * rects[i].height + rects[i].y);
            }
            skinneds[i].sharedMesh.uv = newuv;
        }
        CombineInstance[] combines = new CombineInstance[skinneds.Length];
        for (int i = 0; i < skinneds.Length; i++)
        {
            combines[i].mesh = skinneds[i].sharedMesh;
            combines[i].transform = skinneds[i].transform.localToWorldMatrix;
        }
        SkinnedMeshRenderer skinnedMesh;
        if (gg.GetComponent<SkinnedMeshRenderer>())
        {
            skinnedMesh = gg.GetComponent<SkinnedMeshRenderer>();
        }else
        {
            skinnedMesh = gg.AddComponent<SkinnedMeshRenderer>();
        }
        skinnedMesh.sharedMesh = new Mesh();
        skinnedMesh.sharedMesh.CombineMeshes(combines, true, false);
        skinnedMesh.material = new Material(Shader.Find("Custom/Face"));
        skinnedMesh.material.SetTexture("_BackTex", texture);
        skinnedMesh.material.SetTexture("_MainTex", face[faceid]);
        skinnedMesh.material.SetFloat("_PosX", texture.width / texMax * 4);
        skinnedMesh.material.SetFloat("_PosY", texture.height / texMax * 4);

        Transform[] bones = gg.GetComponentsInChildren<Transform>(true);
        Dictionary<string, Transform> bonedic = new Dictionary<string, Transform>();
        for (int i = 0; i < bones.Length; i++)
        {
            bonedic.Add(bones[i].name, bones[i]);
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
