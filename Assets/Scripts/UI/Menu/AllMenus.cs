using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Camera))]
public class AllMenus : MonoBehaviour
{
    public GameObject headPhones;
    public GameObject warning;
    public GameObject autoSave;
    public GameObject blink;
    public GameObject pressStartEmpty;
    public GameObject pressAnyButtonToStart;
    public GameObject mainMenu;
    public GameObject playMenu;
    public GameObject loadMenu;
    public GameObject creditMenu;
    public GameObject optionsMenu;
    public GameObject soundMenu;
    public GameObject controlMenu;
    public GameObject graphicsMenu;
    public GameObject gameplayMenu;


    public RawImage[] mainMenuButtons;
    public Text[] mainMenuText;

    public RawImage[] playMenuButtons;
    public Text[] playMenuText;

    public RawImage[] optionsImageMenu;
    public Text[] optionsTextMenu;

    public RawImage[] gameplayImageMenu;
    public Text[] gameplayTextMenu;

    public Text[] gameplayOptions;

    public RawImage[] SoundMenuOptions;

    public RawImage[] graphicsMenuOptions;
    public Text graphicsMenuText;

    public Texture menuButtonWhite;
    public Texture menuButtonNormal;

    public Texture[] eyeAnimation;

    public GameObject player;
    private ControlAndMovement control;

    private int menuScreenIndex = 0;
    private int menuOptionIndex = 0;
    private int animationIndex = 0;
    private int difficultyIndex = 1;
    private int subtitlesIndex = 0;


    private float timeNextAnimation = 0.3333f;
    private float timeNextAnimationInitial = 0.3333f;
    private int blinkanimationIndex = 0;

    private float timeToNext = 0.0434f;
    private float timeToNextInitial = 0.0434f;

    private float readingTime = 3f;
    private float readingTimeInitial = 2f;

    private bool blinking = false;
    //Bools of the menu
    private bool turnOn = false;
    private bool turnOff = false;

    private bool mainMenuBool = true;
    private bool optionsBool = false;
    private bool soundBool = false;
    private bool controlBool = false;
    private bool graphicsBool = false;
    private bool gamePlayBool = false;
    private bool backBool = false;
    private bool playGameBool = false;
    private bool playDemoBool = false;
    private bool loadGame = false;
    private bool started = false;

    private bool creditsBool = false;

    private float[] blinkingAnimation = {0f, 0f, 0f, 0f, 0.05f, 0.1f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f, 0.45f,0.5f, 0.55f,
                                            0.6f, 0.65f, 0.7f, 0.75f, 0.8f, 0.85f,0.9f, 0.95f,1f,
                                            0.95f, 0.90f, 0.85f, 0.80f, 0.75f, 0.7f, 0.65f, 0.6f, 0.55f, 0.5f,
                                            0.45f, 0.40f, 0.35f, 0.3f, 0.25f,0.20f, 0.15f,0.10f,0.05f, 0f, 0f, 0f, 0f};

    private float[] turnOnAnimation = {0f, 0f, 0f, 0f, 0.05f, 0.1f, 0.15f, 0.2f, 0.25f, 0.3f, 0.35f, 0.4f, 0.45f,0.5f, 0.55f,
                                             0.6f, 0.65f, 0.7f, 0.75f, 0.8f, 0.85f,0.9f, 0.95f, 1f, 1f, 1f, 1f};

    private float[] turnOffAnimation = {1f, 1f, 0.95f, 0.90f, 0.85f, 0.80f, 0.75f, 0.7f, 0.65f, 0.6f, 0.55f, 0.5f,
                                            0.45f, 0.40f, 0.35f, 0.3f, 0.25f,0.20f, 0.15f,0.10f,0.05f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f};

    private string[] difficulties = { "Fetus", "Child", "Puberty" };
    private string[] subtitles = { "No", "Yes" };
    private string[] inGameUI = { "Yes", "No" };

    private bool alreadyStarted = false;



    // Start is called before the first frame update
    void Start()
    {
        control = player.GetComponent<ControlAndMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(control.startedGame);

        switch (menuScreenIndex)
        {
            case 0:
                HeadPhonesOn();
                break;
            case 1:
                HeadPhonesRead();
                break;
            case 2:
                HeadPhonesOff();
                break;
            case 3:
                WarningOn();
                break;
            case 4:
                WarningRead();
                break;
            case 5:
                WarningOff();
                break;
            case 6:
                AutoSaveOn();
                break;
            case 7:
                AutoSaveRead();
                break;
            case 8:
                AutoSaveOff();
                break;
            case 9:
                BlikingEyeOn();
                break;
            case 10:
                BlinkingEyeAnimation();
                break;
            case 11:
                BlikingEyeOff();
                break;
            case 12:
                AnyButtonOn();
                break;
            case 13:
                AnyButton();
                break;
            case 14:
                AnyButtonOff();
                break;
            case 15:
                MainMenuOn();
                break;
            case 16:
                MainMenu();
                break;
            case 17:
                MainMenuOff();
                break;
            case 18:
                CreditsMenuOn();
                break;
            case 19:
                CreditsMenu();
                break;
            case 20:
                CreditsMenuOff();
                break;
            case 21:
                OptionsMenuOn();
                break;
            case 22:
                OptionsMenu();
                break;
            case 23:
                OptionsMenuOff();
                break;
            case 24:
                SoundMenuOn();
                break;
            case 25:
                SoundMenu();
                break;
            case 26:
                SoundMenuOff();
                break;
            case 27:
                ControlsMenuOn();
                break;
            case 28:
                ControlsMenu();
                break;
            case 29:
                ControlsMenuOff();
                break;
            case 30:
                GraphicsMenuOn();
                break;
            case 31:
                GraphicsMenu();
                break;
            case 32:
                GraphicsMenuOff();
                break;
            case 33:
                GamePlayOn();
                break;
            case 34:
                GamePlay();
                break;
            case 35:
                GamePlayOff();
                break;
            case 36:
                PlayOn();
                break;
            case 37:
                Play();
                break;
            case 38:
                PlayOff();
                break;
            case 39:
                LoadGameOn();
                break;
            case 40:
                LoadGame();
                break;
            case 41:
                LoadGameOff();
                break;
        }
    }

    private void HeadPhonesOn()
    {
        if (control.startedGame == true)
        {
            menuScreenIndex = 15;
        }
        ////////HeadPhone
        GameObject headphone = headPhones.transform.GetChild(0).gameObject;
        RawImage headphoneRaw = headphone.GetComponent<RawImage>();

        Color alphaPhone = headphoneRaw.color;
        alphaPhone.a = turnOnAnimation[animationIndex];
        headphoneRaw.color = alphaPhone;

        ////////Text
        GameObject headPhoneText = headPhones.transform.GetChild(1).gameObject;
        Text headPhoneTextRaw = headPhoneText.GetComponent<Text>();

        Color alphaText = headPhoneTextRaw.color;
        alphaText.a = turnOnAnimation[animationIndex];
        headPhoneTextRaw.color = alphaText;

        timeToNext -= Time.deltaTime;
        if (timeToNext <= 0)
        {
            animationIndex++;

            if (animationIndex == turnOnAnimation.Length - 1)
            {
                menuScreenIndex = 1;
                animationIndex = 0;
                timeToNext = timeToNextInitial;
            }
        }
    }

    private void HeadPhonesRead()
    {
        readingTime -= Time.deltaTime;

        if ((readingTime <= 0) || (Input.GetMouseButtonDown(0)))
        {
            menuScreenIndex = 2;
            animationIndex = 0;
            readingTime = readingTimeInitial;
        }
    }

    private void HeadPhonesOff()
    {
        ////////HeadPhone
        GameObject headphone = headPhones.transform.GetChild(0).gameObject;
        RawImage headphoneRaw = headphone.GetComponent<RawImage>();

        Color alphaPhone = headphoneRaw.color;
        alphaPhone.a = turnOffAnimation[animationIndex];
        headphoneRaw.color = alphaPhone;

        ////////Text
        GameObject headPhoneText = headPhones.transform.GetChild(1).gameObject;
        Text headPhoneTextRaw = headPhoneText.GetComponent<Text>();

        Color alphaText = headPhoneTextRaw.color;
        alphaText.a = turnOffAnimation[animationIndex];
        headPhoneTextRaw.color = alphaText;

        timeToNext -= Time.deltaTime;
        if (timeToNext <= 0)
        {
            animationIndex++;

            if (animationIndex == turnOffAnimation.Length - 1)
            {
                menuScreenIndex = 3;
                animationIndex = 0;

                timeToNext = timeToNextInitial;

            }
        }
    }

    private void WarningOn()
    {
        GameObject warningImage = warning.transform.GetChild(0).gameObject;
        RawImage warningRaw = warningImage.GetComponent<RawImage>();

        Color alphaWarning = warningRaw.color;
        alphaWarning.a = turnOnAnimation[animationIndex];
        warningRaw.color = alphaWarning;

        GameObject warningText = warning.transform.GetChild(1).gameObject;
        Text warningTextRaw = warningText.GetComponent<Text>();

        Color alphaText = warningTextRaw.color;
        alphaText.a = turnOnAnimation[animationIndex];
        warningTextRaw.color = alphaText;

        timeToNext -= Time.deltaTime;
        if (timeToNext <= 0)
        {
            animationIndex++;

            if (animationIndex == turnOnAnimation.Length - 1)
            {
                menuScreenIndex = 4;
                animationIndex = 0;
                timeToNext = timeToNextInitial;
            }
        }
    }

    private void WarningRead()
    {
        readingTime -= Time.deltaTime;

        if ((readingTime <= 0) || (Input.GetMouseButtonDown(0)))
        {
            menuScreenIndex = 5;
            readingTime = readingTimeInitial;
        }
    }

    private void WarningOff()
    {
        GameObject warningImage = warning.transform.GetChild(0).gameObject;
        RawImage warningRaw = warningImage.GetComponent<RawImage>();

        Color alphaWarning = warningRaw.color;
        alphaWarning.a = turnOffAnimation[animationIndex];
        warningRaw.color = alphaWarning;

        GameObject warningText = warning.transform.GetChild(1).gameObject;
        Text warningTextRaw = warningText.GetComponent<Text>();

        Color alphaText = warningTextRaw.color;
        alphaText.a = turnOffAnimation[animationIndex];
        warningTextRaw.color = alphaText;

        timeToNext -= Time.deltaTime;
        if (timeToNext <= 0)
        {
            animationIndex++;

            if (animationIndex == turnOnAnimation.Length - 1)
            {
                menuScreenIndex = 6;
                animationIndex = 0;
                timeToNext = timeToNextInitial;

            }
        }
    }

    private void AutoSaveOn()
    {
        GameObject saveImage = autoSave.transform.GetChild(0).gameObject;
        RawImage saveImageRaw = saveImage.GetComponent<RawImage>();

        Color alphaSaveImage = saveImageRaw.color;
        alphaSaveImage.a = turnOnAnimation[animationIndex];
        saveImageRaw.color = alphaSaveImage;

        GameObject saveText = autoSave.transform.GetChild(1).gameObject;
        Text saveTextRaw = saveText.GetComponent<Text>();

        Color alphaText = saveTextRaw.color;
        alphaText.a = turnOnAnimation[animationIndex];
        saveTextRaw.color = alphaText;

        timeToNext -= Time.deltaTime;
        if (timeToNext <= 0)
        {
            animationIndex++;

            if (animationIndex == turnOnAnimation.Length - 1)
            {
                menuScreenIndex = 7;
                animationIndex = 0;
                timeToNext = timeToNextInitial;
            }
        }
    }

    private void AutoSaveRead()
    {
        readingTime -= Time.deltaTime;

        if ((readingTime <= 0) || (Input.GetMouseButtonDown(0)))
        {
            menuScreenIndex = 8;
            readingTime = readingTimeInitial;
        }
    }

    private void AutoSaveOff()
    {
        GameObject saveImage = autoSave.transform.GetChild(0).gameObject;
        RawImage saveImageRaw = saveImage.GetComponent<RawImage>();

        Color alphaSaveImage = saveImageRaw.color;
        alphaSaveImage.a = turnOffAnimation[animationIndex];
        saveImageRaw.color = alphaSaveImage;

        GameObject saveText = autoSave.transform.GetChild(1).gameObject;
        Text saveTextRaw = saveText.GetComponent<Text>();

        Color alphaText = saveTextRaw.color;
        alphaText.a = turnOffAnimation[animationIndex];
        saveTextRaw.color = alphaText;

        timeToNext -= Time.deltaTime;
        if (timeToNext <= 0)
        {
            animationIndex++;

            if (animationIndex == turnOnAnimation.Length - 1)
            {
                menuScreenIndex = 9;
                animationIndex = 0;
                timeToNext = timeToNextInitial;

            }
        }
    }

    private void BlikingEyeOn()
    {
        GameObject blickEye = blink.transform.GetChild(0).gameObject;
        RawImage blickEyeRaw = blickEye.GetComponent<RawImage>();

        Color alpha = blickEyeRaw.color;
        alpha.a = turnOnAnimation[animationIndex];
        blickEyeRaw.color = alpha;

        timeToNext -= Time.deltaTime;
        if (timeToNext <= 0)
        {
            animationIndex++;

            if (animationIndex == turnOnAnimation.Length - 1)
            {
                menuScreenIndex = 10;
                animationIndex = 0;
                timeToNext = timeToNextInitial;
            }

        }
    }

    private void BlinkingEyeAnimation()
    {
        GameObject blickEye = blink.transform.GetChild(0).gameObject;
        RawImage blickEyeRaw = blickEye.GetComponent<RawImage>();

        blickEyeRaw.texture = eyeAnimation[blinkanimationIndex];

        readingTime -= Time.deltaTime;

        if (readingTime <= 0)
        {
            menuScreenIndex = 11;
            readingTime = readingTimeInitial;
        }
        else
        {
            timeNextAnimation -= Time.deltaTime;

            if (timeNextAnimation <= 0)
            {

                blinkanimationIndex++;
                timeNextAnimation = timeNextAnimationInitial;
            }
            if (blinkanimationIndex == eyeAnimation.Length)
            {
                blinkanimationIndex = 0;
            }
        }
    }

    private void BlikingEyeOff()
    {
        GameObject blickEye = blink.transform.GetChild(0).gameObject;
        RawImage blickEyeRaw = blickEye.GetComponent<RawImage>();

        Color alpha = blickEyeRaw.color;
        alpha.a = turnOffAnimation[animationIndex];
        blickEyeRaw.color = alpha;

        timeToNext -= Time.deltaTime;
        if (timeToNext <= 0)
        {
            animationIndex++;

            if (animationIndex == turnOnAnimation.Length - 1)
            {
                menuScreenIndex = 12;
                animationIndex = 0;
                timeToNext = timeToNextInitial;

            }

        }
    }

    private void AnyButtonOn()
    {
        GameObject background = pressStartEmpty.transform.GetChild(1).gameObject;
        RawImage rawBackground = background.GetComponent<RawImage>();

        Color alphaBack = rawBackground.color;
        alphaBack.a = turnOnAnimation[animationIndex];
        rawBackground.color = alphaBack;

        GameObject logo = pressStartEmpty.transform.GetChild(2).gameObject;
        RawImage rawLogo = logo.GetComponent<RawImage>();

        Color alphalogo = rawLogo.color;
        alphalogo.a = turnOnAnimation[animationIndex];
        rawLogo.color = alphalogo;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == turnOnAnimation.Length - 1)
        {
            menuScreenIndex = 13;
            animationIndex = 0;
            timeToNext = timeToNextInitial;
        }
    }

    private void AnyButton()
    {
        RawImage rawPress = pressAnyButtonToStart.GetComponent<RawImage>();

        Color alpha = rawPress.color;
        alpha.a = blinkingAnimation[animationIndex];
        rawPress.color = alpha;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == blinkingAnimation.Length - 1)
        {
            animationIndex = 0;
        }

        if (Input.anyKey)
        {
            menuScreenIndex = 14;
            turnOff = true;
            animationIndex = 0;
        }
    }

    private void AnyButtonOff()
    {
        GameObject background = pressStartEmpty.transform.GetChild(1).gameObject;
        RawImage rawBackground = background.GetComponent<RawImage>();

        Color alphaBack = rawBackground.color;
        alphaBack.a = turnOffAnimation[animationIndex];
        rawBackground.color = alphaBack;

        GameObject logo = pressStartEmpty.transform.GetChild(2).gameObject;
        RawImage rawLogo = logo.GetComponent<RawImage>();

        Color alphalogo = rawLogo.color;
        alphalogo.a = turnOffAnimation[animationIndex];
        rawLogo.color = alphalogo;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == turnOffAnimation.Length - 1)
        {
            animationIndex = 0;
            menuScreenIndex = 15;
            timeToNext = timeToNextInitial;
        }
    }

    private void MainMenuOn()
    {
        ////////Logo
        GameObject logo = mainMenu.transform.GetChild(0).gameObject;
        RawImage logoRaw = logo.GetComponent<RawImage>();

            Color alphaLogo = logoRaw.color;
            alphaLogo.a = turnOnAnimation[animationIndex];
            logoRaw.color = alphaLogo;

        ////////Button Start
        GameObject start = mainMenu.transform.GetChild(1).gameObject;
        RawImage startRaw = start.GetComponent<RawImage>();

            Color alphaStart = startRaw.color;
            alphaStart.a = turnOnAnimation[animationIndex];
            startRaw.color = alphaStart;

        //Text Start
        GameObject startTextGameObject = start.transform.GetChild(0).gameObject;
        Text startText = startTextGameObject.GetComponent<Text>();

            Color alphaStartText = startText.color;
            alphaStartText.a = turnOnAnimation[animationIndex];
            startText.color = alphaStartText;

        //Button Options
        GameObject optionsGameObject = mainMenu.transform.GetChild(2).gameObject;
        RawImage optionsraw = optionsGameObject.GetComponent<RawImage>();

            Color alphaOptions = optionsraw.color;
            alphaOptions.a = turnOnAnimation[animationIndex];
            optionsraw.color = alphaOptions;

        ////////Options Text
        GameObject optionsTextGameObject = optionsGameObject.transform.GetChild(0).gameObject;
        Text optionsText = optionsTextGameObject.GetComponent<Text>();

            Color alphaOptionsText = optionsText.color;
            alphaOptionsText.a = turnOnAnimation[animationIndex];
            optionsText.color = alphaOptionsText;


        //Button Credits
        GameObject creditsGameObject = mainMenu.transform.GetChild(3).gameObject;
        RawImage creditsraw = creditsGameObject.GetComponent<RawImage>();

            Color alphaCredits = creditsraw.color;
            alphaCredits.a = turnOnAnimation[animationIndex];
            creditsraw.color = alphaCredits;

        ////////Credits Text
        GameObject crecitsTextGameObject = creditsGameObject.transform.GetChild(0).gameObject;
        Text creditsText = crecitsTextGameObject.GetComponent<Text>();

            Color alphaCreditsText = creditsText.color;
            alphaCreditsText.a = turnOnAnimation[animationIndex];
            creditsText.color = alphaCreditsText;

        //Button Quit
        GameObject quit = mainMenu.transform.GetChild(4).gameObject;
        RawImage quitRaw = quit.GetComponent<RawImage>();

            Color alphaQuit = quitRaw.color;
            alphaQuit.a = turnOnAnimation[animationIndex];
            quitRaw.color = alphaQuit;

        ////////Quit Text
        GameObject quitTextGameObject = quit.transform.GetChild(0).gameObject;
        Text quitText = quitTextGameObject.GetComponent<Text>();

            Color alphaQuitText = quitText.color;
            alphaQuitText.a = turnOnAnimation[animationIndex];
            quitText.color = alphaQuitText;

        timeToNext -= Time.deltaTime;


        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if ((animationIndex == turnOnAnimation.Length - 1) && (mainMenuBool == true))
        {
            menuScreenIndex = 16;
            animationIndex = 0;
            timeToNext = timeToNextInitial;
        }
    }

    private void MainMenu()
    {
        //W & S to change optionIndex
        if (Input.GetKeyDown("w"))
        {
            menuOptionIndex -= 1;
        }
        if (Input.GetKeyDown("s"))
        {
            menuOptionIndex += 1;
        }

        /* BACK TO INITIAL OPTION */
        if (menuOptionIndex < 0)
        {
            menuOptionIndex = 3;
        }
        if (menuOptionIndex > mainMenuButtons.Length - 1)
        {
            menuOptionIndex = 0;
        }
        /*BACK TO INITIAL OPTION*/

        for (int i = 0; i < mainMenuButtons.Length; i++)
        {
            if (i == menuOptionIndex)
            {
                mainMenuButtons[menuOptionIndex].texture = menuButtonWhite;
                mainMenuText[menuOptionIndex].color = Color.white;
            }
            else
            {
                mainMenuButtons[i].texture = menuButtonNormal;
                mainMenuText[i].color = Color.white;
            }
        }

        //StartGame
        if ((menuOptionIndex == 0) && (Input.GetMouseButtonDown(0)))
        {
            started = true;
            menuScreenIndex = 17;
            
            animationIndex = 0;
        }

        if ((menuOptionIndex == 1) && (Input.GetMouseButtonDown(0)))
        {
            alreadyStarted = true;
            menuScreenIndex = 17;
            animationIndex = 0;
        }

        if ((menuOptionIndex == 2) && (Input.GetMouseButtonDown(0)))
        {
            mainMenuBool = false;
            creditsBool = true;
            animationIndex = 0;
            menuScreenIndex = 17;
        }

        if ((menuOptionIndex == 3) && (Input.GetMouseButtonDown(0)))
        {
            Application.Quit();
        }
    }

    private void MainMenuOff()
    {
        ////////Logo
        GameObject logo = mainMenu.transform.GetChild(0).gameObject;
        RawImage logoRaw = logo.GetComponent<RawImage>();

        Color alphaLogo = logoRaw.color;
        alphaLogo.a = turnOffAnimation[animationIndex];
        logoRaw.color = alphaLogo;

        ////////Button Start
        GameObject start = mainMenu.transform.GetChild(1).gameObject;
        RawImage startRaw = start.GetComponent<RawImage>();

        Color alphaStart = startRaw.color;
        alphaStart.a = turnOffAnimation[animationIndex];
        startRaw.color = alphaStart;

        //Text Start
        GameObject startTextGameObject = start.transform.GetChild(0).gameObject;
        Text startText = startTextGameObject.GetComponent<Text>();

        Color alphaStartText = startText.color;
        alphaStartText.a = turnOffAnimation[animationIndex];
        startText.color = alphaStartText;

        //Button Options
        GameObject optionsGameObject = mainMenu.transform.GetChild(2).gameObject;
        RawImage optionsraw = optionsGameObject.GetComponent<RawImage>();

        Color alphaOptions = optionsraw.color;
        alphaOptions.a = turnOffAnimation[animationIndex];
        optionsraw.color = alphaOptions;

        ////////Options Text
        GameObject optionsTextGameObject = optionsGameObject.transform.GetChild(0).gameObject;
        Text optionsText = optionsTextGameObject.GetComponent<Text>();

        Color alphaOptionsText = optionsText.color;
        alphaOptionsText.a = turnOffAnimation[animationIndex];
        optionsText.color = alphaOptionsText;


        //Button Credits
        GameObject creditsGameObject = mainMenu.transform.GetChild(3).gameObject;
        RawImage creditsraw = creditsGameObject.GetComponent<RawImage>();

        Color alphaCredits = creditsraw.color;
        alphaCredits.a = turnOffAnimation[animationIndex];
        creditsraw.color = alphaCredits;

        ////////Credits Text
        GameObject crecitsTextGameObject = creditsGameObject.transform.GetChild(0).gameObject;
        Text creditsText = crecitsTextGameObject.GetComponent<Text>();

        Color alphaCreditsText = creditsText.color;
        alphaCreditsText.a = turnOffAnimation[animationIndex];
        creditsText.color = alphaCreditsText;

        //Button Quit
        GameObject quit = mainMenu.transform.GetChild(4).gameObject;
        RawImage quitRaw = quit.GetComponent<RawImage>();

        Color alphaQuit = quitRaw.color;
        alphaQuit.a = turnOffAnimation[animationIndex];
        quitRaw.color = alphaQuit;

        ////////Quit Text
        GameObject quitTextGameObject = quit.transform.GetChild(0).gameObject;
        Text quitText = quitTextGameObject.GetComponent<Text>();

        Color alphaQuitText = quitText.color;
        alphaQuitText.a = turnOffAnimation[animationIndex];
        quitText.color = alphaQuitText;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if ((animationIndex == turnOnAnimation.Length - 1) && (started == true))
        {
            menuScreenIndex = 36;
            animationIndex = 0;
            menuOptionIndex = 0;
            started = false;
            timeToNext = timeToNextInitial;
        }
        if ((animationIndex == turnOnAnimation.Length - 1) && (optionsBool == true))
        {

            menuScreenIndex = 21;
            animationIndex = 0;
            menuOptionIndex = 0;
            optionsBool = false;
            timeToNext = timeToNextInitial;
        }

        if ((animationIndex == turnOnAnimation.Length - 1) && (creditsBool == true))
        {

            menuScreenIndex = 18;
            animationIndex = 0;
            menuOptionIndex = 0;
            creditsBool = false;
            timeToNext = timeToNextInitial;
        }

    }

    private void OptionsMenuOn()
    {
        ////////Logo
        GameObject logo = optionsMenu.transform.GetChild(0).gameObject;
        RawImage logoRaw = logo.GetComponent<RawImage>();

        Color alphaLogo = logoRaw.color;
        alphaLogo.a = turnOnAnimation[animationIndex];
        logoRaw.color = alphaLogo;

        ////////Button Start
        GameObject SoundImageText = optionsMenu.transform.GetChild(1).gameObject;
        RawImage startRaw = SoundImageText.GetComponent<RawImage>();

        Color alphaStart = startRaw.color;
        alphaStart.a = turnOnAnimation[animationIndex];
        startRaw.color = alphaStart;

        //Text Sound
        GameObject SoundText = SoundImageText.transform.GetChild(0).gameObject;
        Text startText = SoundText.GetComponent<Text>();

        Color alphaStartText = startText.color;
        alphaStartText.a = turnOnAnimation[animationIndex];
        startText.color = alphaStartText;

        ////////Button Controls
        GameObject Control = optionsMenu.transform.GetChild(2).gameObject;
        RawImage controlRaw = Control.GetComponent<RawImage>();

        Color alphaControlRaw = controlRaw.color;
        alphaControlRaw.a = turnOnAnimation[animationIndex];
        controlRaw.color = alphaControlRaw;

        //Text Controls
        GameObject ControlText = Control.transform.GetChild(0).gameObject;
        Text controlText = ControlText.GetComponent<Text>();

        Color alphaControl = controlText.color;
        alphaControl.a = turnOnAnimation[animationIndex];
        controlText.color = alphaControl;

        //Graphics
        GameObject Graphics = optionsMenu.transform.GetChild(3).gameObject;
        RawImage graphicsRaw = Graphics.GetComponent<RawImage>();

        Color alphGraphicslRaw = graphicsRaw.color;
        alphGraphicslRaw.a = turnOnAnimation[animationIndex];
        graphicsRaw.color = alphGraphicslRaw;

        //Text Graohics
        GameObject GraphicsText = Graphics.transform.GetChild(0).gameObject;
        Text GraphicsTextRaw = GraphicsText.GetComponent<Text>();

        Color alphaGraphics = GraphicsTextRaw.color;
        alphaGraphics.a = turnOnAnimation[animationIndex];
        GraphicsTextRaw.color = alphaGraphics;


        //GamePlay
        GameObject GamePlay = optionsMenu.transform.GetChild(4).gameObject;
        RawImage gameplayRaw = GamePlay.GetComponent<RawImage>();

        Color alphGamePlayRaw = gameplayRaw.color;
        alphGamePlayRaw.a = turnOnAnimation[animationIndex];
        gameplayRaw.color = alphGamePlayRaw;

        //Text GamePlay
        GameObject gameplayText = GamePlay.transform.GetChild(0).gameObject;
        Text gameplayTextRaw = gameplayText.GetComponent<Text>();

        Color alphaGamePlay = gameplayTextRaw.color;
        alphaGamePlay.a = turnOnAnimation[animationIndex];
        gameplayTextRaw.color = alphaGamePlay;

        //Back
        GameObject back = optionsMenu.transform.GetChild(5).gameObject;
        RawImage backImageraw = back.GetComponent<RawImage>();

        Color alphaBack = backImageraw.color;
        alphaBack.a = turnOnAnimation[animationIndex];
        backImageraw.color = alphaBack;

        //Text Back
        GameObject backText = back.transform.GetChild(0).gameObject;
        Text backTextRaw = backText.GetComponent<Text>();

        Color alphaBackText = backTextRaw.color;
        alphaBackText.a = turnOnAnimation[animationIndex];
        backTextRaw.color = alphaBackText;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == turnOnAnimation.Length - 1)
        {
            menuScreenIndex = 22;
            animationIndex = 0;
        }

    }
    private void OptionsMenu()
    {
        //W & S to change optionIndex
        if (Input.GetKeyDown("w"))
        {
            menuOptionIndex -= 1;
        }
        if (Input.GetKeyDown("s"))
        {
            menuOptionIndex += 1;
        }

        /* BACK TO INITIAL OPTION */
        if (menuOptionIndex < 0)
        {
            menuOptionIndex = optionsImageMenu.Length - 1;
        }
        if (menuOptionIndex > optionsImageMenu.Length - 1)
        {
            menuOptionIndex = 0;
        }
        /*BACK TO INITIAL OPTION*/

        for (int i = 0; i < optionsImageMenu.Length; i++)
        {
            if (i == menuOptionIndex)
            {
                optionsImageMenu[menuOptionIndex].texture = menuButtonWhite;
                optionsTextMenu[menuOptionIndex].color = Color.white;
            }
            else
            {
                optionsImageMenu[i].texture = menuButtonNormal;
                optionsTextMenu[i].color = Color.white;
            }
        }

        if ((Input.GetMouseButtonDown(0)) && (menuOptionIndex == 0))
        {
            menuScreenIndex = 23;
            soundBool = true;
            animationIndex = 0;
            timeToNext = timeToNextInitial;
        }

        if ((Input.GetMouseButtonDown(0)) && (menuOptionIndex == 1))
        {
            menuScreenIndex = 23;
            controlBool = true;
            animationIndex = 0;
            timeToNext = timeToNextInitial;
        }

        if ((Input.GetMouseButtonDown(0)) && (menuOptionIndex == 2))
        {
            menuScreenIndex = 23;
            graphicsBool = true;
            animationIndex = 0;
            timeToNext = timeToNextInitial;
        }

        if ((Input.GetMouseButtonDown(0)) && (menuOptionIndex == 3))
        {
            menuScreenIndex = 23;
            gamePlayBool = true;
            animationIndex = 0;
            timeToNext = timeToNextInitial;
        }

        if ((Input.GetMouseButtonDown(0)) && (menuOptionIndex == 4))
        {
            menuScreenIndex = 23;
            backBool = true;
            animationIndex = 0;
            timeToNext = timeToNextInitial;
        }
    }
    private void OptionsMenuOff()
    {
        ////////Logo
        GameObject logo = optionsMenu.transform.GetChild(0).gameObject;
        RawImage logoRaw = logo.GetComponent<RawImage>();

        Color alphaLogo = logoRaw.color;
        alphaLogo.a = turnOffAnimation[animationIndex];
        logoRaw.color = alphaLogo;

        ////////Button Start
        GameObject SoundImageText = optionsMenu.transform.GetChild(1).gameObject;
        RawImage startRaw = SoundImageText.GetComponent<RawImage>();

        Color alphaStart = startRaw.color;
        alphaStart.a = turnOffAnimation[animationIndex];
        startRaw.color = alphaStart;

        //Text Sound
        GameObject SoundText = SoundImageText.transform.GetChild(0).gameObject;
        Text startText = SoundText.GetComponent<Text>();

        Color alphaStartText = startText.color;
        alphaStartText.a = turnOffAnimation[animationIndex];
        startText.color = alphaStartText;

        ////////Button Controls
        GameObject Control = optionsMenu.transform.GetChild(2).gameObject;
        RawImage controlRaw = Control.GetComponent<RawImage>();

        Color alphaControlRaw = controlRaw.color;
        alphaControlRaw.a = turnOffAnimation[animationIndex];
        controlRaw.color = alphaControlRaw;

        //Text Controls
        GameObject ControlText = Control.transform.GetChild(0).gameObject;
        Text controlText = ControlText.GetComponent<Text>();

        Color alphaControl = controlText.color;
        alphaControl.a = turnOffAnimation[animationIndex];
        controlText.color = alphaControl;

        //Graphics
        GameObject Graphics = optionsMenu.transform.GetChild(3).gameObject;
        RawImage graphicsRaw = Graphics.GetComponent<RawImage>();

        Color alphGraphicslRaw = graphicsRaw.color;
        alphGraphicslRaw.a = turnOffAnimation[animationIndex];
        graphicsRaw.color = alphGraphicslRaw;

        //Text Graohics
        GameObject GraphicsText = Graphics.transform.GetChild(0).gameObject;
        Text GraphicsTextRaw = GraphicsText.GetComponent<Text>();

        Color alphaGraphics = GraphicsTextRaw.color;
        alphaGraphics.a = turnOffAnimation[animationIndex];
        GraphicsTextRaw.color = alphaGraphics;

        //GamePlay
        GameObject GamePlay = optionsMenu.transform.GetChild(4).gameObject;
        RawImage gameplayRaw = GamePlay.GetComponent<RawImage>();

        Color alphGamePlayRaw = gameplayRaw.color;
        alphGamePlayRaw.a = turnOffAnimation[animationIndex];
        gameplayRaw.color = alphGamePlayRaw;

        //Text GamePlay
        GameObject gameplayText = GamePlay.transform.GetChild(0).gameObject;
        Text gameplayTextRaw = gameplayText.GetComponent<Text>();

        Color alphaGamePlay = gameplayTextRaw.color;
        alphaGamePlay.a = turnOffAnimation[animationIndex];
        gameplayTextRaw.color = alphaGamePlay;

        //Back
        GameObject back = optionsMenu.transform.GetChild(5).gameObject;
        RawImage backImageraw = back.GetComponent<RawImage>();

        Color alphaBack = backImageraw.color;
        alphaBack.a = turnOffAnimation[animationIndex];
        backImageraw.color = alphaBack;

        //Text Back
        GameObject backText = back.transform.GetChild(0).gameObject;
        Text backTextRaw = backText.GetComponent<Text>();

        Color alphaBackText = backTextRaw.color;
        alphaBackText.a = turnOffAnimation[animationIndex];
        backTextRaw.color = alphaBackText;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if ((animationIndex == turnOnAnimation.Length - 1) && (soundBool == true))
        {
            menuScreenIndex = 24;
            animationIndex = 0;
            soundBool = false;
            timeToNext = timeToNextInitial;
        }
        if ((animationIndex == turnOnAnimation.Length - 1) && (controlBool == true))
        {
            menuScreenIndex = 27;
            animationIndex = 0;
            controlBool = false;
            timeToNext = timeToNextInitial;
        }
        if ((animationIndex == turnOnAnimation.Length - 1) && (graphicsBool == true))
        {
            menuScreenIndex = 30;
            animationIndex = 0;
            timeToNext = timeToNextInitial;
            graphicsBool = false;
        }
        if ((animationIndex == turnOnAnimation.Length - 1) && (gamePlayBool == true))
        {
            menuScreenIndex = 33;
            animationIndex = 0;
            gamePlayBool = false;
            timeToNext = timeToNextInitial;
        }
        if ((animationIndex == turnOnAnimation.Length - 1) && (backBool == true))
        {
            animationIndex = 0;
            menuOptionIndex = 15;
            timeToNext = timeToNextInitial;
            menuScreenIndex = 15;
            timeToNext = timeToNextInitial;
            backBool = false;
        }
    }

    private void SoundMenuOn()
    {
        ////////Logo
        GameObject logo = soundMenu.transform.GetChild(0).gameObject;
        RawImage logoRaw = logo.GetComponent<RawImage>();

        Color alphaLogo = logoRaw.color;
        alphaLogo.a = turnOnAnimation[animationIndex];
        logoRaw.color = alphaLogo;


        //Text
        GameObject text = soundMenu.transform.GetChild(1).gameObject;
        Text textRaw = text.GetComponent<Text>();

        Color alphaText = textRaw.color;
        alphaText.a = turnOnAnimation[animationIndex];
        textRaw.color = alphaText;

        //SoundOption - FATHER
        GameObject SoundOptionFather = soundMenu.transform.GetChild(2).gameObject;
        RawImage SoundFatherRaw = SoundOptionFather.GetComponent<RawImage>();

        Color alphaOptionsFather = SoundFatherRaw.color;
        alphaOptionsFather.a = turnOnAnimation[animationIndex];
        SoundFatherRaw.color = alphaOptionsFather;

        //Text - child Sound
        GameObject textchild0 = SoundOptionFather.transform.GetChild(0).gameObject;
        Text textchildFather0Raw = textchild0.GetComponent<Text>();

        Color alphaFather0Text = textchildFather0Raw.color;
        alphaFather0Text.a = turnOnAnimation[animationIndex];
        textchildFather0Raw.color = alphaFather0Text;

        //SoundBackground
        GameObject imageChild01 = SoundOptionFather.transform.GetChild(1).gameObject;
        RawImage imagechildFather1Raw = imageChild01.GetComponent<RawImage>();

        Color alphaFather1image = imagechildFather1Raw.color;
        alphaFather1image.a = turnOnAnimation[animationIndex];
        imagechildFather1Raw.color = alphaFather1image;

        //Sound Level
        GameObject imageChild02 = SoundOptionFather.transform.GetChild(2).gameObject;
        RawImage imagechildFather2Raw = imageChild02.GetComponent<RawImage>();

        Color alphaFather2image = imagechildFather2Raw.color;
        alphaFather2image.a = turnOnAnimation[animationIndex];
        imagechildFather2Raw.color = alphaFather2image;

        //SFXOption - MOTHER
        GameObject SFXOptionMother = soundMenu.transform.GetChild(3).gameObject;
        RawImage SFXFatherRaw = SFXOptionMother.GetComponent<RawImage>();

        Color alphaSFXMother = SFXFatherRaw.color;
        alphaSFXMother.a = turnOnAnimation[animationIndex];
        SFXFatherRaw.color = alphaSFXMother;

        //Text - child SFX
        GameObject textchild1 = SFXOptionMother.transform.GetChild(0).gameObject;
        Text textchildMother0Raw = textchild1.GetComponent<Text>();

        Color alphaMother0Text = textchildMother0Raw.color;
        alphaMother0Text.a = turnOnAnimation[animationIndex];
        textchildMother0Raw.color = alphaMother0Text;

        //SoundBackground
        GameObject imageChild04 = SFXOptionMother.transform.GetChild(1).gameObject;
        RawImage imagechildMother1Raw = imageChild04.GetComponent<RawImage>();

        Color alphaMother1image = imagechildMother1Raw.color;
        alphaMother1image.a = turnOnAnimation[animationIndex];
        imagechildMother1Raw.color = alphaMother1image;

        //Sound Level
        GameObject imageChild05 = SFXOptionMother.transform.GetChild(2).gameObject;
        RawImage imagechildMother2Raw = imageChild05.GetComponent<RawImage>();

        Color alphaMother2image = imagechildMother2Raw.color;
        alphaMother2image.a = turnOnAnimation[animationIndex];
        imagechildMother2Raw.color = alphaMother2image;

        //BackButton
        //Back
        GameObject back = soundMenu.transform.GetChild(4).gameObject;
        RawImage backImageraw = back.GetComponent<RawImage>();

        Color alphaBack = backImageraw.color;
        alphaBack.a = turnOnAnimation[animationIndex];
        backImageraw.color = alphaBack;

        //Text Back
        GameObject backText = back.transform.GetChild(0).gameObject;
        Text backTextRaw = backText.GetComponent<Text>();

        Color alphaBackText = backTextRaw.color;
        alphaBackText.a = turnOnAnimation[animationIndex];
        backTextRaw.color = alphaBackText;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == turnOnAnimation.Length - 1)
        {
            menuScreenIndex = 25;
            animationIndex = 0;
        }
    }

    private void SoundMenu()
    {

        //W & S to change optionIndex
        if (Input.GetKeyDown("w"))
        {
            menuOptionIndex -= 1;
        }
        if (Input.GetKeyDown("s"))
        {
            menuOptionIndex += 1;
        }

        /* BACK TO INITIAL OPTION */
        if (menuOptionIndex < 0)
        {
            menuOptionIndex = SoundMenuOptions.Length - 1;
        }
        if (menuOptionIndex > SoundMenuOptions.Length - 1)
        {
            menuOptionIndex = 0;
        }
        /*BACK TO INITIAL OPTION*/

        for (int i = 0; i < SoundMenuOptions.Length; i++)
        {
            if (i == menuOptionIndex)
            {
                SoundMenuOptions[menuOptionIndex].texture = menuButtonWhite;
                SoundMenuOptions[menuOptionIndex].color = Color.white;
            }
            else
            {
                SoundMenuOptions[i].texture = menuButtonNormal;
                SoundMenuOptions[i].color = Color.white;
            }
        }

        if (menuOptionIndex == 0)
        {
            //TODO: CHANGE VOLUME SOUND
        }

        if (menuOptionIndex == 1)
        {
            //TODO: CHANGE VOLUME SFX
        }

        if ((Input.GetMouseButtonDown(0)) && (menuOptionIndex == 2))
        {
            menuScreenIndex = 26;
            controlBool = false;
            animationIndex = 0;
            timeToNext = timeToNextInitial;
        }
    }

    private void SoundMenuOff()
    {
        ////////Logo
        GameObject logo = soundMenu.transform.GetChild(0).gameObject;
        RawImage logoRaw = logo.GetComponent<RawImage>();

        Color alphaLogo = logoRaw.color;
        alphaLogo.a = turnOffAnimation[animationIndex];
        logoRaw.color = alphaLogo;


        //Text
        GameObject text = soundMenu.transform.GetChild(1).gameObject;
        Text textRaw = text.GetComponent<Text>();

        Color alphaText = textRaw.color;
        alphaText.a = turnOffAnimation[animationIndex];
        textRaw.color = alphaText;

        //SoundOption - FATHER
        GameObject SoundOptionFather = soundMenu.transform.GetChild(2).gameObject;
        RawImage SoundFatherRaw = SoundOptionFather.GetComponent<RawImage>();

        Color alphaOptionsFather = SoundFatherRaw.color;
        alphaOptionsFather.a = turnOffAnimation[animationIndex];
        SoundFatherRaw.color = alphaOptionsFather;

        //Text - child Sound
        GameObject textchild0 = SoundOptionFather.transform.GetChild(0).gameObject;
        Text textchildFather0Raw = textchild0.GetComponent<Text>();

        Color alphaFather0Text = textchildFather0Raw.color;
        alphaFather0Text.a = turnOffAnimation[animationIndex];
        textchildFather0Raw.color = alphaFather0Text;

        //SoundBackground
        GameObject imageChild01 = SoundOptionFather.transform.GetChild(1).gameObject;
        RawImage imagechildFather1Raw = imageChild01.GetComponent<RawImage>();

        Color alphaFather1image = imagechildFather1Raw.color;
        alphaFather1image.a = turnOffAnimation[animationIndex];
        imagechildFather1Raw.color = alphaFather1image;

        //Sound Level
        GameObject imageChild02 = SoundOptionFather.transform.GetChild(2).gameObject;
        RawImage imagechildFather2Raw = imageChild02.GetComponent<RawImage>();

        Color alphaFather2image = imagechildFather2Raw.color;
        alphaFather2image.a = turnOffAnimation[animationIndex];
        imagechildFather2Raw.color = alphaFather2image;

        //SFXOption - MOTHER
        GameObject SFXOptionMother = soundMenu.transform.GetChild(3).gameObject;
        RawImage SFXFatherRaw = SFXOptionMother.GetComponent<RawImage>();

        Color alphaSFXMother = SFXFatherRaw.color;
        alphaSFXMother.a = turnOffAnimation[animationIndex];
        SFXFatherRaw.color = alphaSFXMother;

        //Text - child SFX
        GameObject textchild1 = SFXOptionMother.transform.GetChild(0).gameObject;
        Text textchildMother0Raw = textchild1.GetComponent<Text>();

        Color alphaMother0Text = textchildMother0Raw.color;
        alphaMother0Text.a = turnOffAnimation[animationIndex];
        textchildMother0Raw.color = alphaMother0Text;

        //SoundBackground
        GameObject imageChild04 = SFXOptionMother.transform.GetChild(1).gameObject;
        RawImage imagechildMother1Raw = imageChild04.GetComponent<RawImage>();

        Color alphaMother1image = imagechildMother1Raw.color;
        alphaMother1image.a = turnOffAnimation[animationIndex];
        imagechildMother1Raw.color = alphaMother1image;

        //Sound Level
        GameObject imageChild05 = SFXOptionMother.transform.GetChild(2).gameObject;
        RawImage imagechildMother2Raw = imageChild05.GetComponent<RawImage>();

        Color alphaMother2image = imagechildMother2Raw.color;
        alphaMother2image.a = turnOffAnimation[animationIndex];
        imagechildMother2Raw.color = alphaMother2image;

        //BackButton
        //Back
        GameObject back = soundMenu.transform.GetChild(4).gameObject;
        RawImage backImageraw = back.GetComponent<RawImage>();

        Color alphaBack = backImageraw.color;
        alphaBack.a = turnOffAnimation[animationIndex];
        backImageraw.color = alphaBack;

        //Text Back
        GameObject backText = back.transform.GetChild(0).gameObject;
        Text backTextRaw = backText.GetComponent<Text>();

        Color alphaBackText = backTextRaw.color;
        alphaBackText.a = turnOffAnimation[animationIndex];
        backTextRaw.color = alphaBackText;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == turnOnAnimation.Length - 1)
        {
            menuScreenIndex = 21;
            animationIndex = 0;
        }
    }

    private void ControlsMenuOn()
    {
        ////////Logo
        GameObject logo = controlMenu.transform.GetChild(0).gameObject;
        RawImage logoRaw = logo.GetComponent<RawImage>();

        Color alphaLogo = logoRaw.color;
        alphaLogo.a = turnOnAnimation[animationIndex];
        logoRaw.color = alphaLogo;

        ////////PickUp
        GameObject pickUp = controlMenu.transform.GetChild(1).gameObject;
        RawImage pickUpRaw = pickUp.GetComponent<RawImage>();

        Color alphaPick = pickUpRaw.color;
        alphaPick.a = turnOnAnimation[animationIndex];
        pickUpRaw.color = alphaPick;

        ////////Movement
        GameObject movement = controlMenu.transform.GetChild(2).gameObject;
        RawImage movementRaw = movement.GetComponent<RawImage>();

        Color alphaMovement = movementRaw.color;
        alphaMovement.a = turnOnAnimation[animationIndex];
        movementRaw.color = alphaMovement;

        ////////Interact
        GameObject interact = controlMenu.transform.GetChild(3).gameObject;
        RawImage interactRaw = interact.GetComponent<RawImage>();

        Color alphaInteract = interactRaw.color;
        alphaInteract.a = turnOnAnimation[animationIndex];
        interactRaw.color = alphaInteract;

        ////////Text
        GameObject controls = controlMenu.transform.GetChild(4).gameObject;
        Text controlRaw = controls.GetComponent<Text>();

        Color alphaControl = controlRaw.color;
        alphaControl.a = turnOnAnimation[animationIndex];
        controlRaw.color = alphaControl;

        ////////Button
        GameObject back = controlMenu.transform.GetChild(5).gameObject;
        RawImage backRaw = back.GetComponent<RawImage>();

        Color alphaBack = backRaw.color;
        alphaBack.a = turnOnAnimation[animationIndex];
        backRaw.color = alphaBack;

        GameObject backText = back.transform.GetChild(0).gameObject;
        Text backTextRaw = backText.GetComponent<Text>();

        Color alphaTextBack = backTextRaw.color;
        alphaTextBack.a = turnOffAnimation[animationIndex];
        backTextRaw.color = alphaTextBack;


        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == turnOnAnimation.Length - 1)
        {
            menuScreenIndex = 28;
            animationIndex = 0;
        }
    }

    private void ControlsMenu()
    {
        if (Input.GetMouseButtonDown(0))
        {
            menuScreenIndex = 29;
            animationIndex = 0;
        }
    }
    private void ControlsMenuOff()
    {
        ////////Logo
        GameObject logo = controlMenu.transform.GetChild(0).gameObject;
        RawImage logoRaw = logo.GetComponent<RawImage>();

        Color alphaLogo = logoRaw.color;
        alphaLogo.a = turnOffAnimation[animationIndex];
        logoRaw.color = alphaLogo;

        ////////PickUp
        GameObject pickUp = controlMenu.transform.GetChild(1).gameObject;
        RawImage pickUpRaw = pickUp.GetComponent<RawImage>();

        Color alphaPick = pickUpRaw.color;
        alphaPick.a = turnOffAnimation[animationIndex];
        pickUpRaw.color = alphaPick;

        ////////Movement
        GameObject movement = controlMenu.transform.GetChild(2).gameObject;
        RawImage movementRaw = movement.GetComponent<RawImage>();

        Color alphaMovement = movementRaw.color;
        alphaMovement.a = turnOffAnimation[animationIndex];
        movementRaw.color = alphaMovement;

        ////////Interact
        GameObject interact = controlMenu.transform.GetChild(3).gameObject;
        RawImage interactRaw = interact.GetComponent<RawImage>();

        Color alphaInteract = interactRaw.color;
        alphaInteract.a = turnOffAnimation[animationIndex];
        interactRaw.color = alphaInteract;

        ////////Text
        GameObject controls = controlMenu.transform.GetChild(4).gameObject;
        Text controlRaw = controls.GetComponent<Text>();

        Color alphaControl = controlRaw.color;
        alphaControl.a = turnOffAnimation[animationIndex];
        controlRaw.color = alphaControl;

        ////////Button
        GameObject back = controlMenu.transform.GetChild(5).gameObject;
        RawImage backRaw = back.GetComponent<RawImage>();

        Color alphaBack = backRaw.color;
        alphaBack.a = turnOffAnimation[animationIndex];
        backRaw.color = alphaBack;

        GameObject backText = back.transform.GetChild(0).gameObject;
        Text backTextRaw = backText.GetComponent<Text>();

        Color alphaTextBack = backTextRaw.color;
        alphaTextBack.a = turnOffAnimation[animationIndex];
        backTextRaw.color = alphaTextBack;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == turnOnAnimation.Length - 1)
        {
            graphicsBool = false;
            menuScreenIndex = 21;
            animationIndex = 0;
        }
    }

    private void GraphicsMenuOn()
    {
        ////////Logo
        GameObject logo = graphicsMenu.transform.GetChild(0).gameObject;
        RawImage logoRaw = logo.GetComponent<RawImage>();

        Color alphaLogo = logoRaw.color;
        alphaLogo.a = turnOnAnimation[animationIndex];
        logoRaw.color = alphaLogo;

        //Text
        GameObject text = graphicsMenu.transform.GetChild(1).gameObject;
        Text textRaw = text.GetComponent<Text>();

        Color alphaText = textRaw.color;
        alphaText.a = turnOnAnimation[animationIndex];
        textRaw.color = alphaText;

        //Brightness - FATHER
        GameObject BritghOptionFather = graphicsMenu.transform.GetChild(2).gameObject;
        RawImage BritghFatherRaw = BritghOptionFather.GetComponent<RawImage>();

        Color alphaBritghFather = BritghFatherRaw.color;
        alphaBritghFather.a = turnOnAnimation[animationIndex];
        BritghFatherRaw.color = alphaBritghFather;

        //Text - child Sound
        GameObject textchild0 = BritghOptionFather.transform.GetChild(0).gameObject;
        Text textchildFather0Raw = textchild0.GetComponent<Text>();

        Color alphaFather0Text = textchildFather0Raw.color;
        alphaFather0Text.a = turnOnAnimation[animationIndex];
        textchildFather0Raw.color = alphaFather0Text;

        //SoundBackground
        GameObject imageChild01 = BritghOptionFather.transform.GetChild(1).gameObject;
        RawImage imagechildFather1Raw = imageChild01.GetComponent<RawImage>();

        Color alphaFather1image = imagechildFather1Raw.color;
        alphaFather1image.a = turnOnAnimation[animationIndex];
        imagechildFather1Raw.color = alphaFather1image;

        //Sound Level
        GameObject imageChild02 = BritghOptionFather.transform.GetChild(2).gameObject;
        RawImage imagechildFather2Raw = imageChild02.GetComponent<RawImage>();

        Color alphaFather2image = imagechildFather2Raw.color;
        alphaFather2image.a = turnOnAnimation[animationIndex];
        imagechildFather2Raw.color = alphaFather2image;

        //IngameUI - Mother
        GameObject InGameMother = graphicsMenu.transform.GetChild(3).gameObject;
        RawImage InGameUIRaw = InGameMother.GetComponent<RawImage>();

        Color alphaInGameUI = InGameUIRaw.color;
        alphaInGameUI.a = turnOnAnimation[animationIndex];
        InGameUIRaw.color = alphaInGameUI;

        //SubtitlesText
        GameObject TextMother0 = InGameMother.transform.GetChild(0).gameObject;
        Text TextMotherRaw = TextMother0.GetComponent<Text>();

        Color alphaText0 = TextMotherRaw.color;
        alphaText0.a = turnOnAnimation[animationIndex];
        TextMotherRaw.color = alphaText0;

        //Seta Esquerda
        GameObject setaEsquerdaMother = InGameMother.transform.GetChild(1).gameObject;
        RawImage setaRaw1 = setaEsquerdaMother.GetComponent<RawImage>();

        Color alphaSeta1 = setaRaw1.color;
        alphaSeta1.a = turnOnAnimation[animationIndex];
        setaRaw1.color = alphaSeta1;

        //Seta Esquerda
        GameObject setaDireitaMother = InGameMother.transform.GetChild(2).gameObject;
        RawImage setaRaw2 = setaDireitaMother.GetComponent<RawImage>();

        Color alphaSeta2 = setaRaw2.color;
        alphaSeta2.a = turnOnAnimation[animationIndex];
        setaRaw2.color = alphaSeta2;

        //Texto Dentro InGameUI
        GameObject TextMother1 = InGameMother.transform.GetChild(3).gameObject;
        Text TextMotherRaw1 = TextMother1.GetComponent<Text>();

        Color alphaText1 = TextMotherRaw1.color;
        alphaText1.a = turnOnAnimation[animationIndex];
        TextMotherRaw1.color = alphaText1;

        //BackButton
        //Back
        GameObject back = graphicsMenu.transform.GetChild(4).gameObject;
        RawImage backImageraw = back.GetComponent<RawImage>();

        Color alphaBack = backImageraw.color;
        alphaBack.a = turnOnAnimation[animationIndex];
        backImageraw.color = alphaBack;

        //Text Back
        GameObject backText = back.transform.GetChild(0).gameObject;
        Text backTextRaw = backText.GetComponent<Text>();

        Color alphaBackText = backTextRaw.color;
        alphaBackText.a = turnOnAnimation[animationIndex];
        backTextRaw.color = alphaBackText;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == turnOnAnimation.Length - 1)
        {
            menuScreenIndex = 31;
            animationIndex = 0;
        }
    }
    private void GraphicsMenu()
    {

        //W & S to change optionIndex
        if (Input.GetKeyDown("w"))
        {
            menuOptionIndex -= 1;
        }
        if (Input.GetKeyDown("s"))
        {
            menuOptionIndex += 1;
        }

        /* BACK TO INITIAL OPTION */
        if (menuOptionIndex < 0)
        {
            menuOptionIndex = graphicsMenuOptions.Length - 1;
        }
        if (menuOptionIndex > graphicsMenuOptions.Length - 1)
        {
            menuOptionIndex = 0;
        }
        /*BACK TO INITIAL OPTION*/

        for (int i = 0; i < graphicsMenuOptions.Length; i++)
        {
            if (i == menuOptionIndex)
            {
                graphicsMenuOptions[menuOptionIndex].texture = menuButtonWhite;
                graphicsMenuOptions[menuOptionIndex].color = Color.white;
            }
            else
            {
                graphicsMenuOptions[i].texture = menuButtonNormal;
                graphicsMenuOptions[i].color = Color.white;
            }
        }

        if (menuOptionIndex == 0)
        {
            //TODO: CHANGE Britghness
        }

        if (menuOptionIndex == 1)
        {
            //TODO: CHANGE VOLUME SFX
        }

        if ((Input.GetMouseButtonDown(0)) && (menuOptionIndex == 2))
        {
            menuScreenIndex = 32;
            controlBool = false;
            animationIndex = 0;
            timeToNext = timeToNextInitial;
        }
    }

    private void GraphicsMenuOff()
    {
        ////////Logo
        GameObject logo = graphicsMenu.transform.GetChild(0).gameObject;
        RawImage logoRaw = logo.GetComponent<RawImage>();

        Color alphaLogo = logoRaw.color;
        alphaLogo.a = turnOffAnimation[animationIndex];
        logoRaw.color = alphaLogo;

        //Text
        GameObject text = graphicsMenu.transform.GetChild(1).gameObject;
        Text textRaw = text.GetComponent<Text>();

        Color alphaText = textRaw.color;
        alphaText.a = turnOffAnimation[animationIndex];
        textRaw.color = alphaText;

        //Brightness - FATHER
        GameObject BritghOptionFather = graphicsMenu.transform.GetChild(2).gameObject;
        RawImage BritghFatherRaw = BritghOptionFather.GetComponent<RawImage>();

        Color alphaBritghFather = BritghFatherRaw.color;
        alphaBritghFather.a = turnOffAnimation[animationIndex];
        BritghFatherRaw.color = alphaBritghFather;

        //Text - child Sound
        GameObject textchild0 = BritghOptionFather.transform.GetChild(0).gameObject;
        Text textchildFather0Raw = textchild0.GetComponent<Text>();

        Color alphaFather0Text = textchildFather0Raw.color;
        alphaFather0Text.a = turnOffAnimation[animationIndex];
        textchildFather0Raw.color = alphaFather0Text;

        //SoundBackground
        GameObject imageChild01 = BritghOptionFather.transform.GetChild(1).gameObject;
        RawImage imagechildFather1Raw = imageChild01.GetComponent<RawImage>();

        Color alphaFather1image = imagechildFather1Raw.color;
        alphaFather1image.a = turnOffAnimation[animationIndex];
        imagechildFather1Raw.color = alphaFather1image;

        //Sound Level
        GameObject imageChild02 = BritghOptionFather.transform.GetChild(2).gameObject;
        RawImage imagechildFather2Raw = imageChild02.GetComponent<RawImage>();

        Color alphaFather2image = imagechildFather2Raw.color;
        alphaFather2image.a = turnOffAnimation[animationIndex];
        imagechildFather2Raw.color = alphaFather2image;

        //IngameUI - Mother
        GameObject InGameMother = graphicsMenu.transform.GetChild(3).gameObject;
        RawImage InGameUIRaw = InGameMother.GetComponent<RawImage>();

        Color alphaInGameUI = InGameUIRaw.color;
        alphaInGameUI.a = turnOffAnimation[animationIndex];
        InGameUIRaw.color = alphaInGameUI;

        //SubtitlesText
        GameObject TextMother0 = InGameMother.transform.GetChild(0).gameObject;
        Text TextMotherRaw = TextMother0.GetComponent<Text>();

        Color alphaText0 = TextMotherRaw.color;
        alphaText0.a = turnOffAnimation[animationIndex];
        TextMotherRaw.color = alphaText0;

        //Seta Esquerda
        GameObject setaEsquerdaMother = InGameMother.transform.GetChild(1).gameObject;
        RawImage setaRaw1 = setaEsquerdaMother.GetComponent<RawImage>();

        Color alphaSeta1 = setaRaw1.color;
        alphaSeta1.a = turnOffAnimation[animationIndex];
        setaRaw1.color = alphaSeta1;

        //Seta Esquerda
        GameObject setaDireitaMother = InGameMother.transform.GetChild(2).gameObject;
        RawImage setaRaw2 = setaDireitaMother.GetComponent<RawImage>();

        Color alphaSeta2 = setaRaw2.color;
        alphaSeta2.a = turnOffAnimation[animationIndex];
        setaRaw2.color = alphaSeta2;

        //Texto Dentro InGameUI
        GameObject TextMother1 = InGameMother.transform.GetChild(3).gameObject;
        Text TextMotherRaw1 = TextMother1.GetComponent<Text>();

        Color alphaText1 = TextMotherRaw1.color;
        alphaText1.a = turnOffAnimation[animationIndex];
        TextMotherRaw1.color = alphaText1;

        //BackButton
        //Back
        GameObject back = graphicsMenu.transform.GetChild(4).gameObject;
        RawImage backImageraw = back.GetComponent<RawImage>();

        Color alphaBack = backImageraw.color;
        alphaBack.a = turnOffAnimation[animationIndex];
        backImageraw.color = alphaBack;

        //Text Back
        GameObject backText = back.transform.GetChild(0).gameObject;
        Text backTextRaw = backText.GetComponent<Text>();

        Color alphaBackText = backTextRaw.color;
        alphaBackText.a = turnOffAnimation[animationIndex];
        backTextRaw.color = alphaBackText;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == turnOnAnimation.Length - 1)
        {
            menuScreenIndex = 21;
            animationIndex = 0;
        }
    }

    private void GamePlayOn()
    {
        ////////Logo
        GameObject logo = gameplayMenu.transform.GetChild(0).gameObject;
        RawImage logoRaw = logo.GetComponent<RawImage>();

        Color alphaLogo = logoRaw.color;
        alphaLogo.a = turnOnAnimation[animationIndex];
        logoRaw.color = alphaLogo;

        //Text
        GameObject text = gameplayMenu.transform.GetChild(1).gameObject;
        Text textRaw = text.GetComponent<Text>();

        Color alphaText = textRaw.color;
        alphaText.a = turnOnAnimation[animationIndex];
        textRaw.color = alphaText;

        //DifficultyOption
        GameObject OptionFather = gameplayMenu.transform.GetChild(2).gameObject;
        RawImage OptionsFatherRaw = OptionFather.GetComponent<RawImage>();

        Color alphaOptionsFather = OptionsFatherRaw.color;
        alphaOptionsFather.a = turnOnAnimation[animationIndex];
        OptionsFatherRaw.color = alphaOptionsFather;


        //DifficultyOption 1
        GameObject OptionChildText = OptionFather.transform.GetChild(0).gameObject;
        Text ChildTextRaw = OptionChildText.GetComponent<Text>();

        Color alphaChildText = ChildTextRaw.color;
        alphaChildText.a = turnOnAnimation[animationIndex];
        ChildTextRaw.color = alphaChildText;

        //DifficultyOption 2
        GameObject OptionChildImage0 = OptionFather.transform.GetChild(1).gameObject;
        RawImage ChildImage1Raw = OptionChildImage0.GetComponent<RawImage>();

        Color alphaChildImage1 = ChildImage1Raw.color;
        alphaChildImage1.a = turnOnAnimation[animationIndex];
        ChildImage1Raw.color = alphaChildImage1;

        //DifficultyOption 3
        GameObject OptionChildImage2 = OptionFather.transform.GetChild(2).gameObject;
        RawImage ChildImage2Raw = OptionChildImage2.GetComponent<RawImage>();

        Color alphaChildImage2 = ChildImage2Raw.color;
        alphaChildImage2.a = turnOnAnimation[animationIndex];
        ChildImage2Raw.color = alphaChildImage2;

        //DifficultyOption 3
        GameObject OptionChildText2 = OptionFather.transform.GetChild(3).gameObject;
        Text ChildText2Raw = OptionChildText2.GetComponent<Text>();

        Color alphaChildText2 = ChildText2Raw.color;
        alphaChildText2.a = turnOnAnimation[animationIndex];
        ChildText2Raw.color = alphaChildText2;

        //subtitlesImage
        GameObject OptionMother = gameplayMenu.transform.GetChild(3).gameObject;
        RawImage OptionsMotherRaw = OptionMother.GetComponent<RawImage>();

        Color alphaOptionsMother = OptionsMotherRaw.color;
        alphaOptionsMother.a = turnOnAnimation[animationIndex];
        OptionsMotherRaw.color = alphaOptionsMother;

        //subtitlesText
        GameObject OptionMotherImage0 = OptionMother.transform.GetChild(0).gameObject;
        Text ChildMother0Raw = OptionMotherImage0.GetComponent<Text>();

        Color alphaChildMother0 = ChildMother0Raw.color;
        alphaChildMother0.a = turnOnAnimation[animationIndex];
        ChildMother0Raw.color = alphaChildMother0;

        //subtitlesImage1
        GameObject OptionMotherImage1 = OptionMother.transform.GetChild(1).gameObject;
        RawImage ChildMother1Raw = OptionMotherImage1.GetComponent<RawImage>();

        Color alphaChildMother1 = ChildMother1Raw.color;
        alphaChildMother1.a = turnOnAnimation[animationIndex];
        ChildMother1Raw.color = alphaChildMother1;

        //subtitlesImage2
        GameObject OptionMotherImage2 = OptionMother.transform.GetChild(2).gameObject;
        RawImage ChildMother2Raw = OptionMotherImage2.GetComponent<RawImage>();

        Color alphaChildMother2 = ChildMother2Raw.color;
        alphaChildMother2.a = turnOnAnimation[animationIndex];
        ChildMother2Raw.color = alphaChildMother2;

        //subtitlesImage2
        GameObject OptionMotherImage3 = OptionMother.transform.GetChild(3).gameObject;
        Text ChildMother3Raw = OptionMotherImage3.GetComponent<Text>();

        Color alphaChildMother3 = ChildMother3Raw.color;
        alphaChildMother3.a = turnOnAnimation[animationIndex];
        ChildMother3Raw.color = alphaChildMother3;

        //BackImage
        GameObject backImage = gameplayMenu.transform.GetChild(4).gameObject;
        RawImage backImageRaw = backImage.GetComponent<RawImage>();

        Color alphaBackImageRaw = backImageRaw.color;
        alphaBackImageRaw.a = turnOnAnimation[animationIndex];
        backImageRaw.color = alphaBackImageRaw;

        //BackText
        GameObject backText = backImage.transform.GetChild(0).gameObject;
        Text backTextRaw = backText.GetComponent<Text>();

        Color alphaBackTextRawRaw = backTextRaw.color;
        alphaBackTextRawRaw.a = turnOnAnimation[animationIndex];
        backTextRaw.color = alphaBackTextRawRaw;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == turnOnAnimation.Length - 1)
        {
            menuScreenIndex = 34;
            animationIndex = 0;
        }
    }

    private void GamePlay()
    {
        //W & S to change optionIndex
        if (Input.GetKeyDown("w"))
        {
            menuOptionIndex -= 1;
        }
        if (Input.GetKeyDown("s"))
        {
            menuOptionIndex += 1;
        }

        /* BACK TO INITIAL OPTION */
        if (menuOptionIndex < 0)
        {
            menuOptionIndex = gameplayImageMenu.Length - 1;
        }
        if (menuOptionIndex > gameplayImageMenu.Length - 1)
        {
            menuOptionIndex = 0;
        }
        /*BACK TO INITIAL OPTION*/

        for (int i = 0; i < gameplayImageMenu.Length; i++)
        {
            if (i == menuOptionIndex)
            {
                gameplayImageMenu[menuOptionIndex].texture = menuButtonWhite;
                gameplayTextMenu[menuOptionIndex].color = Color.white;
            }
            else
            {
                gameplayImageMenu[i].texture = menuButtonNormal;
                gameplayTextMenu[i].color = Color.white;
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && (menuOptionIndex == 0))
        {
            difficultyIndex--;
            if (difficultyIndex < 0)
            {
                difficultyIndex = 2;
            }
            gameplayOptions[0].text = difficulties[difficultyIndex];
        }

        if (Input.GetKeyDown(KeyCode.D) && (menuOptionIndex == 0))
        {
            difficultyIndex++;
            if (difficultyIndex == difficulties.Length)
            {
                difficultyIndex = 0;
            }
            gameplayOptions[0].text = difficulties[difficultyIndex];
        }

        if (Input.GetKeyDown(KeyCode.A) && (menuOptionIndex == 1))
        {
            subtitlesIndex--;
            if (subtitlesIndex < 0)
            {
                subtitlesIndex = 1;
            }
            gameplayOptions[1].text = subtitles[subtitlesIndex];
        }

        if (Input.GetKeyDown(KeyCode.D) && (menuOptionIndex == 1))
        {
            subtitlesIndex++;
            if (subtitlesIndex > subtitles.Length - 1)
            {
                subtitlesIndex = 0;
            }
            gameplayOptions[1].text = subtitles[subtitlesIndex];
        }

        if ((Input.GetMouseButtonDown(0)) && (menuOptionIndex == 2))
        {
            menuScreenIndex = 35;
            animationIndex = 0;
            timeToNext = timeToNextInitial;
        }
    }

    private void GamePlayOff()
    {
        ////////Logo
        GameObject logo = gameplayMenu.transform.GetChild(0).gameObject;
        RawImage logoRaw = logo.GetComponent<RawImage>();

        Color alphaLogo = logoRaw.color;
        alphaLogo.a = turnOffAnimation[animationIndex];
        logoRaw.color = alphaLogo;

        //Text
        GameObject text = gameplayMenu.transform.GetChild(1).gameObject;
        Text textRaw = text.GetComponent<Text>();

        Color alphaText = textRaw.color;
        alphaText.a = turnOffAnimation[animationIndex];
        textRaw.color = alphaText;

        //DifficultyOption
        GameObject OptionFather = gameplayMenu.transform.GetChild(2).gameObject;
        RawImage OptionsFatherRaw = OptionFather.GetComponent<RawImage>();

        Color alphaOptionsFather = OptionsFatherRaw.color;
        alphaOptionsFather.a = turnOffAnimation[animationIndex];
        OptionsFatherRaw.color = alphaOptionsFather;

        //DifficultyOption 1
        GameObject OptionChildText = OptionFather.transform.GetChild(0).gameObject;
        Text ChildTextRaw = OptionChildText.GetComponent<Text>();

        Color alphaChildText = ChildTextRaw.color;
        alphaChildText.a = turnOffAnimation[animationIndex];
        ChildTextRaw.color = alphaChildText;

        //DifficultyOption 2
        GameObject OptionChildImage0 = OptionFather.transform.GetChild(1).gameObject;
        RawImage ChildImage1Raw = OptionChildImage0.GetComponent<RawImage>();

        Color alphaChildImage1 = ChildImage1Raw.color;
        alphaChildImage1.a = turnOffAnimation[animationIndex];
        ChildImage1Raw.color = alphaChildImage1;

        //DifficultyOption 3
        GameObject OptionChildImage2 = OptionFather.transform.GetChild(2).gameObject;
        RawImage ChildImage2Raw = OptionChildImage2.GetComponent<RawImage>();

        Color alphaChildImage2 = ChildImage2Raw.color;
        alphaChildImage2.a = turnOffAnimation[animationIndex];
        ChildImage2Raw.color = alphaChildImage2;

        //DifficultyOption 3
        GameObject OptionChildText2 = OptionFather.transform.GetChild(3).gameObject;
        Text ChildText2Raw = OptionChildText2.GetComponent<Text>();

        Color alphaChildText2 = ChildText2Raw.color;
        alphaChildText2.a = turnOffAnimation[animationIndex];
        ChildText2Raw.color = alphaChildText2;

        //subtitlesImage
        GameObject OptionMother = gameplayMenu.transform.GetChild(3).gameObject;
        RawImage OptionsMotherRaw = OptionMother.GetComponent<RawImage>();

        Color alphaOptionsMother = OptionsMotherRaw.color;
        alphaOptionsMother.a = turnOffAnimation[animationIndex];
        OptionsMotherRaw.color = alphaOptionsMother;

        //subtitlesText
        GameObject OptionMotherImage0 = OptionMother.transform.GetChild(0).gameObject;
        Text ChildMother0Raw = OptionMotherImage0.GetComponent<Text>();

        Color alphaChildMother0 = ChildMother0Raw.color;
        alphaChildMother0.a = turnOffAnimation[animationIndex];
        ChildMother0Raw.color = alphaChildMother0;

        //subtitlesImage1
        GameObject OptionMotherImage1 = OptionMother.transform.GetChild(1).gameObject;
        RawImage ChildMother1Raw = OptionMotherImage1.GetComponent<RawImage>();

        Color alphaChildMother1 = ChildMother1Raw.color;
        alphaChildMother1.a = turnOffAnimation[animationIndex];
        ChildMother1Raw.color = alphaChildMother1;

        //subtitlesImage2
        GameObject OptionMotherImage2 = OptionMother.transform.GetChild(2).gameObject;
        RawImage ChildMother2Raw = OptionMotherImage2.GetComponent<RawImage>();

        Color alphaChildMother2 = ChildMother2Raw.color;
        alphaChildMother2.a = turnOffAnimation[animationIndex];
        ChildMother2Raw.color = alphaChildMother2;

        //subtitlesImage2
        GameObject OptionMotherImage3 = OptionMother.transform.GetChild(3).gameObject;
        Text ChildMother3Raw = OptionMotherImage3.GetComponent<Text>();

        Color alphaChildMother3 = ChildMother3Raw.color;
        alphaChildMother3.a = turnOffAnimation[animationIndex];
        ChildMother3Raw.color = alphaChildMother3;

        //BackImage
        GameObject backImage = gameplayMenu.transform.GetChild(4).gameObject;
        RawImage backImageRaw = backImage.GetComponent<RawImage>();

        Color alphaBackImageRaw = backImageRaw.color;
        alphaBackImageRaw.a = turnOffAnimation[animationIndex];
        backImageRaw.color = alphaBackImageRaw;

        //BackText
        GameObject backText = backImage.transform.GetChild(0).gameObject;
        Text backTextRaw = backText.GetComponent<Text>();

        Color alphaBackTextRawRaw = backTextRaw.color;
        alphaBackTextRawRaw.a = turnOffAnimation[animationIndex];
        backTextRaw.color = alphaBackTextRawRaw;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == turnOnAnimation.Length - 1)
        {
            menuScreenIndex = 21;
            animationIndex = 0;
        }
    }

    private void CreditsMenuOn()
    {
        //////LOGOS
        GameObject logo = creditMenu.transform.GetChild(0).gameObject;

        //Metanoia Logo
        GameObject metanoia = logo.transform.GetChild(0).gameObject;
        RawImage metaLogo = metanoia.GetComponent<RawImage>();

        Color alphaMetaLogo = metaLogo.color;
        alphaMetaLogo.a = turnOnAnimation[animationIndex];
        metaLogo.color = alphaMetaLogo;

        //Merakkie Logo
        GameObject merakkie = logo.transform.GetChild(1).gameObject;
        RawImage meraLogo = merakkie.GetComponent<RawImage>();

        Color alphaMeraLogo = meraLogo.color;
        alphaMeraLogo.a = turnOnAnimation[animationIndex];
        meraLogo.color = alphaMeraLogo;

        //Unity Logo
        GameObject unity = logo.transform.GetChild(2).gameObject;
        RawImage unityLogo = unity.GetComponent<RawImage>();

        Color alphaUnity = unityLogo.color;
        alphaUnity.a = turnOnAnimation[animationIndex];
        unityLogo.color = alphaUnity;

        //Epidemic Logo
        GameObject epidemic = logo.transform.GetChild(3).gameObject;
        RawImage epicLogo = epidemic.GetComponent<RawImage>();

        Color alphaEpic = epicLogo.color;
        alphaEpic.a = turnOnAnimation[animationIndex];
        epicLogo.color = alphaEpic;

        //////BACK BUTTON
        GameObject backFather = creditMenu.transform.GetChild(1).gameObject;
        RawImage backFatherImage = backFather.GetComponent<RawImage>();

        Color alphaBackButton = backFatherImage.color;
        alphaBackButton.a = turnOnAnimation[animationIndex];
        backFatherImage.color = alphaBackButton;

        GameObject backText = backFather.transform.GetChild(0).gameObject;
        Text back = backText.GetComponent<Text>();

        Color alphaBack = back.color;
        alphaBack.a = turnOnAnimation[animationIndex];
        back.color = alphaBack;

        //////LINES
        GameObject lines = creditMenu.transform.GetChild(2).gameObject;

        GameObject line0 = lines.transform.GetChild(0).gameObject;
        RawImage line0Raw = line0.GetComponent<RawImage>();

        Color alphaline0 = line0Raw.color;
        alphaline0.a = turnOnAnimation[animationIndex];
        line0Raw.color = alphaline0;

        GameObject line1 = lines.transform.GetChild(1).gameObject;
        RawImage line1Raw = line1.GetComponent<RawImage>();

        Color alphaline1 = line1Raw.color;
        alphaline1.a = turnOnAnimation[animationIndex];
        line1Raw.color = alphaline1;

        GameObject line2 = lines.transform.GetChild(2).gameObject;
        RawImage line2Raw = line2.GetComponent<RawImage>();

        Color alphaline2 = line2Raw.color;
        alphaline2.a = turnOnAnimation[animationIndex];
        line2Raw.color = alphaline2;

        GameObject line3 = lines.transform.GetChild(3).gameObject;
        RawImage line3Raw = line3.GetComponent<RawImage>();

        Color alphaline3 = line3Raw.color;
        alphaline3.a = turnOnAnimation[animationIndex];
        line3Raw.color = alphaline3;

        GameObject line4 = lines.transform.GetChild(4).gameObject;
        RawImage line4Raw = line4.GetComponent<RawImage>();

        Color alphaline4 = line4Raw.color;
        alphaline4.a = turnOnAnimation[animationIndex];
        line4Raw.color = alphaline4;

        GameObject line5 = lines.transform.GetChild(5).gameObject;
        RawImage line5Raw = line5.GetComponent<RawImage>();

        Color alphaline5 = line5Raw.color;
        alphaline5.a = turnOnAnimation[animationIndex];
        line5Raw.color = alphaline5;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == turnOnAnimation.Length - 1)
        {
            menuScreenIndex = 19;
            animationIndex = 0;
            timeToNext = timeToNextInitial;
        }
    }
    private void CreditsMenu()
    {
        if (Input.GetMouseButtonDown(0))
        {
            menuOptionIndex = 0;
            menuScreenIndex = 20;
            animationIndex = 0;
            creditsBool = false;
        }
    }
    private void CreditsMenuOff()
    {
        //////LOGOS
        GameObject logo = creditMenu.transform.GetChild(0).gameObject;

        //Metanoia Logo
        GameObject metanoia = logo.transform.GetChild(0).gameObject;
        RawImage metaLogo = metanoia.GetComponent<RawImage>();

        Color alphaMetaLogo = metaLogo.color;
        alphaMetaLogo.a = turnOffAnimation[animationIndex];
        metaLogo.color = alphaMetaLogo;

        //Merakkie Logo
        GameObject merakkie = logo.transform.GetChild(1).gameObject;
        RawImage meraLogo = merakkie.GetComponent<RawImage>();

        Color alphaMeraLogo = meraLogo.color;
        alphaMeraLogo.a = turnOffAnimation[animationIndex];
        meraLogo.color = alphaMeraLogo;

        //Unity Logo
        GameObject unity = logo.transform.GetChild(2).gameObject;
        RawImage unityLogo = unity.GetComponent<RawImage>();

        Color alphaUnity = unityLogo.color;
        alphaUnity.a = turnOffAnimation[animationIndex];
        unityLogo.color = alphaUnity;

        //Epidemic Logo
        GameObject epidemic = logo.transform.GetChild(3).gameObject;
        RawImage epicLogo = epidemic.GetComponent<RawImage>();

        Color alphaEpic = epicLogo.color;
        alphaEpic.a = turnOffAnimation[animationIndex];
        epicLogo.color = alphaEpic;

        //////BACK BUTTON
        GameObject backFather = creditMenu.transform.GetChild(1).gameObject;
        RawImage backFatherImage = backFather.GetComponent<RawImage>();

        Color alphaBackButton = backFatherImage.color;
        alphaBackButton.a = turnOffAnimation[animationIndex];
        backFatherImage.color = alphaBackButton;

        GameObject backText = backFather.transform.GetChild(0).gameObject;
        Text back = backText.GetComponent<Text>();

        Color alphaBackImage = back.color;
        alphaBackImage.a = turnOffAnimation[animationIndex];
        back.color = alphaBackImage;

        Color alphaBack = back.color;
        alphaBack.a = turnOffAnimation[animationIndex];
        back.color = alphaBack;

        //////LINES
        GameObject lines = creditMenu.transform.GetChild(2).gameObject;

        GameObject line0 = lines.transform.GetChild(0).gameObject;
        RawImage line0Raw = line0.GetComponent<RawImage>();

        Color alphaline0 = line0Raw.color;
        alphaline0.a = turnOffAnimation[animationIndex];
        line0Raw.color = alphaline0;

        GameObject line1 = lines.transform.GetChild(1).gameObject;
        RawImage line1Raw = line1.GetComponent<RawImage>();

        Color alphaline1 = line1Raw.color;
        alphaline1.a = turnOffAnimation[animationIndex];
        line1Raw.color = alphaline1;

        GameObject line2 = lines.transform.GetChild(2).gameObject;
        RawImage line2Raw = line2.GetComponent<RawImage>();

        Color alphaline2 = line2Raw.color;
        alphaline2.a = turnOffAnimation[animationIndex];
        line2Raw.color = alphaline2;

        GameObject line3 = lines.transform.GetChild(3).gameObject;
        RawImage line3Raw = line3.GetComponent<RawImage>();

        Color alphaline3 = line3Raw.color;
        alphaline3.a = turnOffAnimation[animationIndex];
        line3Raw.color = alphaline3;

        GameObject line4 = lines.transform.GetChild(4).gameObject;
        RawImage line4Raw = line4.GetComponent<RawImage>();

        Color alphaline4 = line4Raw.color;
        alphaline4.a = turnOffAnimation[animationIndex];
        line4Raw.color = alphaline4;

        GameObject line5 = lines.transform.GetChild(5).gameObject;
        RawImage line5Raw = line5.GetComponent<RawImage>();

        Color alphaline5 = line5Raw.color;
        alphaline5.a = turnOffAnimation[animationIndex];
        line5Raw.color = alphaline5;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == turnOffAnimation.Length - 1)
        {
            animationIndex = 0;
            menuScreenIndex = 15;
            timeToNext = timeToNextInitial;
            mainMenuBool = true;

        }
    }
    private void PlayOn()
    {
        ////////Logo
        GameObject logo = playMenu.transform.GetChild(0).gameObject;
        RawImage logoRaw = logo.GetComponent<RawImage>();

            Color alphaLogo = logoRaw.color;
            alphaLogo.a = turnOnAnimation[animationIndex];
            logoRaw.color = alphaLogo;

        //Swing abaixo
        //PlayGameFather 1
        GameObject play = playMenu.transform.GetChild(1).gameObject;
        RawImage playRaw = play.GetComponent<RawImage>();

            Color alphaPlay = playRaw.color;
            alphaPlay.a = turnOnAnimation[animationIndex];
            playRaw.color = alphaPlay;

        //Son Father 1
        GameObject playGame = play.transform.GetChild(0).gameObject;
        Text playGameRaw = playGame.GetComponent<Text>();

            Color alphaPlayText = playGameRaw.color;
            alphaPlayText.a = turnOnAnimation[animationIndex];
            playGameRaw.color = alphaPlayText;

        //PlayGameDemoFather 2
        GameObject playDemo = playMenu.transform.GetChild(2).gameObject;
        RawImage playDemoRaw = playDemo.GetComponent<RawImage>();

            Color alphaPlayDemo = playDemoRaw.color;
            alphaPlayDemo.a = turnOnAnimation[animationIndex];
            playDemoRaw.color = alphaPlayDemo;

        //Son Father 2
        GameObject playGameDemo = playDemo.transform.GetChild(0).gameObject;
        Text playDemoTextRaw = playGameDemo.GetComponent<Text>();

            Color alphaPlayDemoText = playDemoTextRaw.color;
            alphaPlayDemoText.a = turnOnAnimation[animationIndex];
            playDemoTextRaw.color = alphaPlayDemoText;

        //PlayGameDemo Mother 1
        GameObject LoadGame = playMenu.transform.GetChild(3).gameObject;
        RawImage LoadGameRaw = LoadGame.GetComponent<RawImage>();

            Color alphaLoadGame = LoadGameRaw.color;
            alphaLoadGame.a = turnOnAnimation[animationIndex];
            LoadGameRaw.color = alphaLoadGame;

        //Son Mother 1
        GameObject LoadGameText = LoadGame.transform.GetChild(0).gameObject;
        Text LoadGameTextRaw = LoadGameText.GetComponent<Text>();

            Color alphaLoadGameText = LoadGameTextRaw.color;
            alphaLoadGameText.a = turnOnAnimation[animationIndex];
            LoadGameTextRaw.color = alphaLoadGameText;

        //PlayGameDemo Mother 2
        GameObject back = playMenu.transform.GetChild(4).gameObject;
        RawImage backRaw = back.GetComponent<RawImage>();

            Color alphaBack = backRaw.color;
            alphaBack.a = turnOnAnimation[animationIndex];
            backRaw.color = alphaBack;

        //Son Mother 2
        GameObject backText = back.transform.GetChild(0).gameObject;
        Text backTextRaw = backText.GetComponent<Text>();

            Color alphaBackText = backTextRaw.color;
            alphaBackText.a = turnOnAnimation[animationIndex];
            backTextRaw.color = alphaBackText;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == turnOnAnimation.Length - 1)
        {
            menuScreenIndex = 37;
            animationIndex = 0;
            menuOptionIndex = 0;
        }
    }
    private void Play()
    {

        //W & S to change optionIndex
        if (Input.GetKeyDown("w"))
        {
            menuOptionIndex -= 1;
        }
        if (Input.GetKeyDown("s"))
        {
            menuOptionIndex += 1;
        }

        /* BACK TO INITIAL OPTION */
        if (menuOptionIndex < 0)
        {
            menuOptionIndex = playMenuButtons.Length - 1;
        }
        if (menuOptionIndex > playMenuButtons.Length - 1)
        {
            menuOptionIndex = 0;
        }
        /*BACK TO INITIAL OPTION*/

        for (int i = 0; i < playMenuButtons.Length; i++)
        {
            if (i == menuOptionIndex)
            {
                playMenuButtons[menuOptionIndex].texture = menuButtonWhite;
                playMenuText[menuOptionIndex].color = Color.white;
            }
            else
            {
                playMenuButtons[i].texture = menuButtonNormal;
                playMenuText[i].color = Color.white;
            }
        }

        if (Input.GetMouseButtonDown(0) && (menuOptionIndex == 0))
        {
            playGameBool = true;
            alreadyStarted = true;
            menuScreenIndex = 38;
        }
        if (Input.GetMouseButtonDown(0) && (menuOptionIndex == 1))
        {
            playDemoBool = true;
            alreadyStarted = true;
            menuScreenIndex = 38;
        }
        if (Input.GetMouseButtonDown(0) && (menuOptionIndex == 2))
        {
            loadGame = true;
            menuScreenIndex = 38;
        }

        if (Input.GetMouseButtonDown(0) && (menuOptionIndex == 3))
        {
            backBool = true;
            menuOptionIndex = 0;
            menuScreenIndex = 38;
        }

    }
    private void PlayOff()
    {
        ////////Logo
        GameObject logo = playMenu.transform.GetChild(0).gameObject;
        RawImage logoRaw = logo.GetComponent<RawImage>();

        Color alphaLogo = logoRaw.color;
        alphaLogo.a = turnOffAnimation[animationIndex];
        logoRaw.color = alphaLogo;

        //Swing abaixo
        //PlayGameFather 1
        GameObject play = playMenu.transform.GetChild(1).gameObject;
        RawImage playRaw = play.GetComponent<RawImage>();

        Color alphaPlay = playRaw.color;
        alphaPlay.a = turnOffAnimation[animationIndex];
        playRaw.color = alphaPlay;

        //Son Father 1
        GameObject playGame = play.transform.GetChild(0).gameObject;
        Text playGameRaw = playGame.GetComponent<Text>();

        Color alphaPlayText = playGameRaw.color;
        alphaPlayText.a = turnOffAnimation[animationIndex];
        playGameRaw.color = alphaPlayText;

        //PlayGameDemoFather 2
        GameObject playDemo = playMenu.transform.GetChild(2).gameObject;
        RawImage playDemoRaw = playDemo.GetComponent<RawImage>();

        Color alphaPlayDemo = playDemoRaw.color;
        alphaPlayDemo.a = turnOffAnimation[animationIndex];
        playDemoRaw.color = alphaPlayDemo;

        //Son Father 2
        GameObject playGameDemo = playDemo.transform.GetChild(0).gameObject;
        Text playDemoTextRaw = playGameDemo.GetComponent<Text>();

        Color alphaPlayDemoText = playDemoTextRaw.color;
        alphaPlayDemoText.a = turnOffAnimation[animationIndex];
        playDemoTextRaw.color = alphaPlayDemoText;

        //PlayGameDemo Mother 1
        GameObject LoadGame = playMenu.transform.GetChild(3).gameObject;
        RawImage LoadGameRaw = LoadGame.GetComponent<RawImage>();

        Color alphaLoadGame = LoadGameRaw.color;
        alphaLoadGame.a = turnOffAnimation[animationIndex];
        LoadGameRaw.color = alphaLoadGame;

        //Son Mother 1
        GameObject LoadGameText = LoadGame.transform.GetChild(0).gameObject;
        Text LoadGameTextRaw = LoadGameText.GetComponent<Text>();

        Color alphaLoadGameText = LoadGameTextRaw.color;
        alphaLoadGameText.a = turnOffAnimation[animationIndex];
        LoadGameTextRaw.color = alphaLoadGameText;

        //PlayGameDemo Mother 2
        GameObject back = playMenu.transform.GetChild(4).gameObject;
        RawImage backRaw = back.GetComponent<RawImage>();

        Color alphaBack = backRaw.color;
        alphaBack.a = turnOffAnimation[animationIndex];
        backRaw.color = alphaBack;

        //Son Mother 2
        GameObject backText = back.transform.GetChild(0).gameObject;
        Text backTextRaw = backText.GetComponent<Text>();

        Color alphaBackText = backTextRaw.color;
        alphaBackText.a = turnOffAnimation[animationIndex];
        backTextRaw.color = alphaBackText;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == turnOnAnimation.Length - 1)
        {
            if (playGameBool == true)
            {
                alreadyStarted = true;
                SceneManager.LoadScene("Rocca Inside");
                control.startedGame = true;
                playDemoBool = false;
                playGameBool = false;
            }
            if (playDemoBool == true)
            {
                alreadyStarted = true;
                SceneManager.LoadScene("Prototype");
                control.startedGame = true;
                playDemoBool = false;

            }
            if (loadGame == true)
            {
                menuScreenIndex = 39;
                loadGame = false;

            }
            if (backBool == true)
            {
                menuScreenIndex = 15;
                backBool = false;
            }

        }
    }

    private void LoadGameOn()
    {
        ////////Logo
        GameObject logo = loadMenu.transform.GetChild(0).gameObject;
        RawImage logoRaw = logo.GetComponent<RawImage>();

            Color alphaLogo = logoRaw.color;
            alphaLogo.a = turnOnAnimation[animationIndex];
            logoRaw.color = alphaLogo;

        //Lines - Father
        GameObject lineFather = loadMenu.transform.GetChild(1).gameObject;
        //Lines - Sons
        GameObject line0 = lineFather.transform.GetChild(0).gameObject;
        RawImage line0Raw = line0.GetComponent<RawImage>();

            Color alphaLine0 = line0Raw.color;
            alphaLine0.a = turnOnAnimation[animationIndex];
            line0Raw.color = alphaLine0;

        GameObject line1 = lineFather.transform.GetChild(1).gameObject;
        RawImage line1Raw = line1.GetComponent<RawImage>();

            Color alphaLine1 = line1Raw.color;
            alphaLine1.a = turnOnAnimation[animationIndex];
            line1Raw.color = alphaLine1;

        GameObject line2 = lineFather.transform.GetChild(2).gameObject;
        RawImage line2Raw = line2.GetComponent<RawImage>();

            Color alphaLine2 = line2Raw.color;
            alphaLine2.a = turnOnAnimation[animationIndex];
            line2Raw.color = alphaLine2;

        GameObject line3 = lineFather.transform.GetChild(3).gameObject;
        RawImage line3Raw = line3.GetComponent<RawImage>();

            Color alphaLine3 = line3Raw.color;
            alphaLine3.a = turnOnAnimation[animationIndex];
            line3Raw.color = alphaLine3;

        GameObject line4 = lineFather.transform.GetChild(4).gameObject;
        RawImage line4Raw = line4.GetComponent<RawImage>();

            Color alphaLine4 = line4Raw.color;
            alphaLine4.a = turnOnAnimation[animationIndex];
            line4Raw.color = alphaLine4;

        GameObject line5 = lineFather.transform.GetChild(5).gameObject;
        RawImage line5Raw = line5.GetComponent<RawImage>();

            Color alphaLine5 = line5Raw.color;
            alphaLine5.a = turnOnAnimation[animationIndex];
            line5Raw.color = alphaLine5;
        //Lines - Father


        //TextLoadGame
        GameObject loadGameText = loadMenu.transform.GetChild(2).gameObject;

        GameObject LoadText0 = loadGameText.transform.GetChild(0).gameObject;
        Text LoadText0Raw = LoadText0.GetComponent<Text>();

            Color alphaText0 = LoadText0Raw.color;
            alphaText0.a = turnOnAnimation[animationIndex];
            LoadText0Raw.color = alphaText0;

        GameObject LoadText1 = loadGameText.transform.GetChild(1).gameObject;
        Text LoadText1Raw = LoadText1.GetComponent<Text>();

            Color alphaText1 = LoadText1Raw.color;
            alphaText1.a = turnOnAnimation[animationIndex];
            LoadText1Raw.color = alphaText1;

        GameObject LoadText2 = loadGameText.transform.GetChild(2).gameObject;
        Text LoadText2Raw = LoadText2.GetComponent<Text>();

            Color alphaText2 = LoadText2Raw.color;
            alphaText2.a = turnOnAnimation[animationIndex];
            LoadText2Raw.color = alphaText2;

        //BackButton
        GameObject back = loadMenu.transform.GetChild(3).gameObject;
        RawImage backRaw = back.GetComponent<RawImage>();

            Color alphaBack = backRaw.color;
            alphaBack.a = turnOnAnimation[animationIndex];
            backRaw.color = alphaBack;

        GameObject backText = back.transform.GetChild(0).gameObject;
        Text backTextRaw = backText.GetComponent<Text>();

            Color alphaBackText = backTextRaw.color;
            alphaBackText.a = turnOnAnimation[animationIndex];
            backTextRaw.color = alphaBackText;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == turnOnAnimation.Length - 1)
        {
            menuScreenIndex = 40;
            animationIndex = 0;
            menuOptionIndex = 0;
        }
    }

    private void LoadGame()
    {
        if (Input.GetMouseButtonDown(0))
        {
            menuScreenIndex = 41;
        }
    }

    private void LoadGameOff()
    {
        ////////Logo
        GameObject logo = loadMenu.transform.GetChild(0).gameObject;
        RawImage logoRaw = logo.GetComponent<RawImage>();

            Color alphaLogo = logoRaw.color;
            alphaLogo.a = turnOffAnimation[animationIndex];
            logoRaw.color = alphaLogo;

        //Lines - Father
        GameObject lineFather = loadMenu.transform.GetChild(1).gameObject;
        //Lines - Sons
        GameObject line0 = lineFather.transform.GetChild(0).gameObject;
        RawImage line0Raw = line0.GetComponent<RawImage>();

            Color alphaLine0 = line0Raw.color;
            alphaLine0.a = turnOffAnimation[animationIndex];
            line0Raw.color = alphaLine0;

        GameObject line1 = lineFather.transform.GetChild(1).gameObject;
        RawImage line1Raw = line1.GetComponent<RawImage>();

            Color alphaLine1 = line1Raw.color;
            alphaLine1.a = turnOffAnimation[animationIndex];
            line1Raw.color = alphaLine1;

        GameObject line2 = lineFather.transform.GetChild(2).gameObject;
        RawImage line2Raw = line2.GetComponent<RawImage>();

            Color alphaLine2 = line2Raw.color;
            alphaLine2.a = turnOffAnimation[animationIndex];
            line2Raw.color = alphaLine2;

        GameObject line3 = lineFather.transform.GetChild(3).gameObject;
        RawImage line3Raw = line3.GetComponent<RawImage>();

            Color alphaLine3 = line3Raw.color;
            alphaLine3.a = turnOffAnimation[animationIndex];
            line3Raw.color = alphaLine3;

        GameObject line4 = lineFather.transform.GetChild(4).gameObject;
        RawImage line4Raw = line4.GetComponent<RawImage>();

            Color alphaLine4 = line4Raw.color;
            alphaLine4.a = turnOffAnimation[animationIndex];
            line4Raw.color = alphaLine4;

        GameObject line5 = lineFather.transform.GetChild(5).gameObject;
        RawImage line5Raw = line5.GetComponent<RawImage>();

            Color alphaLine5 = line5Raw.color;
            alphaLine5.a = turnOffAnimation[animationIndex];
            line5Raw.color = alphaLine5;
        //Lines - Father


        //TextLoadGame
        GameObject loadGameText = loadMenu.transform.GetChild(2).gameObject;

        GameObject LoadText0 = loadGameText.transform.GetChild(0).gameObject;
        Text LoadText0Raw = LoadText0.GetComponent<Text>();

            Color alphaText0 = LoadText0Raw.color;
            alphaText0.a = turnOffAnimation[animationIndex];
            LoadText0Raw.color = alphaText0;

        GameObject LoadText1 = loadGameText.transform.GetChild(1).gameObject;
        Text LoadText1Raw = LoadText1.GetComponent<Text>();

            Color alphaText1 = LoadText1Raw.color;
            alphaText1.a = turnOffAnimation[animationIndex];
            LoadText1Raw.color = alphaText1;

        GameObject LoadText2 = loadGameText.transform.GetChild(2).gameObject;
        Text LoadText2Raw = LoadText2.GetComponent<Text>();

            Color alphaText2 = LoadText2Raw.color;
            alphaText2.a = turnOffAnimation[animationIndex];
            LoadText2Raw.color = alphaText2;

        //BackButton
        GameObject back = loadMenu.transform.GetChild(3).gameObject;
        RawImage backRaw = back.GetComponent<RawImage>();

            Color alphaBack = backRaw.color;
            alphaBack.a = turnOffAnimation[animationIndex];
            backRaw.color = alphaBack;

        GameObject backText = back.transform.GetChild(0).gameObject;
        Text backTextRaw = backText.GetComponent<Text>();

            Color alphaBackText = backTextRaw.color;
            alphaBackText.a = turnOffAnimation[animationIndex];
            backTextRaw.color = alphaBackText;

        timeToNext -= Time.deltaTime;

        if (timeToNext <= 0)
        {
            animationIndex += 1;
            timeToNext = timeToNextInitial;
        }

        if (animationIndex == turnOnAnimation.Length - 1)
        {
            menuScreenIndex = 36;
            backBool = false;
            animationIndex = 0;
            menuOptionIndex = 0;
        }
    }
}
