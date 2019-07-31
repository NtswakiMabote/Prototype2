namespace UnityStandardAssets.Characters.FirstPerson
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MoveableItem : MonoBehaviour
    {
        public float cameraSensitivityOnGrab;
        public float openSensitivity;
        public float zLimit;

        private float _originalCameraSensitivity;
        private Vector3 _originalPos;
        private bool _canMove;

        // Start is called before the first frame update
        void Start()
        {
            _originalCameraSensitivity = GameObject.Find("FPSController").GetComponent<FirstPersonController>().GetMouseLook().XSensitivity;
            _originalPos = this.transform.position;
            _canMove = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (this.transform.position.z >= _originalPos.z + zLimit)
            {
                Debug.Log("LIMIT SHOULD BE REACHED");
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                _canMove = false;
            }
        }

        private void OnMouseDrag()
        {

            
            if (Vector3.Distance(GameObject.Find("FPSController").transform.position, this.gameObject.transform.position) <= this.GetComponent<Interactable>().GetInteractDistance())
            {
                if (_canMove)
                {
                    this.GetComponent<Rigidbody>().AddForce(GameObject.Find("FPSController").gameObject.transform.forward * Input.GetAxis("Mouse Y") * openSensitivity);
                } else
                {
                    this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }

                GameObject.Find("FPSController").GetComponent<FirstPersonController>().GetMouseLook().XSensitivity = cameraSensitivityOnGrab;
                GameObject.Find("FPSController").GetComponent<FirstPersonController>().GetMouseLook().YSensitivity = cameraSensitivityOnGrab;
            }
        }

        private void OnMouseUp()
        {
            if (Vector3.Distance(GameObject.Find("FPSController").transform.position, this.gameObject.transform.position) <= this.GetComponent<Interactable>().GetInteractDistance())
            {
                GameObject.Find("FPSController").GetComponent<FirstPersonController>().GetMouseLook().XSensitivity = _originalCameraSensitivity;
                GameObject.Find("FPSController").GetComponent<FirstPersonController>().GetMouseLook().YSensitivity = _originalCameraSensitivity;
            }
        }
    }
}
