/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCast : MonoBehaviour
{
    public GameObject[] shadows;
    private GameObject player;
    private ControlAndMovement control;

    private bool hitPlayer;
    private bool hitShadow;

    private void Awake()
    {
       
        shadows = GameObject.FindGameObjectsWithTag("Shadow");
  
    }

    // Start is called before the first frame update
    void Start()
    {
        shadows = GameObject.FindGameObjectsWithTag("Shadow");
        player = GameObject.FindGameObjectWithTag("Player");
        control = player.GetComponent<ControlAndMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        float closestDistance = Mathf.Infinity;
        int closesShadowId = 0;

        for (int i = 0; i < shadows.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, shadows[i].transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closesShadowId = i;
            }
        }

        Vector3 destiny = shadows[closesShadowId].transform.position;

        if (Physics.Linecast(transform.position, player.transform.position, out RaycastHit playerHit))
        {
            if (playerHit.collider.gameObject.CompareTag("Player"))
            {
                hitPlayer = true;
            }
        }

        if (Physics.Linecast(transform.position, destiny, out RaycastHit shadowHit))
        {
            if (shadowHit.collider.gameObject.CompareTag("Shadow"))
            {
                hitShadow = true;
            }
        }

        if (hitShadow == true && hitPlayer == true)
        {
            control.CanSeeShadow();
        }
        Debug.DrawLine(transform.position, player.transform.position);
        Debug.DrawLine(transform.position, destiny);
        Debug.Log(hitShadow);
        Debug.Log(hitPlayer);

    }
}*/
