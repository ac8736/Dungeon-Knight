using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void QuitGame() {
        Application.Quit();
    }

    public void PlayGame() {
        SceneManager.LoadScene("Intro");
    }

    public void Menu() {
        SceneManager.LoadScene("Menu");
    }
}
