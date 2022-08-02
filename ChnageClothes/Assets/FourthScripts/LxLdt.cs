using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LxLdt : Graphic
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
    public void SetSx(Wqs mysx)
    {
        nums[0] = mysx.gj;
        nums[1] = mysx.fw;
        nums[2] = mysx.bj;
        nums[3] = mysx.sf;
        nums[4] = mysx.gs;
        nums[5] = mysx.ys;
        SetVerticesDirty();
    }
    protected override void OnPopulateMesh(VertexHelper vh)
    {
        vh.Clear();
        Rect r = GetPixelAdjustedRect();

        //Vector4 v = new Vector4(r.x, r.y, r.x + r.width, r.y + r.height);
        //vh.AddVert(new Vector3(v.x, v.y), Color.white, new Vector2(0f, 0f));
        //vh.AddVert(new Vector3(v.x, v.w), Color.white, new Vector2(0f, 1f));
        //vh.AddVert(new Vector3(v.z, v.w), Color.white, new Vector2(1f, 1f));
        //vh.AddVert(new Vector3(v.z, v.y), Color.white, new Vector2(1f, 0f));

        //vh.AddTriangle(0, 1, 2);
        //vh.AddTriangle(0, 2, 3);

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
        
        if (r.width<r.height)
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
            float x = Mathf.Sin(i * ang)*bz  * nums[i];
            float y = Mathf.Cos(i * ang)*bz* nums[i];
            vh.AddVert(new Vector3(x, y, 0), c, Vector2.zero);
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (i==0)
            {
                vh.AddTriangle(7, nums.Length + 7, 8);
            }
            else
            {
                vh.AddTriangle(7, i + 7, i+8);
            }
        }
    }

}
