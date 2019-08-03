using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFader : MonoBehaviour
{
    private bool _fadeIn;

    // Start is called before the first frame update
    void Start()
    {
        _fadeIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_fadeIn)
        {
         Color c =  this.GetComponent<Text>().color;
         c.a += 0.01f;
         this.GetComponent<Text>().color = c;
        }
    }


    public void FadeIn()
    {
        _fadeIn = true;
    }

}
