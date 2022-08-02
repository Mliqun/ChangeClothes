using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LxHz : MonoBehaviour
{
    public GameObject[] tou;
    public GameObject[] hand;
    public GameObject[] body;
    public GameObject[] leg;
    public int touid = 0;
    public int handid = 0;
    public int bodyid = 0;
    public int legid = 0;
    public int wqid=0;
    public GameObject gg;
    SkinnedMeshRenderer[] skinneds = new SkinnedMeshRenderer[4];
    Dictionary<string, SkinnedMeshRenderer> playDic = new Dictionary<string, SkinnedMeshRenderer>();
    
    public Transform fu;
    List<GameObject> wqs = new List<GameObject>();
    int lastid = -1;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <=3; i++)
        {
            string name = "w" + i;
            GameObject wq = Instantiate(Resources.Load<GameObject>(name), fu);
            wqs.Add(wq);
            wq.SetActive(false);
        }
        
        Change();
        
    }
    public SkinnedMeshRenderer GetById(string name,GameObject prefab)
    {
        if (playDic.ContainsKey(name))
        {
            return playDic[name];
        }
        else
        {
            SkinnedMeshRenderer play = Instantiate(prefab.transform.GetComponentInChildren<SkinnedMeshRenderer>());
            playDic.Add(name, play);
            play.gameObject.SetActive(false);
            return play;
        }
    }
    public void ChangeWq()
    {
        if (lastid!=-1)
        {
            wqs[lastid].SetActive(false);
            
        }
        wqs[wqid].SetActive(true);
        lastid = wqid;
    }
    public void Change()
    {
        print("½øÈë");
        ChangeWq();
        skinneds[0] = GetById(tou[touid].name, tou[touid]);
        skinneds[1] = GetById(hand[handid].name, hand[handid]);
        skinneds[2] = GetById(body[bodyid].name, body[bodyid]);
        skinneds[3] = GetById(leg[legid].name, leg[legid]);
        Texture2D[] texture2Ds = new Texture2D[skinneds.Length];
        for (int i = 0; i < skinneds.Length; i++)
        {
            texture2Ds[i] = skinneds[i].material.GetTexture("_MainTex") as Texture2D;
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
        }
        else{
            skinnedMesh = gg.AddComponent<SkinnedMeshRenderer>();
        }
        skinnedMesh.sharedMesh = new Mesh();
        skinnedMesh.sharedMesh.CombineMeshes(combines, true, false);
        skinnedMesh.material = new Material(Shader.Find("Mobile/Diffuse"));
        skinnedMesh.material.SetTexture("_MainTex", texture);

        Transform[] bones = gg.GetComponentsInChildren<Transform>();
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
