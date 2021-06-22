using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FlickeringEffect : MonoBehaviour
{
    public float time = 5f;

    private GameObject player;
    private GameObject cam;
    private GameObject postProcessing;
    private bool active = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = player.transform.GetChild(0).gameObject;
        postProcessing = player.transform.GetChild(2).gameObject;

    }

    private void Update()
    {
        if (active == true)
        {
            time -= Time.deltaTime;
            postProcessing.SetActive(true);
            if (time <= 0)
            {
                postProcessing.SetActive(false);
                Destroy(gameObject);
            }

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if ((collision.gameObject.tag == "Player") && (active == false))
        {
            active = true;
        }
    }

}
