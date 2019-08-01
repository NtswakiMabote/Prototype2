using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInspectionMovement : MonoBehaviour
{
    public float rotSpeed;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotSpeed);
        }
    }
}
