using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBeatUI : MonoBehaviour
{
    public Text heartBeat;
    public ControlAndMovement player;
    private int heartBeatInt;

    // Update is called once per frame
    void Update()
    {
        heartBeatInt = (int)(player.heartBeat);
        heartBeat.text = heartBeatInt.ToString();
    }
}
