using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Loading");
        
        Time.timeScale = 1.0f;
    }
    public void Home()
    {
        SceneManager.LoadScene("Home");
    }
}
