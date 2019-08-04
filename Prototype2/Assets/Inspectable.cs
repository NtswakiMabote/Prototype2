using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inspectable : MonoBehaviour
{

    private static GameObject _currInspectable;

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
        if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Escape))
        {
            Return();
        }
    }

    private void Inspect()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        _currInspectable = this.gameObject;

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

        this.GetComponent<MeshRenderer>().enabled = false;

        GameObject.Find("CrossHair").GetComponent<Image>().enabled = false;
    }

    public void Return()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        GameObject inspectionCamera = GameObject.Find("InspectionCamera");

        inspectionCamera.GetComponent<Camera>().enabled = false;
        inspectionCamera.transform.parent = _player.transform;
        _blur.SetActive(false);
        _player.SetActive(true);

        Vector3 instantiatePos = inspectionCamera.transform.position;

        instantiatePos = inspectionCamera.transform.position + inspectionCamera.transform.forward * distanceAwayFromCamera;
        Destroy(_currInspectingObject);

        this.GetComponent<MeshRenderer>().enabled = true;

        _currInspectingObject = null;

        GameObject.Find("CrossHair").GetComponent<Image>().enabled = true;
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(GameObject.Find("FPSController").transform.position, this.gameObject.transform.position) <= this.GetComponent<Interactable>().GetInteractDistance())
        {
            Inspect();
        }
    }

    public static GameObject GetCurrInspectable()
    {
        return _currInspectable;
    }
}
