using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHeartbeat : MonoBehaviour
{
    //Public
    public int multiplicator = 2;
    public float[] distances;
    public float minDistance;
    public GameObject[] shadows;

    //Get
    private ControlAndMovement control;

    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<ControlAndMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < shadows.Length; i++)
        {
            distances[i] = Vector3.Distance(shadows[i].transform.position, transform.position);
            Array.Sort(distances);

            if ((distances[0] <= minDistance) || (distances[1] <= minDistance))
            {
                control.heartBeat += multiplicator * Time.deltaTime;
            }
        }
    }
}
