using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nurse : MonoBehaviour
{
    public SpeechManager narrations;
    public GameObject player;
    public GameObject door;
    private bool hasExecuted;
    private SelectionRay selection;


    // Start is called before the first frame update
    void Start()
    {
        selection = player.GetComponent<SelectionRay>();
    }

    public void GoThoughSpeeches()
    {
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= 10f && !hasExecuted)
        {
            int randSpeech = Random.Range(1, 4);
            if (selection.flowersCount < 3)
            {
                narrations.TriggeredSpeech(gameObject, randSpeech);
            }
            else
            {
                narrations.TriggeredSpeech(gameObject, 5);
                Destroy(door);
            }

            hasExecuted = true;
        }
        if (Vector3.Distance(player.transform.position, gameObject.transform.position) >= 20f)
        {
            hasExecuted = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GoThoughSpeeches();
    }
}
