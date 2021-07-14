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

        //\frac{0.00085x^{2}}{6.01}-0.0382x+2.65
        //((0.00095f * control.heartBeat * control.heartBeat) / 6.01f) - 0.0382f * control.heartBeat + 2.65f;

        float redColor = ((0.00095f * player.heartBeat * player.heartBeat) / 6.01f) -0.0382f * player.heartBeat + 2.65f;

        heartBeat.color = new Vector4(redColor, 0f,0f,1f);
    }
}
