using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RadarMap : Graphic
{
    //public float scale = 1;
    public float[] scores;
    public Texture2D texture2D;
    public int cha;
    public float thick;
    public override Texture mainTexture
    {
        get
        {
            if (texture2D==null)
            {
                if (material!=null&&material.mainTexture!=null)
                {
                    return material.mainTexture;
                }
                return s_WhiteTexture;
            }
            return texture2D;
        }
    }
    protected override void OnPopulateMesh(VertexHelper vh)
    {

        vh.Clear();
        Rect r = GetPixelAdjustedRect();//��ȡͼƬ������Ϣ

        Vector4 v = new Vector4(r.x, r.y, r.x + r.width, r.y + r.height);

        Color32 color32 = Color.red;
        // xԲ�� 0 y��Զ��0   w �����ұ�  z�������¿� �ĸ� 
        vh.AddVert(new Vector3(v.x, v.y), color32, new Vector2(0f, 0f));
        vh.AddVert(new Vector3(v.x, v.w), color32, new Vector2(0f, 1f));
        vh.AddVert(new Vector3(v.z, v.w), color32, new Vector2(1f, 1f));
        vh.AddVert(new Vector3(v.z, v.y), color32, new Vector2(1f, 0f));

        vh.AddTriangle(0,1,2);
        vh.AddTriangle(2,3,0);

        float raious;
        if (r.width<r.height)//ȡͼƬС�ı߳�Ϊ�뾶
        {
            raious=(r.width- cha) / 2f;
        }
        else
        {
            raious =( r.height -cha)/ 2f;
        }

        float ratio = raious / scores.Max();//ȡ�뾶���������ֵ�ı�ֵ*����
        float angle = Mathf.PI * 2 / scores.Length;//PI��180�ȣ�PI*2��360�ȣ�����n������������Ƕ�
        vh.AddVert(Vector3.zero, color, Vector2.zero);
       
        for (int i = 0; i < scores.Length; i++)
        {
            float x = Mathf.Sin(angle * i) * scores[i] * ratio;
            float y = Mathf.Cos(angle * i) * scores[i] * ratio;
            vh.AddVert(new Vector3(x, y, 0), color, Vector2.zero);

            float x1 = Mathf.Sin(angle * i) * (scores[i] * ratio- thick);
            float y1 = Mathf.Cos(angle * i) * (scores[i] * ratio - thick);
            vh.AddVert(new Vector3(x1, y1, 0), color, Vector2.zero);
        }
        //����������
        for (int i =0; i < scores.Length; i++)
        {
            if (i==0)
            {
                vh.AddTriangle(i+4, (scores.Length * 2 - 1)+4, i+1+4);
                vh.AddTriangle((scores.Length * 2 - 1) + 4, i+1+4, i + 2 + 4);
                vh.AddTriangle((scores.Length * 2 - 1) + 4, i+2+4, scores.Length * 2+4);
                
            }
            else
            {
                vh.AddTriangle(0+4, (i*2-1)+4,((i+1)*2-1)+4);
                vh.AddTriangle((i*2-1)+4, (i*2+1)+4,((i+1)*2)+4);
                vh.AddTriangle((i * 2 - 1) + 4, ((i + 1) * 2) + 4, (i*2)+4);
            }
        }
    }
}
