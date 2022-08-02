using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tips 
{
    static Tips Ins;
    static Transform tips;
    static Transform content;
    static Button close;
    public static Tips Get()
    {
        if (Ins==null)
        {
            Ins = new Tips();
            tips = GameObject.Instantiate(Resources.Load<Transform>("Hint"), GameObject.Find("Canvas").transform, false);
            content = tips.Find("Scroll View/Viewport/Content");
            close = tips.Find("Close").GetComponent<Button>();
            close.onClick.AddListener(() =>
            {
                foreach (Transform item in content)
                {
                    item.gameObject.SetActive(false);
                }
                tips.gameObject.SetActive(false);
            });
        }
        return Ins;
    }
    public void Show(Item item, int id)
    {
        tips.gameObject.SetActive(true);
        int i = 0;
        foreach (var v in item.dic)
        {
            if (item.dic.Count>content.childCount)
            {
                GameObject.Instantiate(Resources.Load<GameObject>("Item"), content, false);
            }
            GameObject btn = content.GetChild(i).gameObject;
            btn.SetActive(true);
            btn.GetComponentInChildren<Text>().text = v.Value.GetName();
            btn.GetComponent<Button>().onClick.RemoveAllListeners();
            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                v.Value.Do();
            });
            i++;
        }
    }
}
