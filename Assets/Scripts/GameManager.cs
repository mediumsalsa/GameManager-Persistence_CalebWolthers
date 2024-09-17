using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    public float health;
    public float XP;

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

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Health: " + health);
        GUI.Label(new Rect(10, 40, 100, 30), "XP: " + XP);
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.health = health;
        data.XP = XP;

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
        }
    }


}


[Serializable]
class PlayerData
{

    public float health;
    public float XP;



}
