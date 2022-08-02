using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableStart :TableView<int>
{
    public override void Start()
    {

        base.Start();
        int[] a = { 0,1, 2, 3, 4, 5,6 };
        Init(a);


    }
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        
    }
}
