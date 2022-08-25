using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance;
    public string playerName;
    public int highScore;
    private string currentPlayerName;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }
    public void SetPlayerName(string playerName)
    {
        this.playerName = playerName;
    }

    internal void SetCurrentPlayerName(string name)
    {
        currentPlayerName = name;
    }

    public void SetHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            SaveHighScore();
        }
    }
    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.playerName = currentPlayerName;
        playerName = currentPlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            playerName = data.playerName;
        }
    }

    public void ResetHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = 0;
            playerName = "";
        }
    }
}