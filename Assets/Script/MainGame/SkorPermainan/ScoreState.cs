using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreState : MonoBehaviour
{
    public static ScoreState instance;
    [SerializeField] 
    public int _score = 0;

    public void AddScore(int score)
    {
        _score++;
    }
    
    public int getScore()
    {
        return _score;
    }

    private void Awake()
    {
        instance = this;
    }
}