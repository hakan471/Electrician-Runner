using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{
    const string privateCode = "frwSqI72KEKw-wEefZtJ4g8TdU4Ea_PE-kd7T5M0kZ1g";
    const string publicCode = "62a2e2198f40bb11c07946e2";
    const string webUrl = "http://dreamlo.com/lb/";

    public static Highscore[] highscoreList;

    public TextMeshProUGUI[] textScoreList;
    public static string activeLevel = "";
    void Awake()
    {
        //AddNewHighscore("Sebas9tion", 50);
        //AddNewHighscore("Mar8y", 85);
        //AddNewHighscore("Bob7", 92);
        //AddNewHighscore("Sebastio6n", 50);
        //AddNewHighscore("Mary5", 85);
        //AddNewHighscore("Bob4", 92);
        //AddNewHighscore("Sebastion2", 50);
        //AddNewHighscore("Mary3", 85);
        //AddNewHighscore("Bob2", 92);
        DownloadHighscores();

        
    }
    public void AddNewHighscore(string username, int score)
    {
        StartCoroutine(UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webUrl + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            print("Upload Successfull");
        }
        else
        {
            print("Error uploading:" + www.error);
        }
    }

    public void DownloadHighscores()
    {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }
    IEnumerator DownloadHighscoresFromDatabase()
    {
        WWW www = new WWW(webUrl + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.text);
        }
        else
        {
            print("Error downloading:" + www.error);
        }
    }

    void FormatHighscores(string textStream)
    {
        int count = 0;
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoreList = new Highscore[entries.Length];

        if (entries.Length <= 10) count = entries.Length;
        else count = 10;
        for (int i = 0; i < count; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoreList[i] = new Highscore(username, score);
            try
            {
                textScoreList[i].text = (i + 1) + " : " + highscoreList[i].username + " " + highscoreList[i].score;
            }
            catch { }
        }
    }
    public void ActiveScene()
    {
        SceneManager.LoadScene(activeLevel);
    }
}
public struct Highscore
{
    public string username;
    public int score;

    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}
