using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MoveableObject : MonoBehaviour {

    public bool freezeY;
    public bool freezeX;
    public bool freezeZ;
    public bool cantMoveBack;
    public bool imposeLimit;

    private Vector3 objectPosOnScreen;
    private Vector3 offsetToMouse;
    private static bool _beingMoved;
    private Vector3 _startingPos;

    public UnityEvent m_OnMove;
    public AudioClip moveSound;
    private void Start()
    {
        _startingPos = this.transform.position;

        if (m_OnMove == null)
            m_OnMove = new UnityEvent();
    }
    void OnMouseDown()
    {
        objectPosOnScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offsetToMouse = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, objectPosOnScreen.z));
        _beingMoved = true;

        if (moveSound != null)
        {
            //AudioManager.PlaySound(moveSound, 0.1f);
        }
    }

    void OnMouseDrag()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objectPosOnScreen.z);
        Vector3 mousePosOnScreen = Camera.main.ScreenToWorldPoint(mousePos) + offsetToMouse;

        Vector3 myPos = this.transform.position;

        if (freezeX == false)
        {
            myPos.x = mousePosOnScreen.x;
        }
        if (freezeY == false)
        {
            myPos.y = mousePosOnScreen.y;
        }
        if (freezeZ == false)
        {
            if (imposeLimit)
            {
                if (mousePosOnScreen.z > -0.7f)
                {
                    myPos.z = mousePosOnScreen.z;
                }
            } else
            {
                myPos.z = mousePosOnScreen.z;
            }
        }

        if (cantMoveBack && myPos.magnitude > _startingPos.magnitude)
        {
            this.transform.position = myPos;
        }

        _beingMoved = true;
        m_OnMove.Invoke();

    }

    private void OnMouseUp()
    {
        _beingMoved = false;
    }

    public static bool IsBeingMoved()
    {
        return _beingMoved;
    }
}
