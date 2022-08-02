using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CreateX : Graphic
{
    public Color c=Color.blue;
    public Texture2D texture2D;
    public float cha;
    public float[] nums;
    public Slider slider1;
    public Slider slider2;
    public Slider slider3;

    protected override void Start()
    {
        nums = new float[6];
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = 100;
        }
        Debug.Log(111111111111);
        for (int i = 1; i < 4; i++)
        {
            int num = i;
            GameObject.Find("Canvas/GameObject" + num + "/Button").GetComponent<Button>().onClick.AddListener(() =>
            {
                int sj = Random.Range(1, 6);
                float sj2= sj*0.01f;
                if (GameObject.Find("Canvas/GameObject" + num + "/Slider").GetComponent<Slider>().value<1)
                {
                    GameObject.Find("Canvas/GameObject" + num + "/Slider").GetComponent<Slider>().value += sj2;
                    nums[num] += sj;
                }
                SetVerticesDirty();
            });

            GameObject.Find("Canvas/GameObject" + num + "/Button2").GetComponent<Button>().onClick.AddListener(() =>
            {
                int sj = Random.Range(1, 6);
                float sj2 = sj * 0.01f;
                if (GameObject.Find("Canvas/GameObject" + num + "/Slider").GetComponent<Slider>().value > 0)
                {
                    GameObject.Find("Canvas/GameObject" + num + "/Slider").GetComponent<Slider>().value -= sj2;
                    nums[num] -= sj;
                }
                SetVerticesDirty();
            });
        }
    }
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
        //get
        //{
        //    if (texture2D == null)
        //    {
        //        if (material != null && material.mainTexture != null)
        //        {
        //            return material.mainTexture;
        //        }
        //        return s_WhiteTexture;
        //    }
        //    return texture2D;
        //}
    }
    protected override void OnPopulateMesh(VertexHelper vh)
    {
       
        vh.Clear();
        Rect r = GetPixelAdjustedRect();
        Vector4 v = new Vector4(r.x, r.y, r.x + r.width, r.y + r.height);
        vh.AddVert(new Vector3(v.x, v.y), c, new Vector2(0f, 0f));
        vh.AddVert(new Vector3(v.x, v.w), c, new Vector2(0f, 1f));
        vh.AddVert(new Vector3(v.z, v.w), c, new Vector2(1f, 1f));
        vh.AddVert(new Vector3(v.z, v.y), c, new Vector2(1f, 0f));
        vh.AddTriangle(0,1,2);
        vh.AddTriangle(2,3,0);

        float bj;
        if (r.width<r.height)
        {
            bj = (r.width - cha)/2;
        }
        else
        {
            bj = (r.height-cha)/2;
        }
        //Color c2 = Color.green;

        Color c2 = new Color(1, 0, 1, 180f/255f);
        //
        float sf = bj / nums.Max();
        float ang = Mathf.PI * 2 / nums.Length;
        vh.AddVert(Vector3.zero, c2, Vector2.zero);

        for (int i = 0; i < nums.Length; i++)
        {
            float x = Mathf.Sin(ang * i) * nums[i] * sf;
            float y = Mathf.Cos(ang * i) * nums[i] * sf;
            vh.AddVert(new Vector3(x,y,0), c2, Vector2.zero);
        }
        for (int i = 0; i < nums.Length; i++)
        {
            if (i==0)
            {
                vh.AddTriangle(0 + 4, nums.Length + 4, i + 4 + 1);
            }
            else
            {
                vh.AddTriangle(0 + 4,i + 4, i + 1+4);
            }
        }
    }
    public void Update()
    {
        
    }
}
