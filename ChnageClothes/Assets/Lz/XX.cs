using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XX : Rotaryfigure3<int>
{

    public Button toubtn;
    public Button yfbtn;
    public Button legbtn;
    public Button facebtn;
    public InputField input;
    public Button btn;
    private void Start()
    {
        int[] arr = { 0, 1, 2, 3 };
        Init("tou", arr);
        toubtn.onClick.AddListener(() =>
        {
            Init("tou", arr);
        });
        yfbtn.onClick.AddListener(() =>
        {
            Init("yf", arr);
        });
        legbtn.onClick.AddListener(() =>
        {
            Init("leg", arr);
        });
        facebtn.onClick.AddListener(() =>
        {
            Init("face", arr);
        });
        
            btn.onClick.AddListener(() =>
            {
                if (input.text.Length > 0)
                {
                    int k=int.Parse(input.text);
                    Autorotation(k);
                }
            });
    }
}
