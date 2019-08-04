using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInspectionMovement : MonoBehaviour
{
    public float rotSpeed;
    private float _originalZ;

    private void Start()
    {
        _originalZ = this.transform.position.z;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
          transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")) * Time.deltaTime * rotSpeed);
            Vector3 myRot = this.transform.rotation.eulerAngles;
            myRot.z = _originalZ;
            this.transform.rotation = Quaternion.Euler(myRot);
        }
    }
}
