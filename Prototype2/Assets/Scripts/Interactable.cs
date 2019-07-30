using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public Sprite mouseOverInteractSprite;
    public Sprite onClickInteractSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        InteractIcon interactIcon = GameObject.Find("InteractIcon").GetComponent<InteractIcon>();
        interactIcon.ShowIcon(mouseOverInteractSprite);
    }

    public void OnTriggerStay(Collider other)
    {
        InteractIcon interactIcon = GameObject.Find("InteractIcon").GetComponent<InteractIcon>();
        interactIcon.ShowIcon(mouseOverInteractSprite);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            interactIcon.ShowIcon(onClickInteractSprite);
        } 
    }

    public void OnTriggerExit(Collider other)
    {
        GameObject.Find("InteractIcon").GetComponent<InteractIcon>().Hide();
    }
}
