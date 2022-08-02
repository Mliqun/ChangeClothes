using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShowType
{
    nullType = -1,
    bag,
    shop,
    Max,
}
public enum ComponentType
{
    nullType = -1,
    use,
    sell,
    equip,
    Max,
}
public class Item 
{
    public ShowType show = ShowType.bag;
    public DataItem data;
    public Dictionary<ComponentType, ComponentBase> dic = new Dictionary<ComponentType, ComponentBase>();

    public static Item CreatEntityById(int id)
    {
        Item item = new Item();
        item.CreateById(id);
        return item;
    }
    public void CreateById(int id,ShowType type=ShowType.bag)
    {
        show = type;
        data = new DataItem(id);
        InjectAction();
    }
    public void InjectAction()
    {
        if (data.cfg.isUse)
        {
            Use use = new Use();
            dic.Add(ComponentType.use, use);
        }
        if (data.cfg.isSell)
        {
            Sell sell = new Sell();
            dic.Add(ComponentType.sell, sell);
        }
        if (data.cfg.isEquip)
        {
            Equip equip = new Equip();
            dic.Add(ComponentType.equip, equip);
        }
    }
}
