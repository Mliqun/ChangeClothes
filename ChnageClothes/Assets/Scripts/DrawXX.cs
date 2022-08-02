using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DrawXX : Graphic
{
    public Texture texture;
    public float[] nums;
    public float cha;
    public Color c2 ;
    public override Texture mainTexture
    {
        get
        {
            if (texture==null)
            {
                if (material!=null&&material.mainTexture!=null)
                {
                    return material.mainTexture;
                }
                return s_WhiteTexture;
            }
            return texture;
        }
    }
    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();
        Rect r = GetPixelAdjustedRect();
        Vector4 v = new Vector4(r.x, r.y, r.x + r.width, r.y + r.height);
        Color c = Color.green;
        vh.AddVert(new Vector3(v.x, v.y), c, new Vector2(0, 0));
        vh.AddVert(new Vector3(v.x, v.w), c, new Vector2(0, 1));
        vh.AddVert(new Vector3(v.z, v.w), c, new Vector2(1, 1));
        vh.AddVert(new Vector3(v.z, v.y), c, new Vector2(1, 0));
        vh.AddTriangle(0, 1, 2);
        vh.AddTriangle(2, 3, 0);

        float bj;
        if (r.width<r.height)
        {
            bj = (r.width-cha)/2;
        }
        else
        {
            bj = (r.height - cha) / 2;
        }
        float bz = bj / nums.Max();
        float ang = Mathf.PI * 2 / nums.Length;
        vh.AddVert(new Vector3(0, 0, 0), c2, Vector2.zero);
        for (int i = 0; i < nums.Length; i++)
        {
            float x = Mathf.Sin(ang * i) * nums[i] * bz;
            float y = Mathf.Cos(ang * i) * nums[i] * bz;
            vh.AddVert(new Vector3(x, y, 0), c2, Vector2.zero);
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (i==0)
            {
                vh.AddTriangle(4, nums.Length + 4, 5);
            }
            else
            {
                vh.AddTriangle(4, i + 4, i + 5);
            }
        }
    }
}
