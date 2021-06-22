using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StaticNPC : MonoBehaviour
{
    public SpeechManager narrations;
    public GameObject player;
    public int ID;
    private bool hasExecuted;
    private int speechNumber;
    private int flowers;
    public GameObject door;

    void Start()
    {
        speechNumber = 1;
        flowers = player.GetComponent<SelectionRay>().GetFlowersCount();
    }
    public void GoThoughSpeeches(int ID)
    {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= 10f && !hasExecuted)
        {
            if(ID == 1)
            {
                int randSpeech = Random.Range(1, 4);
                if (flowers < 3)
                    narrations.TriggeredSpeech(gameObject, randSpeech);
                else
                    narrations.TriggeredSpeech(gameObject, 5);
            }
            else
            {
                narrations.TriggeredSpeech(gameObject, speechNumber);
                Object.Destroy(door, 2);
            }
            hasExecuted = true;
            speechNumber += 1;

        }
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) >= 50f)
        {
            hasExecuted = false;
            narrations.StopCaptions();
        }
    }

    void Update()
    {
    }
}
