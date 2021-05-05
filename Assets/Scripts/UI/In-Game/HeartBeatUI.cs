using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBeatUI : MonoBehaviour
{
    public Text heartBeat;
    public ControlAndMovement player;

    // Update is called once per frame
    void Update()
    {
        heartBeat.text = player.heartBeat.ToString();
    }
}
