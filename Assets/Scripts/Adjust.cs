using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Adjust : MonoBehaviour
{

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 100, 100, 30), "Health Up"))
        {
            GameManager.manager.health += 10;
        }
        if (GUI.Button(new Rect(10, 140, 100, 30), "Health Down"))
        {
            GameManager.manager.health -= 10;
        }
        if (GUI.Button(new Rect(10, 180, 100, 30), "XP Up"))
        {
            GameManager.manager.XP += 10;
        }
        if (GUI.Button(new Rect(10, 220, 100, 30), "XP Down"))
        {
            GameManager.manager.XP -= 10;
        }
        if (GUI.Button(new Rect(Screen.width / 2.25f, 400, 200, 60), "Score +" + GameManager.manager.scoreIncreaser))
        {
            GameManager.manager.score += GameManager.manager.scoreIncreaser;
        }
        if (GUI.Button(new Rect(Screen.width / 2.25f, 475, 200, 60), "Increase score button strength"))
        {
            GameManager.manager.scoreIncreaser += 1;
        }
        if (GUI.Button(new Rect(Screen.width / 2.25f, 550, 200, 60), "Multiply the score Increase by 2"))
        {
            GameManager.manager.scoreIncreaser *= 2;
        }


        if (GUI.Button(new Rect(10, 550, 200, 30), "Reset score and increasers"))
        {
            GameManager.manager.score = 0;
            GameManager.manager.scoreIncreaser = 0;
        }


        if (GUI.Button(new Rect(10, 260, 100, 30), "Save"))
        {
            GameManager.manager.Save();
        }
        if (GUI.Button(new Rect(10, 300, 100, 30), "Load"))
        {
            GameManager.manager.Load();
        }

        if (GUI.Button(new Rect(Screen.width - 120, 85, 100, 30), "Submit"))
        {
            GameManager.manager.playerName = GameManager.manager.inputField.text;
        }
    }

}
