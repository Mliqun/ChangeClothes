using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ComponentBase 
{
    public virtual void Do()
    {
        
    }
    public abstract string GetName();
}
public class Use:ComponentBase
{
    public override void Do()
    {
        base.Do();
        Debug.Log("使用物品");
    }
    public override string GetName()
    {
        return "使用";
    }
}public class Sell:ComponentBase
{
    public override void Do()
    {
        base.Do();
        Debug.Log("出售物品");
    }
    public override string GetName()
    {
        return "出售";
    }
}public class Equip:ComponentBase
{
    public override void Do()
    {
        base.Do();
        Debug.Log("装备物品");
    }
    public override string GetName()
    {
        return "装备";
    }
}

