using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float interactDistance;

    public Sprite mouseOverInteractSprite;
    public Sprite onClickInteractSprite;

    private bool _shouldHideIcon;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        if (_shouldHideIcon)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                GameObject.Find("InteractIcon").GetComponent<InteractIcon>().Hide();
                _shouldHideIcon = false;
            }
        }
    }

    private void OnMouseEnter()
    {
        if (Vector3.Distance(GameObject.Find("FPSController").transform.position, this.gameObject.transform.position) <= interactDistance)
        {
            _shouldHideIcon = false;

            InteractIcon interactIcon = GameObject.Find("InteractIcon").GetComponent<InteractIcon>();
            interactIcon.ShowIcon(mouseOverInteractSprite);
        }
    }

    private void OnMouseOver()
    {
        if (Vector3.Distance(GameObject.Find("FPSController").transform.position, this.gameObject.transform.position) <= interactDistance)
        {
            _shouldHideIcon = false;

            InteractIcon interactIcon = GameObject.Find("InteractIcon").GetComponent<InteractIcon>();
            interactIcon.ShowIcon(mouseOverInteractSprite);

            if (Input.GetKey(KeyCode.Mouse0))
            {
                interactIcon.ShowIcon(onClickInteractSprite);
            }
        }
    }

    private void OnMouseExit()
    {
        _shouldHideIcon = true;
        if (!Input.GetKey(KeyCode.Mouse0))
        {
            GameObject.Find("InteractIcon").GetComponent<InteractIcon>().Hide();
        }
    }

    public float GetInteractDistance()
    {
        return interactDistance;
    }
}
