using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Direction
{
    horizontal,
    vertical
}
public class TableView<T> : MonoBehaviour
{
    RectTransform self;
    public ScrollRect scrollRect;
    public RectOffset padding;//�߾�
    public float spacing;//���
    public Direction direction = Direction.horizontal;//��������(Ĭ�Ϻ���)
    Dictionary<Rect, T> dataDic = new Dictionary<Rect, T>();//ȫ������
    Dictionary<Rect, GameObject> lookDic = new Dictionary<Rect, GameObject>();//��ʾ������
    public RectTransform tableCell;//������Ԥ����
    // Start is called before the first frame update
   public virtual void Start()
    {
        self = GetComponent<RectTransform>();
        scrollRect.content.anchorMin = new Vector2(0.5f, 0.5f);
        scrollRect.content.anchorMax = new Vector2(0.5f, 0.5f);
        scrollRect.content.pivot = new Vector2(0.5f, 0.5f);
        scrollRect.onValueChanged.AddListener((Vector2 v2) =>
        {
            LookData();
        });
    }
    public void Init(T[] arr)
    {
        Debug.Log(0);
        if (direction==Direction.horizontal)
        {
            //������=��߾�+�������ĺ�+��������ĺͣ�������������һ����+�ұ߾�
            float width = padding.left + arr.Length * (tableCell.rect.width + spacing) - spacing + padding.right;
            //����߶�=�ϱ߾�+�������+�±߾�
            float height = padding.top + tableCell.rect.height + padding.bottom;
            //�����ܿ��
            scrollRect.content.sizeDelta = new Vector2(width, height);

            //ѭ������ÿ�������������
            for (int i = 0; i < arr.Length; i++)
            {
                //����x=��߾�+i�������Ⱥͼ��+������Ŀ��һ�㣨ê��0.5��-�ܿ�ȵ�һ��
                Vector2 pos = new Vector2(padding.left + i * (tableCell.rect.width + spacing) + tableCell.rect.width / 2 - width / 2, 0);
                //��������
                Rect rect = new Rect(pos, tableCell.sizeDelta);
                dataDic.Add(rect, arr[i]);
            }
        }
        else//����
        {
            float width = padding.left + tableCell.rect.width + padding.right;
            float height = padding.top + arr.Length * (tableCell.rect.height + spacing) - spacing + padding.bottom;
            scrollRect.content.sizeDelta = new Vector2(width, height);
            for (int i = 0; i < arr.Length; i++)
            {
                Vector2 pos = new Vector2(0, padding.top + i * (tableCell.rect.height + spacing) + tableCell.rect.height / 2 - height / 2);
                Rect rect = new Rect(pos, tableCell.sizeDelta);
                dataDic.Add(rect, arr[i]);
            }
        }
        LookData();
    }
    public void LookData()
    {
        //��ȡ��ǰ��ʾ������
        Rect rect = new Rect(-scrollRect.content.anchoredPosition.x, -scrollRect.content.anchoredPosition.y, self.rect.width, self.rect.height);
        Dictionary<Rect, T> dic = new Dictionary<Rect, T>();//Ӧ��ʾ��δ��ʾ������
        //1�ҵ�Ӧ����ʾ��û��ʾ������
        //ѭ��ȫ������
        foreach (var item in dataDic)
        {
            if (IsLap(rect,item.Key))
            {
                //�ҵ�δ��ʾ������
                if (!lookDic.ContainsKey(item.Key))
                {
                    dic.Add(item.Key, item.Value);
                }
            }
        }
        //2��δ��ʾ��������ʾ����
        //ѭ��δ��ʾ������
        foreach (var item in dic)
        {
            GameObject cell = null;
            //�ж�����ʾ���Ƿ��ж����
            foreach (var look in lookDic)
            {
                //�ҵ�������ʾ���
                if (!IsLap(rect,look.Key))
                {
                    print(1111);
                    cell = look.Value;
                    cell.GetComponent<RectTransform>().anchoredPosition = new Vector2(item.Key.x, item.Key.y);
                    cell.GetComponent<TableCell>().Init(item.Value);//�����ݴ���������
                    //��gameobject��һ��keyֵ�����ֵ�
                    lookDic.Remove(look.Key);
                    lookDic.Add(item.Key, cell);
                    break;
                }
            }
            //û�ж���ľʹ���
            if (cell==null)
            {
                cell = Instantiate(tableCell.gameObject, scrollRect.content);
                cell.GetComponent<RectTransform>().anchoredPosition = new Vector2(item.Key.x, item.Key.y);
                cell.GetComponent<TableCell>().Init(item.Value);
                lookDic.Add(item.Key, cell);
            }
        }

    }
    public bool IsLap(Rect r1,Rect r2)
    {
        float r1MinX = r1.x - r1.width / 2;
        float r1MaxX = r1.x + r1.width / 2;
        float r1MinY = r1.y - r1.height / 2;
        float r1MaxY = r1.y + r1.height / 2;

        float r2MinX = r2.x - r2.width / 2;
        float r2MaxX = r2.x + r2.width / 2;
        float r2MinY = r2.y - r2.height / 2;
        float r2MaxY = r2.y + r2.height / 2;

        if (r1MinX<r2MaxX&&
            r2MinX<r1MaxX&&
            r1MinY<r2MaxY&&
            r2MinY<r1MaxY
            )
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
