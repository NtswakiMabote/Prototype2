using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inspectable : MonoBehaviour
{

    public GameObject inspectableObject;
    public float distanceAwayFromCamera;

    private GameObject _player;
    private GameObject _currInspectingObject;
    private GameObject _blur;

    // Start is called before the first frame update
    void Start()
    {
        _player = null;
        _blur = GameObject.Find("InspectionCamera").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Return();
        }
    }

    private void Inspect()
    {
        GameObject inspectionCamera = GameObject.Find("InspectionCamera");

        inspectionCamera.GetComponent<Camera>().enabled = true;
        inspectionCamera.transform.parent = null;
        _blur.SetActive(true);
        _player = GameObject.Find("FPSController");
        _player.SetActive(false);

        Vector3 instantiatePos = inspectionCamera.transform.position;

        instantiatePos = inspectionCamera.transform.position + inspectionCamera.transform.forward * distanceAwayFromCamera;

        _currInspectingObject = Instantiate(inspectableObject, instantiatePos, Quaternion.identity);
        _currInspectingObject.transform.LookAt(inspectionCamera.transform.position);

        GameObject.Find("CrossHair").GetComponent<Image>().enabled = false;
    }

    private void Return()
    {
        GameObject inspectionCamera = GameObject.Find("InspectionCamera");

        inspectionCamera.GetComponent<Camera>().enabled = false;
        inspectionCamera.transform.parent = _player.transform;
        _blur.SetActive(false);
        _player.SetActive(true);

        Vector3 instantiatePos = inspectionCamera.transform.position;

        instantiatePos = inspectionCamera.transform.position + inspectionCamera.transform.forward * distanceAwayFromCamera;
        Destroy(_currInspectingObject);

        _currInspectingObject = null;
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(GameObject.Find("FPSController").transform.position, this.gameObject.transform.position) <= this.GetComponent<Interactable>().GetInteractDistance())
        {
            Inspect();
        }
    }
}
