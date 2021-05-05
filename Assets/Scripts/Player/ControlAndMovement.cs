using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAndMovement : MonoBehaviour
{

    /////Public\\\\
    public float movementSpeed = 8f;
    public int heartBeat = 120;
    public Camera cam;

    //is interacting?
    public bool interacting = false;

    ////Private\\\\
    //Positions of the Camera
    private float[] cameraYPos = new float[] {0.70f, 0.69f, 0.68f, 0.67f, 0.66f, 0.65f, 0.64f, 0.63f, 0.62f, 0.61f, 0.60f, 0.61f, 0.62f, 0.63f, 0.64f, 0.65f, 0.66f, 0.67f, 0.68f, 0.69f, 0.70f};
    //CameraYPos Index
    private int cameraIndex = 0;

   

    ////Get Components\\\\
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();   
    }


    //Fixed Update is better as have a smoother movement
    private void FixedUpdate()
    {
        if (interacting == false) {

            //////////Movement && And Camera Behavior\\\\\\\\\\
            float movementX = Input.GetAxis("Vertical");
            float movementZ = Input.GetAxis("Horizontal");

            Vector3 move = transform.forward * movementX + transform.right * movementZ;

            controller.SimpleMove(move * movementSpeed);

            //Camemra "walking"\\
            cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, cameraYPos[cameraIndex], cam.transform.localPosition.z);

            //Character Moves == Camera go Up && Down
            if (movementX != 0 || movementZ != 0)
            {
                cameraIndex += 1;

                if (cameraIndex == cameraYPos.Length)
                {
                    cameraIndex = 0;
                }

            }
            //Camemra "walking"\\
            //////////Movement && And Camera Behavior\\\\\\\\\\
        }
    }

}
