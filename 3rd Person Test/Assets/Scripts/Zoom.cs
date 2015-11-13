using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(Zoom))]
public class Zoom : MonoBehaviour {

    public Camera camera;
    private float defaultFoV;
    private bool zoom = false;
    public float zoomAmount = 30.0f;
    private float xSens;
    private float ySens;
    private RigidbodyFirstPersonController controller;
    // Use this for initialization
    void Start ()
    {
        controller = gameObject.GetComponent<RigidbodyFirstPersonController>();
        defaultFoV = camera.fieldOfView;
        xSens = controller.mouseLook.XSensitivity;
        ySens = controller.mouseLook.YSensitivity;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKey(KeyCode.Z))
        {
            zoom = true;
        }
        else
        {
            zoom = false;
        }

        if(zoom)
        {
            camera.fieldOfView = defaultFoV * zoomAmount;
            controller.mouseLook.XSensitivity = xSens * zoomAmount;
            controller.mouseLook.YSensitivity = ySens * zoomAmount;
        }
        else
        {

            camera.fieldOfView = defaultFoV;
            controller.mouseLook.XSensitivity = xSens;
            controller.mouseLook.YSensitivity = ySens;
        }
	}
}
