using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HighscoreManager : MonoBehaviour
{
    public TextMeshProUGUI highscore;
    private void Update()
    {
        highscore.text = PlayerPrefs.GetInt("Highscore",0).ToString();
    }
}
