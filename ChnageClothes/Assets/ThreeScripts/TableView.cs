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
    public RectOffset padding;//边距
    public float spacing;//间隔
    public Direction direction = Direction.horizontal;//滚动方向(默认横向)
    Dictionary<Rect, T> dataDic = new Dictionary<Rect, T>();//全部数据
    Dictionary<Rect, GameObject> lookDic = new Dictionary<Rect, GameObject>();//显示的内容
    public RectTransform tableCell;//子物体预制体
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
            //计算宽度=左边距+子物体宽的和+子物体间距的和（间距比子物体少一个）+右边距
            float width = padding.left + arr.Length * (tableCell.rect.width + spacing) - spacing + padding.right;
            //计算高度=上边距+子物体高+下边距
            float height = padding.top + tableCell.rect.height + padding.bottom;
            //设置总宽高
            scrollRect.content.sizeDelta = new Vector2(width, height);

            //循环设置每个子物体的坐标
            for (int i = 0; i < arr.Length; i++)
            {
                //坐标x=左边距+i个物体宽度和间距+子物体的宽的一般（锚点0.5）-总宽度的一半
                Vector2 pos = new Vector2(padding.left + i * (tableCell.rect.width + spacing) + tableCell.rect.width / 2 - width / 2, 0);
                //矩形数据
                Rect rect = new Rect(pos, tableCell.sizeDelta);
                dataDic.Add(rect, arr[i]);
            }
        }
        else//纵向
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
        //获取当前显示的区域
        Rect rect = new Rect(-scrollRect.content.anchoredPosition.x, -scrollRect.content.anchoredPosition.y, self.rect.width, self.rect.height);
        Dictionary<Rect, T> dic = new Dictionary<Rect, T>();//应显示但未显示的数据
        //1找到应该显示但没显示的数据
        //循环全部数据
        foreach (var item in dataDic)
        {
            if (IsLap(rect,item.Key))
            {
                //找到未显示的数据
                if (!lookDic.ContainsKey(item.Key))
                {
                    dic.Add(item.Key, item.Value);
                }
            }
        }
        //2将未显示的数据显示出来
        //循环未显示的数据
        foreach (var item in dic)
        {
            GameObject cell = null;
            //判断已显示的是否有多余的
            foreach (var look in lookDic)
            {
                //找到超出显示框的
                if (!IsLap(rect,look.Key))
                {
                    print(1111);
                    cell = look.Value;
                    cell.GetComponent<RectTransform>().anchoredPosition = new Vector2(item.Key.x, item.Key.y);
                    cell.GetComponent<TableCell>().Init(item.Value);//把数据传给子物体
                    //把gameobject换一个key值存入字典
                    lookDic.Remove(look.Key);
                    lookDic.Add(item.Key, cell);
                    break;
                }
            }
            //没有多余的就创建
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
