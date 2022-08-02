using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIItem 
{
    public Dictionary<ShowType, Action> dic;
    public Item item;
    GameObject game;
    public Text name;
    public UIItem(Transform content,int id)
    {
        game = GameObject.Instantiate(Resources.Load<GameObject>("Goods"), content, false);
        dic = new Dictionary<ShowType, Action>()
        {
            {ShowType.bag,()=>{Tips.Get().Show(item,id); } },
            {ShowType.shop,()=>{; } }
        };
        game.GetComponent<Button>().onClick.AddListener(() =>
        {
            dic[item.show].Invoke();
        });
        name = game.GetComponentInChildren<Text>();
    }
    public void SetItem(Item item)
    {
        this.item = item;
        name.text = item.data.cfg.name;
    }
}
