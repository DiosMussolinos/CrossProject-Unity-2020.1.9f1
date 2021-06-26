using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAndMovement : MonoBehaviour
{
    /////Public\\\\
    public float movementSpeed;
    public bool isCollidingWithLight;

    public Camera cam;
    //HeartBeats
    public float heartBeat = 120;
    public float multiplicator = 2;
    //Shadows
    //public
    //Increase Walls
    public GameObject[] wallsAndDoors;

    public GameObject wallExample;
    public GameObject roof;
    //Distrance from shadows
    public GameObject[] shadows;
    public GameObject catShadowPos;
    public GameObject shadowSpawn;
    public float[] distances;
    public float minDistance;
    //is interacting?
    public bool interacting = false;
    //Positions of the Camera
    public bool sawShadow;

    public bool startedGame = false;

    ////Private\\\\
    private float[] cameraYPos = new float[] {0.70f, 0.695f, 0.69f, 0.685f, 0.68f, 0.675f, 0.67f, 0.665f, 0.66f,0.655f, 0.65f, 0.645f, 0.64f, 0.635f, 0.63f,
                                              0.63f, 0.635f, 0.64f, 0.645f, 0.65f, 0.655f, 0.66f, 0.665f, 0.67f, 0.675f, 0.68f, 0.685f, 0.69f, 0.695f, 0.70f};
    //CameraYPos Index
    private int cameraIndex = 0;
    //WallMultiplication
    private float wallMultiplicator;
    //Distance Detection HeartBeats
    private float heartBeatDis;
    private bool itSpawned;
    ////Get Components\\\\
    private CharacterController controller;
    private Renderer render;

    //EndPrototype
    public int endGame = 0;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void IncreaseHeartbeat(float amount)
    {
        heartBeat += amount;
    }

    public float GetHeartBeat()
    {
        return heartBeat;
    }
    
    public float GetHeartBeatDistance()
    {
        return heartBeatDis;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Lights")
        {
            isCollidingWithLight = true;
        }

        if (col.gameObject.tag == "Spawn" && itSpawned == false)
        {  
            shadows[0].transform.position = shadowSpawn.transform.position;
            shadows[0].SetActive(true);
            itSpawned = true;
        }      
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Lights")
        {
            isCollidingWithLight = false;
        }
    }

    public bool CollidedWithLight()
    {
        return isCollidingWithLight;
    }

    //Fixed Update is better as have a smoother movement
    private void FixedUpdate()
    {
        if (interacting == false)
        {
            Control();
        }

        IncreasingHeartBeat();
        IncreasingHeartBeatDistance();
        //ShaderControl();
        //CanSeeShadow();
    }

    public void Control()
    {
            //////////Movement && And Camera Behavior\\\\\\\\\\
            float movementX = Input.GetAxis("Vertical");
            float movementZ = Input.GetAxis("Horizontal");

            //Camemra "walking"\\
            cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, cameraYPos[cameraIndex], cam.transform.localPosition.z);

            //Character Moves == Camera go Up && Down
            if (movementX != 0 || movementZ != 0)
            {
                cameraIndex += 1;
                Vector3 move = transform.forward * movementX + transform.right * movementZ;

                movementSpeed = 4 + (6 * (heartBeat / 200));

                controller.SimpleMove(move * movementSpeed);

            if (cameraIndex == cameraYPos.Length)
                {
                    cameraIndex = 0;
                }
            }
            //Camemra "walking"\\
            //////////Movement && And Camera Behavior\\\\\\\\\\
        
    }

    public void IncreasingHeartBeat()
    {
        if (CollidedWithLight())
        {
            return;
        }
        else
        {
            for (int i = 0; i < shadows.Length; i++)
            {
                distances[i] = Vector3.Distance(shadows[i].transform.position, transform.position);
                Array.Sort(distances);

                if (distances[0] <= minDistance)
                {
                    heartBeat += multiplicator * Time.deltaTime;

                    wallMultiplicator = ((heartBeat - 120) / 120) + 1.7f;
                    for(int j = 0; j < wallsAndDoors.Length; j++)
                    {
                        wallsAndDoors[j].transform.localScale = new Vector3(1, wallMultiplicator, 1);
                    }
                }
            }
        }



        float roofPos = wallExample.transform.position.y + wallExample.transform.localScale.y + 2f;
        roof.transform.position = new Vector3(roof.transform.position.x, roofPos, roof.transform.position.z);
    }

    public float IncreasingHeartBeatDistance()
    {
        heartBeatDis = heartBeat / 8;
        return heartBeatDis;
        
    }

    
    public bool CanSeeShadow()
    {
        Vector3 screenShadowPoint = cam.WorldToViewportPoint(catShadowPos.transform.position);

        bool shadowOnScreen = screenShadowPoint.z < 25f && screenShadowPoint.z > 0f && screenShadowPoint.x > -1f && screenShadowPoint.x < 1f && screenShadowPoint.y > -1 && screenShadowPoint.y < 1;

        return shadowOnScreen;
    }
    
    public bool SawShadow()
    {
        return sawShadow;
    }
}
