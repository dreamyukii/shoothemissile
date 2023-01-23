using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuUtama : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        HitungSkor.scoreValue = 0;
    }
    
    public void Pengaturan()
    {
        SceneManager.LoadScene(2);
    }

    public void aboutMenu()
    {
        SceneManager.LoadScene(3);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
