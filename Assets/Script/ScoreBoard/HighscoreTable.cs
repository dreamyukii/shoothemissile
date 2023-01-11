using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighScoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        
        entryTemplate.gameObject.SetActive(false);
        
        //AddHighScoreEntry(100,"Budi");

        string jsonString = PlayerPrefs.GetString("highScoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        
        //sorting
        for (int i= 0; i< highscores.highscoreEntryList.Count;i++)
        {
            for (int j = i+1; j < highscores.highscoreEntryList.Count;j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighScoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        
        
        highscoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highScoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highScoreEntry,entryContainer,highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighScoreEntry highscoreEntry,Transform container,List<Transform>transformList)
    {
        float templateHeight = 50f;
        Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform= entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);

            int rank = transformList.Count + 1;
            string rankString;
            switch (rank)
            {
                default: rankString = rank + "th"; break;
                case 1 : rankString = "1st"; break;
                case 2 : rankString = "2nd"; break;
                case 3 : rankString = "3nd "; break;
            }

            entryTransform.Find("posText").GetComponent<Text>().text = rankString;
            int score = highscoreEntry.score;
            
            entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();
            string name = highscoreEntry.name;
            entryTransform.Find("nameText").GetComponent<Text>().text = name;
            
            transformList.Add(entryTransform);
        }

    public void AddHighScoreEntry(int score,string name)
    {
        //Membuat highscore entry
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = score, name = name };
        
        //memuat highscore yang tersimpan
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        
        //menambahkan entri baru ke highscore
        highscores.highscoreEntryList.Add(highScoreEntry);

        //menyimpan highscore yang diupdate
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highScoreTable",json);
        PlayerPrefs.Save();
    }
    
    private class Highscores
    {
        public List<HighScoreEntry> highscoreEntryList;
    }
    [System.Serializable]
    private class HighScoreEntry
    {
        public int score;
        public string name;
    }
}
