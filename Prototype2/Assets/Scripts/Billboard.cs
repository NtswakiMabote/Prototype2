using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {
        void Update()
        {
        transform.LookAt(2 * transform.position - GameObject.Find("InspectionCamera").transform.position);
    }
}
