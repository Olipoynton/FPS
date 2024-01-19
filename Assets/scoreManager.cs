using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;

    public Text scoreText;
    public Text highScoreText;

    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);

        scoreText.text = score.ToString() + " :SCORE";
        highScoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void addPoint()
    {
        score += 100;
        scoreText.text = score.ToString() + " :SCORE";

        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }

    }

    public void takePoint()
    {
        score = 0;
        scoreText.text = score.ToString() + " :SCORE";

        
    }

    private void Update()
    {
        if (score > highscore)
        {
            highscore = PlayerPrefs.GetInt("highscore", 0);
            highScoreText.text = "HIGHSCORE: " + highscore.ToString();
        }
    }
} 
