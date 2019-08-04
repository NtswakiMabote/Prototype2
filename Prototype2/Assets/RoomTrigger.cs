using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomTrigger : MonoBehaviour
{
    public UnityEvent m_OnRoomEnter;

    // Start is called before the first frame update
    void Start()
    {
     if (m_OnRoomEnter == null)
        {
            m_OnRoomEnter = new UnityEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("FPSController"))
            m_OnRoomEnter.Invoke();
        m_OnRoomEnter = new UnityEvent();
    }
}
