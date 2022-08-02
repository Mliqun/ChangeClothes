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
        Debug.Log("ʹ����Ʒ");
    }
    public override string GetName()
    {
        return "ʹ��";
    }
}public class Sell:ComponentBase
{
    public override void Do()
    {
        base.Do();
        Debug.Log("������Ʒ");
    }
    public override string GetName()
    {
        return "����";
    }
}public class Equip:ComponentBase
{
    public override void Do()
    {
        base.Do();
        Debug.Log("װ����Ʒ");
    }
    public override string GetName()
    {
        return "װ��";
    }
}

