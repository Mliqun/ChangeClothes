using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableCell: MonoBehaviour
{
    Hz3 hz;
    Hz4 hz4;
    public int id=0;
    public void Init(object obj)
    {
        hz = GameObject.Find("GameObject").GetComponent<Hz3>();
        gameObject.transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
        gameObject.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() =>
        {
            hz.touid = (int)obj;
            print(hz.touid);
            hz.Change();
        });
    }
    public void Init2(object obj)
    {
        
        id = (int)obj;
        print(id);
        string kk = ((int)obj).ToString();
        gameObject.transform.GetChild(0).GetComponent<Text>().text = kk;
        gameObject.transform.GetChild(1).GetComponent<Button>().onClick.RemoveAllListeners();
        gameObject.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() =>
        {
            print(kk);
        });
    }
    public void Set(string lx)
    {
        hz4 = GameObject.Find("GameObject").GetComponent<Hz4>();
        switch (lx)
        {
            case "tou": hz4.touid = id; hz4.Change(); break;
            case "yf": hz4.yfid = id; hz4.Change(); break;
            case "leg": hz4.legid = id; hz4.Change(); break;
            case "face": hz4.faceid = id; hz4.Change(); break;
        }
    }
    public void Ft(string lx)
    {
        string name;
        switch (lx)
        {
            case "tou":
                name = "tou" + id.ToString();
                print(name + "name");
                gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(name);
                break;
            case "yf":
                name = "yf" + id.ToString();
                gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(name); break;
            case "leg":
                name = "leg" + id.ToString();
                gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(name); break;
            case "face":
                name = "face" + id.ToString();
                gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(name); break;
        }
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
