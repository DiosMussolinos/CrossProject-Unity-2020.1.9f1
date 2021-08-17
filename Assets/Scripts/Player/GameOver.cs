using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject UIGame;
    public GameObject selector;
    public Texture whiteOption;
    public Texture blackOption;

    public RawImage[] gameOverButtons;
    public Text[] gameOverText;

    private ControlAndMovement control;
    private float timeToNext = 0.0434f;
    private float timeToNextInitial = 0.0434f;

    private float[] on = { 0f, 0f, 0.05f, 0.1f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f, 0.45f, 0.50f };
    private int arrayIndex = 0;
    private int gameOverOrder = 0;
    [HideInInspector] public int options = 0;


    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<ControlAndMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameOverOrder)
        {
            case 0:
                InGame();
                break;
            case 1:
                TurnOn();
                break;
            case 2:
                GameOverPlayer();
                break;
        }
    }

    private void InGame()
    {
        if ((control.heartBeat >= 221) || (control.heartBeat <= 49))
        {
            control.interacting = true;
            UIGame.SetActive(false);
            selector.SetActive(false);
            gameOverOrder = 1;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void TurnOn()
    {
        GameObject background = gameOver.transform.GetChild(0).gameObject;
        RawImage backgroundImage = background.GetComponent<RawImage>();

            Color alphaback = backgroundImage.color;
            alphaback.a = on[arrayIndex];
            backgroundImage.color = alphaback;

        GameObject metanoia = gameOver.transform.GetChild(1).gameObject;
        RawImage metanoiaLogo = metanoia.GetComponent<RawImage>();

            Color alphaMeta = metanoiaLogo.color;
            alphaMeta.a = on[arrayIndex];
            metanoiaLogo.color = alphaMeta;

        GameObject area = gameOver.transform.GetChild(2).gameObject;
        RawImage areaRaw = area.GetComponent<RawImage>();

        Color alphaArea = areaRaw.color;
        alphaArea.a = on[arrayIndex];
        areaRaw.color = alphaArea;

        GameObject overOption1 = gameOver.transform.GetChild(3).gameObject;
        RawImage overOption11 = overOption1.GetComponent<RawImage>();

            Color alphaOp1 = overOption11.color;
            alphaOp1.a = on[arrayIndex];
            overOption11.color = alphaOp1;

        GameObject pauseOption2 = gameOver.transform.GetChild(4).gameObject;
        RawImage pauseOption21 = pauseOption2.GetComponent<RawImage>();

            Color alphaOp2 = pauseOption21.color;
            alphaOp2.a = on[arrayIndex];
            pauseOption21.color = alphaOp2;

        GameObject pauseOption1Text = gameOver.transform.GetChild(5).gameObject;
        Text pauseOption11Text = pauseOption1Text.GetComponent<Text>();

            Color alphaOpText = pauseOption11Text.color;
            alphaOpText.a = on[arrayIndex];
            pauseOption11Text.color = alphaOpText;

        GameObject pauseOption2Text = gameOver.transform.GetChild(6).gameObject;
        Text pauseOption21Text = pauseOption2Text.GetComponent<Text>();

            Color alphaOp2Text = pauseOption21Text.color;
            alphaOp2Text.a = on[arrayIndex];
            pauseOption21Text.color = alphaOp2Text;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            //Debug.Log(arrayIndex);
            arrayIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if ((arrayIndex == on.Length))
        {
            gameOver.SetActive(true);
            gameOverOrder = 2;
            arrayIndex = 0;
            Time.timeScale = 0;
        }

    }

    private void GameOverPlayer()
    {
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
        if (options > gameOverButtons.Length - 1)
        {
            options = 0;
        }
        /*BACK TO INITIAL OPTION*/

        for (int i = 0; i < gameOverButtons.Length; i++)
        {
            if (i == options)
            {
                gameOverButtons[options].texture = whiteOption;
                gameOverText[options].color = Color.white;
            }
            else
            {
                gameOverButtons[i].texture = blackOption;
                gameOverText[i].color = Color.white;
            }
        }

        //StartGame
        if ((options == 0) && (Input.GetMouseButtonDown(0)))
        {
            control.interacting = false;
            arrayIndex = 0;
            Time.timeScale = 1;
            gameOver.SetActive(false);
            SceneManager.LoadScene("Prototype");
            Cursor.lockState = CursorLockMode.Locked;
        }

        if ((options == 1) && (Input.GetMouseButtonDown(0)))
        {
            control.interacting = false;
            arrayIndex = 0;
            Time.timeScale = 1;
            gameOver.SetActive(false);
            SceneManager.LoadScene("Menus");
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
