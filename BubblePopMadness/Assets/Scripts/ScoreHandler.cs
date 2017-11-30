using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public Text scoreText;
    public Text endScoreText;
    public Text highScoreText;
    public int score = 0;
    public int highscore;
	// Use this for initialization
	void Start ()
    {
        score = 0;
        highscore = PlayerPrefs.GetInt("HighScore");	
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("HighScore", highscore);
        }

        scoreText.text = "" + score;
        endScoreText.text = "" + score;
        highScoreText.text = "" + highscore;
	}
    public void AddScore()
    {
        score += 1;
    }
}
