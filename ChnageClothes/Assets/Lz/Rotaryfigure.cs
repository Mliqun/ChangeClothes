using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Rotaryfigure<T> : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public float padding=10;
    public float scaleMax=1;
    public float scaleMin=1;
    public GameObject prefab;
    float c;
    float r;
    T[] arr;
    List<GameObject> games = new List<GameObject>();
    List<Transform> games2 = new List<Transform>();
    Vector2 beginpos;
    float moveW;//总移动距离
    string lx;
    public void Init(string name,T[] arr)
    {
        lx = name;
        moveW = 0;
        this.arr = arr;
        //计算周长
        c = (prefab.transform.GetComponent<RectTransform>().rect.width + padding) * arr.Length;
        //计算半径
        r = c / (Mathf.PI*2);
        LookData(0);
        for (int i = 0; i < games.Count; i++)
        {
            games[i].GetComponent<TableCell>().Ft(lx);
        }
    }
    public void LookData(float moveW)
    {
        float moveAng = (moveW / c)* Mathf.PI * 2;
        float ang = 2 * Mathf.PI / arr.Length;
        for (int i = 0; i < arr.Length; i++)
        {
            float x = Mathf.Sin(ang * i + moveAng) * r;
            print(x + "..............................");
            float z = Mathf.Cos(ang * i + moveAng) * r+r;//保证z是正值 最小是0  最大是2r
            float scale = (z / (2 * r)) * (scaleMax - scaleMin) + scaleMin;
            if (i<games.Count&&games[i]!=null)
            {
                games[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(x, 0);
                games[i].GetComponent<RectTransform>().localScale = Vector3.one * scale;
            }
            else
            {
                GameObject kk = Instantiate(prefab,transform);
                kk.name = i.ToString();
                kk.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, 0);
                kk.GetComponent<RectTransform>().localScale = Vector3.one * scale;
                kk.GetComponent<TableCell>().Init2(arr[i]);
                games.Add(kk);
                games2.Add(kk.transform);
            }
        }
        
        games2.Sort(delegate (Transform a, Transform b)
        {
            if (a.localScale.x > b.localScale.x)
            {
                return 1;
            }
            else if (a.localScale.x == b.localScale.x)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        );

        for (int i = 0; i < games.Count; i++)
        {   
            games2[i].SetSiblingIndex(i);
        }
    }
    public void Autorotation(int kk)
    {
        //自动旋转
        int ts = kk%arr.Length - games2[games2.Count - 1].GetComponent<TableCell>().id;//间隔几个头
        float jl=(float)ts/arr.Length*c;
        DOTween.To((float a) =>
        {
            moveW = a;
            LookData(moveW);
        }, moveW, moveW - jl, 2f).SetEase(Ease.OutQuad).OnComplete(() =>
            {
                games2[games2.Count - 1].GetComponent<TableCell>().Set(lx);
            });
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        beginpos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        moveW+= eventData.position.x - beginpos.x;
        //if (moveW>c)
        //{
        //    moveW = moveW % c;
        //}
        beginpos = eventData.position;
        LookData(moveW);
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        DOTween.To((float a) =>
        {
            moveW += a;
            LookData(moveW);
        }, eventData.delta.x, 0, 1f).SetEase(Ease.OutQuad)
        .OnComplete(() =>
           {
               float x = games2[games2.Count - 1].GetComponent<RectTransform>().anchoredPosition.x;
               float d = Mathf.Sin(x / r) / (2 * Mathf.PI) * c;
               DOTween.To((float a) =>
               {
                   LookData(a);
                   moveW = a;
               }, moveW, moveW - d, 1f).SetEase(Ease.OutQuad).OnComplete(() =>
               {
                   games2[games2.Count - 1].GetComponent<TableCell>().Set(lx);
               }
               );
           });
    }


    // Start is called before the first frame update

}
