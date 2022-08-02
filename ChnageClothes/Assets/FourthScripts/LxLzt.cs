using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class LxLzt<T> : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    public float spading;
    public float scalMax;
    public float scalMin;
    float moveW;
    Vector2 beginPos;
    public GameObject prefab;
    float c;
    float r;
    T[] arr;
    List<GameObject> games = new List<GameObject>();
    List<Transform> games2 = new List<Transform>();
    string lx;
    public void ChangeSprite(string name)
    {
        lx = name;
        string spritename;
        for (int i = 0; i < games.Count; i++)
        {
            spritename = name + i;
            games[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(spritename);
        }
        
    }
    public void Init(T[]arr)
    {
        this.arr = arr;
        c = (prefab.GetComponent<RectTransform>().rect.width + spading) * arr.Length;
        r = c / (Mathf.PI * 2);
        LookData(0);
    }
    public void LookData(float moveW)
    {
        float moveAng = (moveW / c) * (Mathf.PI * 2);
        float ang = Mathf.PI * 2 / arr.Length;
        for (int i = 0; i < arr.Length; i++)
        {
            float x = Mathf.Sin(ang * i + moveAng) * r;
            float z = Mathf.Cos(ang * i + moveAng) * r+r;
            float scal = (z / (2 * r)) * (scalMax - scalMin) + scalMin;
            if (i<games.Count&&games[i]!=null)
            {
                games[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(x, 0);
                games[i].GetComponent<RectTransform>().localScale = Vector3.one * scal;
            }
            else
            {
                GameObject kk = Instantiate(prefab, transform);
                kk.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, 0);
                kk.GetComponent<RectTransform>().localScale = Vector3.one * scal;
                kk.GetComponent<LxLztDy>().Init(arr[i]);
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
        });
        for (int i = 0; i < games.Count; i++)
        {
            games2[i].SetSiblingIndex(i);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }, eventData.delta.x, 0, 1f).SetEase(Ease.InOutQuad).OnComplete(() =>
           {
               float x = games2[games2.Count - 1].GetComponent<RectTransform>().anchoredPosition.x;
               float hc = Mathf.Sin(x / r) / (Mathf.PI * 2) * c;
               DOTween.To((float a) =>
               {
                   moveW = a;
                   LookData(moveW);
               }, moveW, moveW - hc, 1f).SetEase(Ease.OutQuad).OnComplete(() =>
                 {
                     games2[games2.Count - 1].GetComponent<LxLztDy>().ChangeHz(lx);
               }
               );
           });
    }
}
