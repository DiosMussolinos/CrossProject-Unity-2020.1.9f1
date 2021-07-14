using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource source;
    private ControlAndMovement control;

    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<ControlAndMovement>();
        source = GetComponent<AudioSource>();
        source.volume = ((0.00095f * control.heartBeat * control.heartBeat) / 6.01f) - 0.0382f * control.heartBeat + 2.43f;
        source.pitch = (control.heartBeat / 400) + 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        if (control.heartBeat < 49 || control.heartBeat > 221)
        {
            source.volume = 0;
        }
        else
        {
            source.volume = ((0.00095f * control.heartBeat * control.heartBeat) / 6.01f) - 0.0382f * control.heartBeat + 2.4f;
            source.pitch = (control.heartBeat / 400) + 0.7f;
        }
    }
}
