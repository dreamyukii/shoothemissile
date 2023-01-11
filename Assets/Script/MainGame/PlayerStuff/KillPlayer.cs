using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KillPlayer : MonoBehaviour
{
    private GameObject player;
    public GameObject gameOverPanel;
    public ScoreManager ScoreManager;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
            ScoreManager.FinalScore("Cope",ScoreState.instance._score);
        }
    }
    

    public void Awake()
    {
        ScoreManager = GetComponent<ScoreManager>();
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
}
