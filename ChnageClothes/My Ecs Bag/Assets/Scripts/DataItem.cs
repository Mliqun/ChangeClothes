using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

    public class DataCfg
    {
        public int id;
        public string name;
        public string icon;
        public bool isUse;
        public bool isSell;
        public bool isEquip;
        public int count;
    }
public class DataItem 
{
    public DataCfg cfg;
    public DataItem(int id)
    {
        List<DataCfg> lists = new List<DataCfg>();
        string path = Application.dataPath + "/Json/jj.json";
        string json = File.ReadAllText(path);
        lists = JsonConvert.DeserializeObject<List<DataCfg>>(json);
        cfg = new DataCfg();
        foreach (var item in lists)
        {
            if (item.id == id)
            {
                cfg = item;
                break;
            }
        }
    }
}
