using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingsMenu : MonoBehaviour
{
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void DeleteScoreboard()
    {
        PlayerPrefs.DeleteKey("scores");
    }
}
