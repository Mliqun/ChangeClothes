using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LxLztJc : LxLzt<int>
{
    public int[] brr;
    public Button btn;
    public InputField input;
    public Button[] btns;
    private void Start()
    {
        brr = new int[]{0,1,2};
        Init(brr);
        btn.onClick.AddListener(() =>
        {
            if (input.text.Length>0)
            {
                int touid = int.Parse(input.text);
                //ChangeTou(touid);
            }
        });
        for (int i = 0; i < btns.Length; i++)
        {
            int index = i;
            btns[index].GetComponent<Button>().onClick.AddListener(() =>
            {
                if (index == 0)
                {
                    ChangeSprite("tou");
                    //touid += 1;
                    //touid = touid % tou.Length;

                }
                else if (index == 1)
                {
                    ChangeSprite("hand");
                    //handid += 1;
                    //handid = handid % hand.Length;
                }
                else if (index == 2)
                {
                    ChangeSprite("body");
                    //bodyid += 1;
                    //bodyid = bodyid % body.Length;
                }
                else if (index == 3)
                {
                    ChangeSprite("leg");
                    //legid += 1;
                    //legid = legid % leg.Length;
                }
                else if (index == 4)
                {
                    ChangeSprite("weapon");
                    //int lastid = wqid;
                    //wqid += 1;
                    //wqid = wqid % 3;
                    //wqs[lastid].SetActive(false);
                    //wqs[wqid].SetActive(true);
                }
                
            });
            ChangeSprite("tou");
        }
    }

    // Start is called before the first frame update

}
