using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractIcon : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowIcon(Sprite s)
    {
        Image myImage = this.GetComponent<Image>();
        myImage.sprite = s;
        myImage.enabled = true;
    }

    public void ChangeIcon(Sprite s)
    {
        this.GetComponent<Image>().sprite = s;
    }

    public void Hide()
    {
        this.GetComponent<Image>().enabled = false;
    }
}
