using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndGame : MonoBehaviour
{

    public GameObject goodEnd;
    public GameObject badEnd;
    public GameObject uiInGame;
    public RawImage[] endGoodButtons;
    public RawImage[] endBadButtons;
    public Texture seledted;
    public Texture notSelected;

    public RawImage background;

    [HideInInspector]
    public int end = 0;

    public RawImage cutScene;
    public RawImage escape;

    private VideoPlayer video;
    private float videoLenght = 5.8f;
    [HideInInspector] public int options = 0;
    private ControlAndMovement control;
    private PauseMenu pause;


    private float[] turnOnAnimation = {0f, 0f, 0f, 0f, 0.05f, 0.1f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f, 0.45f,0.5f, 0.55f,
                                             0.6f, 0.65f, 0.7f, 0.75f, 0.8f, 0.85f,0.9f, 0.95f, 1f, 1f, 1f, 1f};
    private int animationIndex = 0;
    private float timeToNext = 0.0434f;
    private float timeToNextInitial = 0.0434f;


    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<ControlAndMovement>();
        pause = GetComponent<PauseMenu>();
        video = GameObject.FindGameObjectWithTag("VideoPlayer").GetComponent<VideoPlayer>();
        video.enabled = false;
        cutScene.enabled = false;
        //escape.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (end)
        {
            case 1:
                Fade();
                break;
            case 2:
                Cinematic();
                break;
            case 3:
                EndOptions();
                break;
        }
    }

    private void Fade()
    {
        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;

            if (animationIndex == turnOnAnimation.Length - 1)
            {
                end = 2;
                timeToNext = timeToNextInitial;
            }
        }

        Color alphaBack = background.color;
        alphaBack.a = turnOnAnimation[animationIndex];
        background.color = alphaBack;

    }

    public void Cinematic()
    {
        uiInGame.SetActive(false);

        background.enabled = false;
        escape.enabled = true;
        
        videoLenght -= Time.deltaTime;
        cutScene.enabled = true;
        video.enabled = true;
        video.Play();

        if (videoLenght <= 0)
        {
            cutScene.color = new Vector4(1f, 1f, 1f, 0.1f);
            end = 3;
        }
    }

    private void EndOptions()
    {
        escape.enabled = false;

        if (control.endGame >= 0)
        {
            goodEnd.SetActive(true);
        }
        else
        {
            badEnd.SetActive(true);
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
