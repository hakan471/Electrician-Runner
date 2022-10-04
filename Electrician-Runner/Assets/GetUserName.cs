using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetUserName : MonoBehaviour
{
    const string privateCode = "frwSqI72KEKw-wEefZtJ4g8TdU4Ea_PE-kd7T5M0kZ1g";
    const string publicCode = "62a2e2198f40bb11c07946e2";
    const string webUrl = "http://dreamlo.com/lb/";

    public TMP_InputField textMeshProUGUI;
    public void SaveButton()
    {
        AddNewHighscore(textMeshProUGUI.text, Move.scoreInt);
        Move.scoreInt = 0;
        SceneManager.LoadScene("Scene 3");
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
}
