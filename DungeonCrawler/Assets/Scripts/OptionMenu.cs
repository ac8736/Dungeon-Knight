using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    public string nextLevel;
    public void PlayGame() {
        SceneManager.LoadScene(nextLevel); 
    }

}
