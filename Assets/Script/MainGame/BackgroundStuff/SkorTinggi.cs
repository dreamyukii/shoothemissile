using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class SkorTinggi : MonoBehaviour
{
    public static SkorTinggi instance;
    public Text scoreText;

    public Text highscoreText;

    int score = 0;

    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " Poin";
        highscoreText.text = "Skor Tinggi " + highscore.ToString();
    }
    public void tambahSkor()
    {
        score += 1;
        scoreText.text = score.ToString() + " Poin";
        if(highscore>score)
            PlayerPrefs.SetInt("highscore",score);
    }
}
