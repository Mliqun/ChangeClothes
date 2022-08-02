using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class B : MonoBehaviour
{
    public GameObject[] tou;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < tou.Length; i++)
        {
            EditorUtility.SetDirty(tou[i]);
            Texture2D image = AssetPreview.GetAssetPreview(tou[i]);
            System.IO.File.WriteAllBytes(Application.dataPath + "/Resources/leg" + i+".png",image.EncodeToPNG());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
