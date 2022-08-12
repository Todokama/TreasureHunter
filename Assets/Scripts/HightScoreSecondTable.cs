using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HightScoreSecondTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private static HightScoreSecondTable instance;
    private List<Transform> highscoreEntryTransformList;
    private List<HighscoreEntry> highscoreEntryList;

    private void Awake()
    {

        instance = this;
        entryContainer = transform.Find("ScoreContainer");
        entryTemplate = entryContainer.Find("ScoreTableTemplate");

        entryTemplate.gameObject.SetActive(false);

        

        string jsonString = PlayerPrefs.GetString("highscoreSeconTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {
            
            AddHighscoreEntry(0, "Player");
            AddHighscoreEntry(0, "Player");
            AddHighscoreEntry(0, "Player");
            AddHighscoreEntry(0, "Player");
            AddHighscoreEntry(0, "Player");
            AddHighscoreEntry(0, "Player");
            AddHighscoreEntry(0, "Player");
            AddHighscoreEntry(0, "Player");
            AddHighscoreEntry(0, "Player");
            AddHighscoreEntry(0, "Player");


            jsonString = PlayerPrefs.GetString("highscoreSeconTable");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        Transform entryTransform = Instantiate(entryTemplate, container);
        float templateHeight = 40f;
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default: rankString = rank.ToString(); break;
            case 1: rankString = "1ши"; break;
            case 2: rankString = "2ни"; break;
            case 3: rankString = "3хи"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;
        string name = highscoreEntry.name;

        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        int score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        transformList.Add(entryTransform);
    }

    public static void AddHighscoreEntry(int score, string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString("highscoreSeconTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {

            highscores = new Highscores()
            {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }

        highscores.highscoreEntryList.Add(highscoreEntry);

        string nameOfLast = "zxz";
        int scoreOfLast = 0;
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                    nameOfLast = tmp.name;
                    scoreOfLast = tmp.score;
                }
            }
        }

        int index = highscores.highscoreEntryList.FindIndex(x => x.name == nameOfLast);
        Debug.Log(index);
        highscores.highscoreEntryList.RemoveAt(index);
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreSeconTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }


    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }

}
