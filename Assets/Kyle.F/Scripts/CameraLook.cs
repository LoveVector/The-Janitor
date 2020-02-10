using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    float rotX;
    float rotY;
    public float RotSpeed = 6f;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotate();
    }

    void CameraRotate()
    {
        rotX += Input.GetAxis("Mouse X") * RotSpeed;
        rotY += Input.GetAxis("Mouse Y") * RotSpeed;
        rotY = Mathf.Clamp(rotY, -90f, 90f);
        camera.transform.localRotation = Quaternion.Euler(-rotY, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, rotX, 0f);
    }
}
