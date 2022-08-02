using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineHead : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //�����������ȫ�����������
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        //�ж���������ж��ٺϲ�ʵ��
        CombineInstance[] combines = new CombineInstance[meshFilters.Length];
        //��ȡ������
        Material[] materials = new Material[meshFilters.Length];
        //��������
        Texture2D[] texture2Ds = new Texture2D[meshFilters.Length];
        
        //ѭ����ֵ����
        for (int i = 0; i <meshFilters.Length; i++)
        {
            //��ȡ������
            materials[i] = meshFilters[i].gameObject.GetComponent<MeshRenderer>().material;
            //��ȡ����
            texture2Ds[i] = materials[i].mainTexture as Texture2D;
        }

        //����������
        Texture2D texture = new Texture2D(1024, 1024, TextureFormat.ARGB32, false);
        //�ϲ�ͼ������ȡͻ����uv����
        Rect[] rects = texture.PackTextures(texture2Ds, 0);
        //�洢ԭ����uv���껹ԭ
        List<Vector2[]> old = new List<Vector2[]>();
        for (int i = 0; i < meshFilters.Length; i++)
        {
            //��ȡ���������ж����uv����
            Vector2[] olduv = meshFilters[i].mesh.uv;
            old.Add(olduv);
            //Ϊ��������ж��㴴���µ�uv����
            Vector2[] newuv = new Vector2[olduv.Length];
            for (int j = 0; j < olduv.Length; j++)
            {
                newuv[j] = new Vector2((olduv[j].x * rects[i].width) + rects[i].x, (olduv[j].y * rects[i].height + rects[i].y));
            }
            meshFilters[i].mesh.uv = newuv;
        }

        //ѭ�������ϲ�ʵ��
        for (int i = 0; i < meshFilters.Length; i++)
        {
            //�������
            combines[i].mesh = meshFilters[i].mesh;
            //��Ӿ�����Ϣ
            combines[i].transform = meshFilters[i].transform.localToWorldMatrix;
            //�ر�ԭ����
            meshFilters[i].gameObject.SetActive(false);
        }
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = new Mesh();
        meshFilter.mesh.CombineMeshes(combines);
        
        //���µ���������²���
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Standard"));
        meshRenderer.material.mainTexture = texture;
        //��ԭ�������uv����
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
