using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RotatableObject : MonoBehaviour {

    public bool freezeY;
    public bool freezeX;
    public bool freezeZ;
    public float rotationSensitivity;

    public UnityEvent m_OnRotate;
    public UnityEvent m_OnStopRotate;

    public AudioClip rotateSound;

    //
    private Vector3 _mousePos;
    private Vector3 _currRotation;

    private static bool _rotating;
    //

    private void Start()
    {
        _mousePos = Vector3.zero;
        _currRotation = Vector3.zero;

        if (m_OnRotate == null)
            m_OnRotate = new UnityEvent();

        if (m_OnStopRotate == null)
            m_OnStopRotate = new UnityEvent();
    }

    void OnMouseDown()
    {
            _rotating = true;

        //if (rotateSound!=null)
        //{
        //    AudioManager.PlaySound(rotateSound, 0.3f);
        //}
       Debug.Log("MOUSE CLICK ACKNOWLEDGED ON ROTATING OBJECT");
    }

    void OnMouseDrag()
    {

        if (_rotating)
        {
            Vector3 offset = (Input.mousePosition - _mousePos);
            if (freezeY == false)
            {
                _currRotation.y = -(offset.x + offset.y) * rotationSensitivity;
            }

            if (freezeX == false)
            {
                _currRotation.x = -(offset.x + offset.y) * rotationSensitivity;
            }

            if (freezeZ == false)
            {
                _currRotation.z = -(offset.x + offset.y) * rotationSensitivity;
            }

            transform.Rotate(_currRotation);
            _mousePos = Input.mousePosition;
            m_OnRotate.Invoke();
        }
    }

    private void OnMouseUp()
    {
        _rotating = false;
        m_OnStopRotate.Invoke();
    }

    public static bool IsBeingMoved()
    {
        return _rotating;
    }
}
