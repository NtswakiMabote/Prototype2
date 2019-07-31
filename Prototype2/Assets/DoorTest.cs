namespace UnityStandardAssets.Characters.FirstPerson
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    public class DoorTest : MonoBehaviour
    {

        public float cameraSensitivityOnGrab;
        public float doorOpenAngle;
        public float openSensitivity;

        public UnityEvent m_OnDoorOpen;
        public UnityEvent m_OnDoorClosed;

        private bool _openEventInvoked;
        private bool _closedEventInvoked;
        private float _originalCameraSensitivity;

        // Start is called before the first frame update
        void Start()
        {
            if (m_OnDoorOpen == null)
            {
                m_OnDoorOpen = new UnityEvent();
            }

            _openEventInvoked = false;
            _closedEventInvoked = false;

            _originalCameraSensitivity = GameObject.Find("FPSController").GetComponent<FirstPersonController>().GetMouseLook().XSensitivity;
        }

        // Update is called once per frame
        void Update()
        {
            //if (Input.GetKey(KeyCode.E))
            //{
            //    this.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
            //}


            if (_openEventInvoked == false)
            {
                if (this.transform.rotation.eulerAngles.y < doorOpenAngle)
                {
                    m_OnDoorOpen.Invoke();
                    _openEventInvoked = true;
                    _closedEventInvoked = false;
                }
            } else if (_closedEventInvoked == false)
            {
                if (this.transform.rotation.eulerAngles.y >= doorOpenAngle)
                {
                    m_OnDoorClosed.Invoke();
                    _closedEventInvoked = true;
                    _openEventInvoked = false;
                }
            }
        }

        private void OnMouseDrag()
        {

            if (Vector3.Distance(GameObject.Find("FPSController").transform.position, this.gameObject.transform.position) <= this.GetComponent<Interactable>().GetInteractDistance())
            {
                this.GetComponent<Rigidbody>().AddForce(GameObject.Find("FPSController").gameObject.transform.forward * Input.GetAxis("Mouse Y") * openSensitivity);

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
