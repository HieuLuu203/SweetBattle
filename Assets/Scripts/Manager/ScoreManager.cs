using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreManager Instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        if (score > PlayerPrefs.GetInt("Highscore", 0)) PlayerPrefs.SetInt("Highscore", score);
        highscoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }

    public int getScore()
    {
        return score;
    }
    public int getHighscore()
    {
        return PlayerPrefs.GetInt("Highscore", 0);
    }

    public void addScore(int num)
    {
        score+=num;
    }
}
