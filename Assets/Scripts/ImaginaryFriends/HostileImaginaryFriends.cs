using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class HostileImaginaryFriends : MonoBehaviour
{
    public SpeechManager narrations;
    //Questionaries 
    //Last one is que question
    public string[] firstQuestionary;
    public string[] optionsFirstQuestionary;
    public int answerFirstQuestionary;

    public string[] secondQuestionary;
    public string[] optionsSecondQuestionary;
    public int answerSecondQuestionary;

    public string[] thirdQuestionary;
    public string[] optionsThirdQuestionary;
    public int answerThirdQuestionary;

    public string[] FourQuestionary;
    public string[] optionsFourthQuestionary;
    public Item itemRequested;

    //Draw
    public RawImage IFDrawObject;
    public Texture IFDraw;

    //Options && Text
    public GameObject HIInteractions;
    public GameObject HIOptions;
    public RawImage[] options;
    public Text sentenceUI;
    public Text[] optionsText;

    //Objects
    public GameObject player;
    public GameObject Shadow;
    public GameObject ShadowSpawn;
    public GameObject flower;
    public State interactingState;

    public Texture selectedOption;
    public Texture notSelectedOption;

    //private && getStuff
    private NavMeshAgent agent;
    private SelectionRay selected;
    private ControlAndMovement control;
    private FSM fsm;
    //Options Index
    private int fQuestionaryIndex = 0;
    private int sQuestionaryIndex = 0;
    private int tQuestionaryIndex = 0;
    private int foQuestionaryIndex = 0;

    private bool HIOptionAndSentence = false;

    private int optionsIndex = 0;
    private int startIndex = 0;
    private int lastIndex = 2;
    private int ActiveQuestionary = 0;
    private bool thisInteraction = false;
    //Index String Index

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
        
        if ((fsm.currentState == interactingState) && (Input.GetKeyDown("e")) && (ActiveQuestionary == 0))
        {
            //narrations.TriggeredSpeech(gameObject, 1);
            control.interacting = true;
            thisInteraction = true;
            ActiveQuestionary = 1;
            IFDrawObject.texture = IFDraw;
            //Time off
            Time.timeScale = 0;

        }

        if ((fsm.currentState == interactingState) && (Input.GetKeyDown("e")))
        {
            if (ActiveQuestionary == 9)
            {
                control.interacting = true;
                HIOptionAndSentence = true;
                HIInteractions.SetActive(HIOptionAndSentence);
                //turn on options
                HIOptions.SetActive(HIOptionAndSentence);
                ActiveQuestionary = 8;
            }
            else
            {
                control.interacting = true;
                //turn on text & image
                HIInteractions.SetActive(true);
                //Turn on interacting
                control.interacting = true;
            }
        }

        switch (ActiveQuestionary)
        {
            case 0:
                break;
            case 1:
                FirstQuestionary();
                break;
            case 2:
                AnswerFirsQuestionary();
                break;
            case 3:
                SecondQuestionary();
                break;
            case 4:
                AswerSecondQuestionary();
                break;
            case 5:
                ThirdQuestionary();
                break;
            case 6:
                AswerThirdQuestionary();
                break;
            case 7:
                FourthQuestionary();
                break;
            case 8:
                AswerFourthQuestionary();
                break;
            case 9:
                TurnItAllOff();
                break;
        }
    }

    public void FirstQuestionary()
    {
        //Activate * (-1) Options
        HIOptions.SetActive(HIOptionAndSentence);
        // Press Left click to next sentence
        if (Input.GetMouseButtonDown(0))
        {
            fQuestionaryIndex += 1;
            if (fQuestionaryIndex == firstQuestionary.Length - 1)
            {
                ActiveQuestionary = 2;
            }
        }
        sentenceUI.text = firstQuestionary[fQuestionaryIndex];
    }

    public void AnswerFirsQuestionary()
    {
        HIOptionAndSentence = true;
        //Activate Options
        HIOptions.SetActive(HIOptionAndSentence);

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
        for (int i = 0; i < options.Length; i++)
        {
            optionsText[i].text = optionsFirstQuestionary[i];
            if (i == optionsIndex)
            {
                options[optionsIndex].texture = selectedOption;
                optionsText[optionsIndex].color = Color.white;
            }
            else
            {
                options[i].texture = notSelectedOption;
                optionsText[i].color = Color.white;
            }
        }

        if ((optionsIndex == answerFirstQuestionary) && (Input.GetMouseButtonDown(0)))
        {
            control.heartBeat -= 5;
            ActiveQuestionary += 1;
            optionsIndex = 0;
            HIOptions.SetActive(false);
        }
        if ((optionsIndex != answerFirstQuestionary) && (Input.GetMouseButtonDown(0)))
        {
            control.heartBeat += 10;
            ActiveQuestionary += 1;
            optionsIndex = 0;
            HIOptions.SetActive(false);
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

    public void SecondQuestionary()
    {
        HIOptions.SetActive(false);
        // Press Left click to next sentence
        if (Input.GetMouseButtonDown(0))
        {
            sQuestionaryIndex += 1;
            if (sQuestionaryIndex == secondQuestionary.Length - 1)
            {
                ActiveQuestionary += 1;
            }
        }
        sentenceUI.text = secondQuestionary[sQuestionaryIndex];
    
    }

    public void AswerSecondQuestionary()
    {
        //Activate Options
        HIOptions.SetActive(true);

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
        for (int i = 0; i < options.Length; i++)
        {
            optionsText[i].text = optionsSecondQuestionary[i];
            if (i == optionsIndex)
            {
                options[optionsIndex].texture = selectedOption;
                optionsText[optionsIndex].color = Color.white;
            }
            else
            {
                options[i].texture = notSelectedOption;
                optionsText[i].color = Color.white;
            }
        }

        if ((optionsIndex == answerSecondQuestionary) && (Input.GetMouseButtonDown(0)))
        {
            control.heartBeat -= 10;
            ActiveQuestionary = 5;
            HIOptions.SetActive(false);
            optionsIndex = 0;
        }
        if ((optionsIndex != answerSecondQuestionary) && (Input.GetMouseButtonDown(0)))
        {
            control.heartBeat += 10;
            ActiveQuestionary = 5;
            HIOptions.SetActive(false);
            optionsIndex = 0;
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

    public void ThirdQuestionary()
    {
        //Activate * (-1) Options
        HIOptions.SetActive(false);

        // Press Left click to next sentence
        if (Input.GetMouseButtonDown(0))
        {
            tQuestionaryIndex += 1;
            if (tQuestionaryIndex == thirdQuestionary.Length - 1)
            {
                ActiveQuestionary = 6;
            }
        }
        sentenceUI.text = thirdQuestionary[tQuestionaryIndex];
    }

    public void AswerThirdQuestionary()
    {
        //Activate Options
        HIOptions.SetActive(true);

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
        for (int i = 0; i < options.Length; i++)
        {
            optionsText[i].text = optionsThirdQuestionary[i];
            if (i == optionsIndex)
            {
                options[optionsIndex].texture = selectedOption;
                optionsText[optionsIndex].color = Color.white;
            }
            else
            {
                options[i].texture = notSelectedOption;
                optionsText[i].color = Color.white;
            }
        }

        if ((optionsIndex == answerThirdQuestionary) && (Input.GetMouseButtonDown(0)))
        {
            control.heartBeat -= 10;
            ActiveQuestionary = 7;
            HIOptions.SetActive(false);
            optionsIndex = 0;
        }
        if ((optionsIndex != answerThirdQuestionary) && (Input.GetMouseButtonDown(0)))
        {
            control.heartBeat += 10;
            ActiveQuestionary = 7;
            HIOptions.SetActive(false);
            optionsIndex = 0;
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

    /*            case 7:
                FourthQuestionary();
                break;
            case 8:
                AswerFourthQuestionary();
                break;
    */


    private void FourthQuestionary()
    {
        //Activate * (-1) Options
        HIOptions.SetActive(false);

        // Press Left click to next sentence
        if (Input.GetMouseButtonDown(0))
        {
            foQuestionaryIndex += 1;
            if (foQuestionaryIndex == FourQuestionary.Length - 1)
            {
                ActiveQuestionary = 8;
            }
        }
        sentenceUI.text = FourQuestionary[foQuestionaryIndex];
    }

    private void AswerFourthQuestionary()
    {
        if (selected.itemColleted == null)
        {
            optionsFourthQuestionary[0] = "Give item (No Item)";
            optionsFourthQuestionary[1] = "Don't give item (No Item)";
            optionsFourthQuestionary[2] = "Leave";
        }
        else
        {
            optionsFourthQuestionary[0] = "Give item (" + selected.itemColleted.name + ")";
            optionsFourthQuestionary[1] = "Don't give item (" + selected.itemColleted.name + ")";
            optionsFourthQuestionary[2] = "Leave";
        }

        HIOptionAndSentence = true;
        //Activate Options
        HIOptions.SetActive(HIOptionAndSentence);

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
        for (int i = 0; i < options.Length; i++)
        {
            optionsText[i].text = optionsFourthQuestionary[i];
            if (i == optionsIndex)
            {
                options[optionsIndex].texture = selectedOption;
                optionsText[optionsIndex].color = Color.white;
            }
            else
            {
                options[i].texture = notSelectedOption;
                optionsText[i].color = Color.white;
            }
        }

        //Give item player has
        if ((optionsIndex == 0) && (Input.GetMouseButtonDown(0)))
        {
            //correct item to correct request
            if (itemRequested != selected.itemColleted)
            {
                selected.itemColleted = null;
                //Destroy npc
                Destroy(gameObject, 0.5f);
                ////Consequence\\\\
                optionsIndex = 0;
                //Turn Off
                control.interacting = false;
                ActiveQuestionary = 9;
                //Flower
                flower.transform.position = transform.position;
                flower.SetActive(true);
            }
            else
            {
                selected.itemColleted = null;
                //Destroy npc
                Destroy(gameObject, 0.5f);
                //Turn Off
                control.interacting = false;
                ActiveQuestionary = 9;
                optionsIndex = 0;
                //////Consequence\\\\
                Shadow.transform.position = ShadowSpawn.transform.position;
                Shadow.SetActive(true);
                //Flower
                flower.SetActive(true);
            }
        }

        if ((optionsIndex == 1) && (Input.GetMouseButtonDown(0)))
        {
            //Destroy npc
            Destroy(gameObject, 0.5f);
            //Turn Off
            control.interacting = false;
            ActiveQuestionary = 9;
            ////Consequence\\\\
            //Active Shadow
            optionsIndex = 0;
            //Flower
            flower.transform.position = transform.position;
            flower.SetActive(true);

        }

        if ((optionsIndex == 2) && (Input.GetMouseButtonDown(0)))
        {
            //Turn off interacting
            control.interacting = false;
            ActiveQuestionary += 1;
            optionsIndex = 0;
            //Turn Off
            ActiveQuestionary = 9;
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

    private void TurnItAllOff()
    {
        //Turning time back on
        Time.timeScale = 1;
        HIOptionAndSentence = false;
        //turn off options
        HIOptions.SetActive(HIOptionAndSentence);
        //Turn off interacting
        HIInteractions.SetActive(HIOptionAndSentence);
        control.interacting = false;
    }

    
}