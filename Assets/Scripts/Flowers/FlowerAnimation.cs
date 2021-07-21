using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerAnimation : MonoBehaviour
{
    private GameObject player;
    private ControlAndMovement control;
    private float posX;
    private float posY;
    private float posZ;
    private float angle = 0f;
    private float speed = 0.035f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        control = player.GetComponent<ControlAndMovement>();

        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        angle += speed;


        if (angle > 360)
        {
            angle = 0;
        }

        transform.position = new Vector3(posX, posY + (Mathf.Sin(angle) /2), posZ);
        transform.Rotate(Vector3.up * 1.2f);

    }
}
