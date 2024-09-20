using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public TMP_InputField inputField;
    public TMP_Text levelName;

    public float health;
    public float XP;
    public float score;
    public string playerName;
    public float scoreIncreaser;
    public float scoreIncreaserMultiplier;


    private void Awake()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        levelName.text = "Level " + currentSceneIndex;
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 24; 
        style.normal.textColor = Color.white;

        GUI.Label(new Rect(10, 10, 100, 30), "Health: " + health, style);
        GUI.Label(new Rect(10, 40, 100, 30), "XP: " + XP, style);
        GUI.Label(new Rect(10, 590, 100, 30), "Name: " + playerName, style);
        GUI.Label(new Rect(10, 625, 100, 30), "Score: " + score, style);
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.health = health;
        data.XP = XP;
        data.score = score;
        data.playerName = playerName;
        data.scoreIncreaser = scoreIncreaser;
        data.scoreIncreaserMultiplier = scoreIncreaserMultiplier;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            health = data.health;
            XP = data.XP;
            score = data.score;
            playerName = data.playerName;
            scoreIncreaser = data.scoreIncreaser;
            scoreIncreaserMultiplier = data.scoreIncreaserMultiplier;
        }
    }


}


[Serializable]
class PlayerData
{

    public float health;
    public float XP;
    public float score;
    public string playerName;
    public float scoreIncreaser;
    public float scoreIncreaserMultiplier;

}
