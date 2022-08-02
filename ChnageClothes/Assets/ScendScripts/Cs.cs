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
        
        //�����������ȫ�����������
        SkinnedMeshRenderer[] skinnedMeshRenderers = body.GetComponentsInChildren<SkinnedMeshRenderer>();
        //�ж���������ж��ٺϲ�ʵ��
        CombineInstance[] combines = new CombineInstance[skinnedMeshRenderers.Length];
        //��ȡ������
        //��������
        Texture2D[] texture2Ds = new Texture2D[skinnedMeshRenderers.Length];

        //ѭ����ֵ����
        for (int i = 0; i < skinnedMeshRenderers.Length; i++)
        {
            //��ȡ����
            texture2Ds[i] = skinnedMeshRenderers[i].material.GetTexture("_BackTex") as Texture2D;
        }

        //����������
        Texture2D texture = new Texture2D(1024, 1024, TextureFormat.ARGB32, false);
        //�ϲ�ͼ������ȡͻ����uv����
        Rect[] rects = texture.PackTextures(texture2Ds, 0);
        //�洢ԭ����uv���껹ԭ
        List<Vector2[]> old = new List<Vector2[]>();
        for (int i = 0; i < skinnedMeshRenderers.Length; i++)
        {
            //��ȡ���������ж����uv����
            Vector2[] olduv = skinnedMeshRenderers[i].sharedMesh.uv;
            old.Add(olduv);
            //Ϊ��������ж��㴴���µ�uv����
            Vector2[] newuv = new Vector2[olduv.Length];
            for (int j = 0; j < olduv.Length; j++)
            {
                newuv[j] = new Vector2((olduv[j].x * rects[i].width) + rects[i].x, (olduv[j].y * rects[i].height + rects[i].y));
            }
            skinnedMeshRenderers[i].sharedMesh.uv = newuv;
        }
        //ѭ�������ϲ�ʵ��
        for (int i = 0; i < skinnedMeshRenderers.Length; i++)
        {
            //�������
            combines[i].mesh = skinnedMeshRenderers[i].sharedMesh;
            //��Ӿ�����Ϣ
            combines[i].transform = skinnedMeshRenderers[i].transform.localToWorldMatrix;
            //�ر�ԭ����
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


        //��ԭ�������uv����
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
