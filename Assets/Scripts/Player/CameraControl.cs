using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    //Public Variables
    public float mouseSense = 100f;
    public Transform player;

    //Private Variables
    private float cameraRotation;

    // Start is called before the first frame update
    void Start()
    {
        //Mouse stuck and invisible in the center of the screen
        //Want to use the mouse? Press Esc and you can see it
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSense;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense;

        cameraRotation -= mouseY;
        
        //cameraRotation, MaxAngle-Y, MaxAngle+Y
        cameraRotation = Mathf.Clamp(cameraRotation, -90f, 45f);

        transform.localRotation = Quaternion.Euler(cameraRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
