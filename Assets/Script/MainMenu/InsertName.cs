using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertName : MonoBehaviour
{
    public InputField InputText;
    public Text showText;
    void Start()
    {
        InputText.text = PlayerPrefs.GetString("player_name");
    }
    public void createName()
    {
        InputText.text = showText.text;
        PlayerPrefs.SetString("player_name",InputText.text);
        PlayerPrefs.Save();
    }

}
