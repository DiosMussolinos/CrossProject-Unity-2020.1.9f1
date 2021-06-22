using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    public Transform[] teleport;

    public GameObject redCandy;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //ControlAndMovement control = GetComponent<ControlAndMovement>();
            //control.interacting = true;
            transform.position = teleport[0].transform.position;
            //control.interacting = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //ControlAndMovement control = GetComponent<ControlAndMovement>();
            //control.interacting = true;
            transform.position = teleport[1].transform.position;
            //control.interacting = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(redCandy, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 1), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectionRay select = GetComponent<SelectionRay>();
            select.flowersCount = 3;
        }
    }
}
