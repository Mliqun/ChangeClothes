using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System;

public class Rotaryfigure3<T>: MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public float spading;
    public float scalMax;
    public float scalMin;
    public GameObject prefab;
    List<GameObject> games = new List<GameObject>();
    List<Transform> games2 = new List<Transform>();
    Vector2 beginPos;
    float moveW;
    T[] arr;
    string lx;
    float c;
    float r;
    
    public void Init(string name,T[] arr)
    {
        this.arr = arr;
        lx = name;
        c = (prefab.GetComponent<RectTransform>().rect.width + spading) * arr.Length;
        r = c / (Mathf.PI * 2);
        LookData(0);
        for (int i = 0; i < games.Count; i++)
        {
            games[i].GetComponent<TableCell>().Ft(lx);
        }
    }
    public void LookData(float moveW)
    {
        float moveAng = (moveW / c) * (2 * Mathf.PI);
        float ang =(2 * Mathf.PI)/arr.Length;
        for (int i = 0; i < arr.Length; i++)
        {
            float x = Mathf.Sin(ang * i + moveAng) * r;
            float z = Mathf.Cos(ang * i + moveAng) * r+r;
            float scal = z / (2 * r) * (scalMax - scalMin) + scalMin;
            if (i<games.Count&&games[i]!=null)
            {
                games[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(x, 0);
                games[i].GetComponent<RectTransform>().localScale = Vector3.one*scal;
            }
            else
            {
                GameObject kk = Instantiate(prefab, transform);
                kk.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, 0);
                kk.GetComponent<RectTransform>().localScale = Vector3.one * scal;
                kk.GetComponent<TableCell>().Init2(arr[i]);
                games.Add(kk);
                games2.Add(kk.transform);
            }
        }
        games2.Sort(delegate (Transform a, Transform b)
        {
            if (a.localScale.x>b.localScale.x)
            {
                return 1;
            }else if(a.localScale.x==b.localScale.x)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        });
        for (int i = 0; i < games2.Count; i++)
        {
            games2[i].SetSiblingIndex(i);
        }
    }
    public void Autorotation(int kk)
    {
        int tc = kk % arr.Length - games2[games2.Count-1].GetComponent<TableCell>().id;
        float jl = (float)tc / arr.Length * c;
        DOTween.To((float a) =>
        {
            moveW = a;
            LookData(moveW);
        },moveW,moveW-jl,1f).OnComplete(()=>
        {
            games2[games2.Count - 1].GetComponent<TableCell>().Set(lx);
        });
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        beginPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        moveW += eventData.position.x - beginPos.x;
        beginPos = eventData.position;
        LookData(moveW);
    }

   
    public void OnEndDrag(PointerEventData eventData)
    {
        DOTween.To((float a) =>
        {
            moveW += a;
            LookData(moveW);
        },eventData.delta.x,0,1f).SetEase(Ease.OutQuad).OnComplete(()=>
        {
            float x = games2[games2.Count - 1].GetComponent<RectTransform>().anchoredPosition.x;
            float hc = Mathf.Sin(x / r) / (2 * Mathf.PI) * c;
            DOTween.To((float a) =>
            {
                moveW = a;
                LookData(moveW);
            },moveW,moveW-hc,1f).OnComplete(()=>
            {
                games2[games2.Count - 1].GetComponent<TableCell>().Set(lx);
            });

        });
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
