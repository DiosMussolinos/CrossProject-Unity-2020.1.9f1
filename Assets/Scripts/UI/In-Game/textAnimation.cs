using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textAnimation : MonoBehaviour
{
    private GameObject player;
    private ControlAndMovement control;
    private RectTransform rt;
    private float angle = 0f;
    private float width = 59.15479f;
    private float height = 30.4178f;
    private float sum = 0f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        control = player.GetComponent<ControlAndMovement>();
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        sum = control.heartBeat / 900;
        angle += sum;

        if (angle > 360)
        {
            angle = 0;
        }

        rt.sizeDelta = new Vector2(width + (Mathf.Sin(angle) * 5), height + (Mathf.Sin(angle) * 5));


    }
}
