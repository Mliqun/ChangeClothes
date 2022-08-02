using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Rotaryfigure2<T> : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public float spacing;
    public float scalMax;
    public float scalMin;
    public GameObject prefab;
    float c;
    float r;
    List<GameObject> games = new List<GameObject>();
    List<Transform> games2 = new List<Transform>();
    string lx;
    T[] arr;
    Vector2 beginpos;
    float moveW;
    public void Init(string name,T[] arr)
    {
        this.arr = arr;
        lx = name;
        c = (prefab.GetComponent<RectTransform>().rect.width + spacing) * arr.Length;
        r = c / (2 * Mathf.PI);
        LookData(0);
        for (int i = 0; i < games.Count; i++)
        {
            games[i].GetComponent<TableCell>().Ft(lx);
        }
    }
    public void LookData(float moveW)
    {
        float moveAng = (moveW / c) * (2 * Mathf.PI);
        float ang = (2 * Mathf.PI) / arr.Length;
        for (int i = 0; i < arr.Length; i++)
        {
            float x = Mathf.Sin(ang * i + moveAng) * r;
            float z = Mathf.Cos(ang * i + moveAng) * r+r;
            float scal = (z / (2 * r)) * (scalMax - scalMin) + scalMin;
            if (i<games.Count&&games[i]!=null)
            {
                games[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(x,0);
                games[i].GetComponent<RectTransform>().localScale = Vector3.one * scal;
            }
            else
            {
                GameObject kk = Instantiate(prefab, transform);
                prefab.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, 0);
                prefab.GetComponent<RectTransform>().localScale = Vector3.one * scal;
                prefab.GetComponent<TableCell>().Init2(arr[i]);
                games.Add(kk);
                games2.Add(kk.transform);
            }
        }
        games2.Sort(delegate (Transform a, Transform b)
        {
            if (a.localScale.x>b.localScale.x)
            {
                return 1;
            }
            else if(a.localScale.x==b.localScale.x)
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
        int ts = (kk % arr.Length - games2[games2.Count - 1].GetComponent<TableCell>().id);
        float jl = (float)ts / arr.Length * c;
        DOTween.To((float a) =>
        {
            moveW = a;
            LookData(moveW);
        }, moveW, moveW - jl, 1f).SetEase(Ease.OutQuad).OnComplete(() =>
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
        moveW += eventData.position.x- beginpos.x;
        beginpos = eventData.position;
        LookData(moveW);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DOTween.To((float a) =>
        {
            moveW += a;
            LookData(moveW);
        }, eventData.delta.x, 0, 1f).SetEase(Ease.OutQuad).OnComplete(() =>
           {
               float x = games2[games2.Count - 1].GetComponent<RectTransform>().anchoredPosition.x;
               float d = Mathf.Sin(x / r) / (2 * Mathf.PI) * c;
               DOTween.To((float a) =>
               {
                   moveW = a;
                   LookData(moveW);
               }, moveW, moveW - d, 1f).SetEase(Ease.OutQuad).OnComplete(() =>
                 {
                     games2[games2.Count - 1].GetComponent<TableCell>().Set(lx);
                 });
           });
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
