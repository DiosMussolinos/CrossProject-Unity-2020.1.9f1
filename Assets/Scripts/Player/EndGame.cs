using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    
    public GameObject goodEnd;
    public GameObject badEnd;
    public RawImage[] endGoodButtons;
    public RawImage[] endBadButtons;
    public Texture seledted;
    public Texture notSelected;
    public bool end;

    private int options = 0;
    private ControlAndMovement control;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Print");
        control = GetComponent<ControlAndMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (end == true)
        {
            if (control.endGame >= 0)
            {   
                goodEnd.SetActive(true);
            }
            else
            {
                badEnd.SetActive(false);
            }

            //W & S to change optionIndex
            if (Input.GetKeyDown("w"))
            {
                options -= 1;
            }
            if (Input.GetKeyDown("s"))
            {
                options += 1;
            }

            /* BACK TO INITIAL OPTION */
            if (options < 0)
            {
                options = 3;
            }
            if (options > endGoodButtons.Length - 1 || options > endBadButtons.Length - 1)
            {
                options = 0;
            }
            /*BACK TO INITIAL OPTION*/

            for (int i = 0; i < endBadButtons.Length; i++)
            {
                if (i == options)
                {
                    endBadButtons[options].texture = seledted;
                    endGoodButtons[options].texture = seledted;
                }
                else
                {
                    endBadButtons[i].texture = notSelected;
                    endGoodButtons[i].texture = notSelected;
                }
            }

            if ((options == 0) && (Input.GetMouseButtonDown(0)))
            {
                SceneManager.LoadScene("Menus");
            }

            if ((options == 1) && (Input.GetMouseButtonDown(0)))
            {
                Application.Quit();
            }

        }

    }
}
