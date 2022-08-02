using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class Wqs
{
    public string name;
    public float gj;
    public float fw;
    public float bj;
    public float sf;
    public float gs;
    public float ys;
}
public class LxLztDy : MonoBehaviour
{
    int id;
    LxHz hz;
    List<Wqs> lists = new List<Wqs>();
    LxLdt ldt;
    public void Init(object obj)
    {
        string path = Application.dataPath + "/Json/Equipment.json";
        string text=File.ReadAllText(path);
        lists = JsonConvert.DeserializeObject<List<Wqs>>(text);

        hz = GameObject.Find("Avatar").GetComponent<LxHz>();
        ldt = GameObject.Find("Canvas/Ldt/Ld").GetComponent<LxLdt>();

        id = (int)obj;
        print(id);
    }
    public void ChangeHz(string lx)
    {
        if (lx == "tou")
        {
            hz.touid = id;
        }
        else if (lx == "hand")
        {
            hz.handid = id;
        }
        else if (lx == "body")
        {
            hz.bodyid = id;
        }
        else if (lx == "leg")
        {
            hz.legid = id;
        }
        else
        {
            hz.wqid = id;
            string sxname = "wq" + id;
            foreach (var item in lists)
            {
                if (item.name==sxname)
                {
                    ldt.SetSx(item);
                }
            }
            
        }
        hz.Change();
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
