using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janitor : MonoBehaviour
{
    public SpeechManager narrations;
    public GameObject player;
    private bool hasExecuted;
    private int speechNumber;

    public void GoThoughSpeeches()
    {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= 10f && !hasExecuted)
        {
            narrations.TriggeredSpeech(gameObject, speechNumber % 5);
            hasExecuted = true;
            speechNumber += 1;
        }

        if (Vector3.Distance(player.transform.position, gameObject.transform.position) >= 20f)
        {
            hasExecuted = false;
        }
    }

    void Start()
    {
        speechNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GoThoughSpeeches();
    }
}

