using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    public RigidbodyFirstPersonController fpsController;
    public Camera fpsCamera;
    public float zoomInFOV = 25;
    public float zoomOutFOV = 70;
    public bool zoomedInToggle = false;

    void Start()
    {
        //fpsController = GetComponent<RigidbodyFirstPersonController>();
        //field_Of_View = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && Input.GetKey(KeyCode.Mouse1))
        {
            zoomedInToggle = true;
            if (zoomedInToggle == true)
            {
                fpsCamera.fieldOfView = zoomInFOV;
                fpsController.mouseLook.XSensitivity = 0.5f;
                fpsController.mouseLook.YSensitivity = 0.5f;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) 
        {
            zoomedInToggle = false;
            if (zoomedInToggle == false)
            {
                fpsCamera.fieldOfView = zoomOutFOV;
                fpsController.mouseLook.XSensitivity = 2f;
                fpsController.mouseLook.YSensitivity = 2f;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            zoomedInToggle = true;
            fpsCamera.fieldOfView = zoomInFOV;
            fpsController.mouseLook.XSensitivity = 0.5f;
            fpsController.mouseLook.YSensitivity = 0.5f;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            zoomedInToggle = false;
            fpsCamera.fieldOfView = zoomOutFOV;
            fpsController.mouseLook.XSensitivity = 2f;
            fpsController.mouseLook.YSensitivity = 2f;
        }
    }
}