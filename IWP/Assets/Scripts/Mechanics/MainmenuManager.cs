using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainmenuManager : MonoBehaviour
{
    [Header("Levels to load")]
    public string _newGameLevel;
    private string levelToLoad;

    public void Startplay()
    {
        SceneManager.LoadScene("Level2");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
