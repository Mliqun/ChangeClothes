using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class yb : MonoBehaviour
{
    public Slider slider;
    AsyncOperation async;
    float sd;
    // Start is called before the first frame update
    void Start()
    {
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;
    }
    private void FixedUpdate()
    {
        if (async.progress>=0.9f)
        {
            sd = 1;
        }
        else
        {
            sd = async.progress;
        }
        slider.value = Mathf.MoveTowards(slider.value, sd, 0.01f);
        if (slider.value>=0.99f)
        {
            async.allowSceneActivation = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
