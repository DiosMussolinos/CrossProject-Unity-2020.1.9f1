using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuFunctions : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Inside");
    }

    public void ToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ToOptions()
    {
        SceneManager.LoadScene("OptionMenu");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
