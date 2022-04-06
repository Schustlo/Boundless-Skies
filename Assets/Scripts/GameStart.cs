using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{ 
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("FlipOutline");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
