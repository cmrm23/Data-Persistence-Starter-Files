using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class UITitle : MonoBehaviour
{
    public Text bestScoreText;
    public InputField nameText;

    private void Start()
    {
        string name = GameManager.Ins.playerName != "" ? GameManager.Ins.playerName : "AAAA";

        bestScoreText.text = "Best Score: " + name + " " + GameManager.Ins.bestScore + " Pts";
    }

    public void LoadGame()
    {
        if (nameText.text != "")
        {
            GameManager.Ins.ChallengerName = nameText.text;
            GameManager.Ins.LoadScene(1);
        }
    }

    public void ExitApp()
    {
        GameManager.Ins.SaveBestScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}