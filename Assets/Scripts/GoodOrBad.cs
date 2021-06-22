using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoodOrBad : MonoBehaviour
{
    private GameObject player;
    private ControlAndMovement control;
    private EndGame endGame;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        control = player.GetComponent<ControlAndMovement>();
        endGame = player.GetComponent<EndGame>();
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            control.interacting = true;
            endGame.end = true;
        }
    }
}
