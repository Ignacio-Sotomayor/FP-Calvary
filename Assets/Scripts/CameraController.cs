using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensivility = 75f;

    private Transform cameraTransform; 
    private float angleX;
    private float angleY;

    void Start()
    {
        cameraTransform = transform.Find("MainCamera").GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        var angles = transform.localEulerAngles;
        var cameraAngles = cameraTransform.localEulerAngles;

        var xAxis = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensivility;
        var yAxis = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensivility;

        angleX = Mathf.Clamp(angleX - yAxis, -20f , 45f);
        angleY += xAxis;

        angles.y = angleY;
        cameraAngles.x = angleX;

        var localEuler = Quaternion.Euler(angles);
        var cameraEuler = Quaternion.Euler(cameraAngles);

        transform.localRotation = localEuler;
        cameraTransform.localRotation = cameraEuler;

        transform.localEulerAngles = angles;
        cameraTransform.localEulerAngles = cameraAngles;

    }
}
