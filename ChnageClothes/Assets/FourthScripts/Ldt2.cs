using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Ldt2 : Graphic
{
    public Texture texture;
    public float[] nums;
    public Color c;
    public Color c1;
    public float cha;
    public override Texture mainTexture
    {
        get
        {
            if (texture == null)
            {
                if (material != null && material.mainTexture != null)
                {
                    return material.mainTexture;
                }
                return s_WhiteTexture;
            }
            return texture;
        }
    }
    // Start is called before the first frame update
    protected override void Start()
    {

    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();
        Rect r = GetPixelAdjustedRect();
        float ang = 2 * Mathf.PI / 6;
        vh.AddVert(Vector3.one, c, Vector2.zero);
        for (int i = 0; i < 6; i++)
        {
            float x = Mathf.Sin(ang * i) * 100;
            float y = Mathf.Cos(ang * i) * 100;
            vh.AddVert(new Vector3(x, y, 0), c1, Vector2.zero);
        }
        for (int i = 0; i < 6; i++)
        {
            if (i == 0)
            {
                vh.AddTriangle(0, 6, 1);
            }
            else
            {
                vh.AddTriangle(0, i, i + 1);
            }
        }
        float bj;
        if (r.width < r.height)
        {
            bj = (r.width - cha) / 2;
        }
        else
        {
            bj = (r.height - cha) / 2;
        }
        float bz = bj / nums.Max();
        vh.AddVert(Vector3.zero, c, Vector2.zero);
        for (int i = 0; i < nums.Length; i++)
        {
            float x = Mathf.Sin(i * ang) * bz * nums[i];
            float y = Mathf.Cos(i * ang) * bz * nums[i];
            vh.AddVert(new Vector3(x, y, 0), c, Vector2.zero);
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (i == 0)
            {
                vh.AddTriangle(7, nums.Length + 7, 8);
            }
            else
            {
                vh.AddTriangle(7, i + 7, i + 8);
            }
        }
    }
}
