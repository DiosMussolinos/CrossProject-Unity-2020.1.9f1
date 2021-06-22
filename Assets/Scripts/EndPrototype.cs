using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPrototype : MonoBehaviour
{
    public int value;
    private GameObject player;
    private ControlAndMovement control;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        control = player.GetComponent<ControlAndMovement>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            control.endGame += value;
            Destroy(gameObject);
        }
    }

}
