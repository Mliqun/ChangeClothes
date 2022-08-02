using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    public Transform content;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <=3; i++)
        {
            UIItem item = new UIItem(content,i);
            item.SetItem(Item.CreatEntityById(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
