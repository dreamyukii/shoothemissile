using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    private Rigidbody2D rigidBodyPlayer;
    public GameObject gameOverPanel;
    public static bool GameIsPaused = false;
    public static bool GameIsOver = false;
    public GameObject pauseMenu;
    public AudioSource sourceAudio;
    public AudioClip shootSound;
    public AudioClip deathSound;
    void Start()
    {
        rigidBodyPlayer = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&& !gameOverPanel.activeInHierarchy)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
        rigidBodyPlayer.velocity = new Vector2(moveSpeed, rigidBodyPlayer.velocity.y);
        if (!GameIsPaused && !GameIsOver)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                rigidBodyPlayer.velocity = new Vector2(rigidBodyPlayer.velocity.x, jumpForce);
            }

            if (Keyboard.current.enterKey.wasPressedThisFrame)
            {
                Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
                sourceAudio.PlayOneShot(shootSound);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameIsOver = true;
            sourceAudio.PlayOneShot(deathSound);
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }



    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        HitungSkor.scoreValue = 0;
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Paused()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void BackMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        GameIsPaused = false;
    }
}
