using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public float timeLimit = 180.0f;

    private int maxHealth = 100;
    public static int curHealth = 100;
    public static int score = 0;
    public static bool isPlayerAlive = true;

    void Update()
    {
        timeLimit -= Time.deltaTime;
        if(timeLimit <= 0)
        {
            Screen.showCursor = true;
            isPlayerAlive = false;
            Application.LoadLevel("GameOver");
        }

        if(curHealth <= 0)
        {
            Screen.showCursor = true;
            isPlayerAlive = false;
            Application.LoadLevel("GameOver");
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(65, 1, 100, 20), "Health");
        GUI.Box(new Rect(10, 20, 150, 20), curHealth + "/" + maxHealth);

        GUI.Label(new Rect(255, 1, 100, 20), "Score");
        GUI.Box(new Rect(200, 20, 150 , 20), "" + score);

        GUI.Label(new Rect(445, 1, 100, 20), "Time");
        GUI.Box(new Rect(390, 20, 150, 20), "" + Mathf.RoundToInt(timeLimit));
    }
}
