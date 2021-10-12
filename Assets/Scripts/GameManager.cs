using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Ins;

    private void Awake()
    {
        if (Ins != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Ins = this;
        DontDestroyOnLoad(this.gameObject);
        LoadBestScore();
    }

    public string playerName;
    public string ChallengerName;
    public int bestScore;

    public void VerifyScore(int score)
    {
        if (score > bestScore)
        {
            bestScore = score;
            playerName = ChallengerName;
            SaveBestScore();
        }
    }

    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void SaveBestScore()
    {
        PlayerData newData = new PlayerData();

        newData.playerName = playerName;
        newData.bestScore = bestScore;

        string json = JsonUtility.ToJson(newData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            PlayerData newData = JsonUtility.FromJson<PlayerData>(json);

            playerName = newData.playerName;
            bestScore = newData.bestScore;
        }
    }

    public class PlayerData
    {
        public string playerName;
        public int bestScore;
    }
}