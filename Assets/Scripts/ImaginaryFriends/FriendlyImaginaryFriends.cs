using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class FriendlyImaginaryFriends : MonoBehaviour
{
    //Public
    //Sentences
    public string[] sentencesText;
    //Option Images And Text
    public RawImage[] optionsRawImages;
    public Text[] optionsText;
    public GameObject ifInteraction;
    public GameObject ifOptions;
    public Text sentenceUI;

    public RawImage IFDrawObject;
    public Texture IFDraw;

    //Item he wants + Player info + Shadow
    public Item itemRequested;
    public GameObject player;
    public GameObject Shadow;
    public GameObject ShadowSpawn;
    public State interactingState;

    //Flower
    public GameObject flower;
    public Texture selectedOption;
    public Texture notSelectedOption;

    //Private
    private SelectionRay selected;
    private ControlAndMovement control;
    private FSM fsm;

    private int waypointIndex = 0;
    private int sentenceTextIndex = 0;
    //Options related Indexes
    public int optionsIndex = 0;
    private int startIndex = 0;
    private int lastIndex = 2;
    private NavMeshAgent agent;
    private bool thisInteraction = false;



    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        fsm = GetComponent<FSM>();

        selected = player.GetComponent<SelectionRay>();

        control = player.GetComponent<ControlAndMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get boolean of interaction from Player to stop moving
        if ((fsm.currentState == interactingState) && (Input.GetKeyDown("e")))
        {
            control.interacting = true;
            thisInteraction = true;
            IFDrawObject.texture = IFDraw;
            Time.timeScale = 0;
        }

        if (thisInteraction == true)
        {
            InteractingFriendlyImaginaryFriend();
        }
    }

    private void InteractingFriendlyImaginaryFriend()
    {
        control.interacting = true;

        ifInteraction.SetActive(true);
        if ((sentenceTextIndex) == (sentencesText.Length - 1))
        {
            Request();
        }
        else
        {
            Talking();
        }
    }

    public void Request()
    {
        control.interacting = true;

        if (selected.itemColleted == null)
        {
            optionsText[0].text = "Give item (No Item)";
            optionsText[1].text = "Don't give item (No Item)";
            optionsText[2].text = "Leave";
        }
        else
        {
            optionsText[0].text = "Give item (" + selected.itemColleted.name + ")";
            optionsText[1].text = "Don't give item (" + selected.itemColleted.name + ")";
            optionsText[2].text = "Leave";
        }
        

        //Activate Options
        ifOptions.SetActive(true);

        //W & S to change optionIndex
        if (Input.GetKeyDown("w") == true)
        {
            optionsIndex -= 1;
        }
        if (Input.GetKeyDown("s") == true)
        {
            optionsIndex += 1;
        }

        //Change the color to show the option activated
        for (int i = 0; i < optionsRawImages.Length; i++)
        {
            if (i == optionsIndex)
            {
                optionsRawImages[optionsIndex].texture = selectedOption;
                optionsText[optionsIndex].color = Color.white;
            }
            else
            {
                optionsRawImages[i].texture = notSelectedOption;
                optionsText[i].color = Color.white;
            }
        }

        //Give item player has
        if ((optionsIndex == 0) && (Input.GetMouseButtonDown(0)))
        {
            //correct item to correct request
            if (itemRequested == selected.itemColleted)
            {
                selected.itemColleted = null;
                //Destroy npc
                Destroy(gameObject, 2f);
                //turn off text & image
                ifInteraction.SetActive(false);
                //turn off options
                ifOptions.SetActive(false);
                //Turn off interacting
                control.interacting = false;

                //Flower
                flower.transform.position = transform.position;
                flower.SetActive(true);
                Time.timeScale = 1;
                thisInteraction = false;
            }
            else
            {
                selected.itemColleted = null;
                //Destroy npc
                Destroy(gameObject, 2f);
                //turn on text & image
                ifInteraction.SetActive(false);
                //turn on options
                ifOptions.SetActive(false);
                //Turn off interacting
                control.interacting = false;
                //Active Shadow
                Shadow.transform.position = ShadowSpawn.transform.position;
                Shadow.SetActive(true);
                //Flower
                flower.SetActive(true);
                Time.timeScale = 1;
                thisInteraction = false;

            }
        }

        if ((optionsIndex == 1) && (Input.GetMouseButtonDown(0)))
        {
            //Destroy npc
            Destroy(gameObject, 2f);
            //turn off text & image
            ifInteraction.SetActive(false);
            //turn off options
            ifOptions.SetActive(false);
            //Turn off interacting
            control.interacting = false;
            //Active Shadow
            Shadow.SetActive(true);
            //Flower
            flower.SetActive(true);
            Time.timeScale = 1;
            thisInteraction = false;
        }

        if ((optionsIndex == 2) && (Input.GetMouseButtonDown(0)))
        {
            //turn off text & image
            ifInteraction.SetActive(false);
            //turn off options
            ifOptions.SetActive(false);
            //Turn off interacting
            control.interacting = false;
            //Return value to 0
            optionsIndex = 0;
            Time.timeScale = 1;
            thisInteraction = false;
        }

        /* BACK TO INITIAL OPTION */
        if (optionsIndex < startIndex)
        {
            optionsIndex = 2;
        }
        if (optionsIndex > lastIndex)
        {
            optionsIndex = 0;
        }
        /*BACK TO INITIAL OPTION*/
    }


    public void Talking()
    {
        // Press Left click to next sentence
        if (Input.GetMouseButtonDown(0))
        {
            sentenceTextIndex += 1;
        }
        sentenceUI.text = sentencesText[sentenceTextIndex];
    }
}