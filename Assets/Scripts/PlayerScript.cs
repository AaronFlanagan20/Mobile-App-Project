using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public static float timeLimit = 300.0f;

    private int maxHealth = 100;
    public static int curHealth = 100;
    public static int score = 0;
    public static bool isPlayerAlive = true;

    public bool level1Complete;
    public bool level2Complete;
    public bool level3Complete;

    public static bool isLevel3 = false;

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

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        { 
            if (level1Complete)
            {
                Level1();
            }

            if (level2Complete)
            {
                Level2();
            }

            if (level3Complete)
            {
                Level3();
            }
        }
        else if (Input.GetMouseButton(0) && FireGunLevel1.bullets == 0 && FireGunLevel1.clip == 0)
         {
            Screen.showCursor = true;
            isPlayerAlive = false;
            Application.LoadLevel("GameOver");
         }
        else if (Input.GetMouseButton(0) && FireGunLevel2.bullets == 0 && FireGunLevel2.clip == 0)
        {
            Screen.showCursor = true;
            isPlayerAlive = false;
            Application.LoadLevel("GameOver");
        }
    }

    void Level1()
    {
        Screen.showCursor = true;
        int timeLeft = Mathf.RoundToInt(timeLimit);
        score += timeLeft;
        Application.LoadLevel("TransitionLevel2");
        timeLimit = 120.0f;
    }

    void Level2()
    {
        Screen.showCursor = true;
        int timeLeft = Mathf.RoundToInt(timeLimit);
        score += timeLeft;
        Application.LoadLevel("TransitionLevel3");
        Screen.showCursor = true;
        timeLimit = 180.0f;
        isLevel3 = true;
    }

    void Level3()
    {
        Screen.showCursor = true;
        int timeLeft = Mathf.RoundToInt(timeLimit);
        score += timeLeft;
        Application.LoadLevel("win");
        Screen.showCursor = true;
        http postScore = gameObject.GetComponent<http>();
        postScore.UpdateScores(score);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(65, 1, 100, 20), "Health");
        GUI.Box(new Rect(10, 20, 150, 20), curHealth + "/" + maxHealth);

        GUI.Label(new Rect(257, 1, 100, 20), "Score");
        GUI.Box(new Rect(200, 20, 150 , 20), "" + score);

        GUI.Label(new Rect(450, 1, 100, 20), "Time");
        GUI.Box(new Rect(390, 20, 150, 20), "" + Mathf.RoundToInt(timeLimit));

        if (level1Complete)
        {
            GUI.Label(new Rect(635, 1, 100, 20), "Bullets");
            GUI.Box(new Rect(580, 20, 150, 20), "" + FireGunLevel1.bullets);

            GUI.Label(new Rect(830, 1, 100, 20), "Clips");
            GUI.Box(new Rect(770, 20, 150, 20), "" + FireGunLevel1.clip);
        }

        if (level2Complete)
        {
            GUI.Label(new Rect(635, 1, 100, 20), "Bullets");
            GUI.Box(new Rect(580, 20, 150, 20), "" + FireGunLevel2.bullets);

            GUI.Label(new Rect(830, 1, 100, 20), "Clips");
            GUI.Box(new Rect(770, 20, 150, 20), "" + FireGunLevel2.clip);
        }

        if (level3Complete)
        {
            GUI.Label(new Rect(635, 1, 100, 20), "Bullets");
            GUI.Box(new Rect(580, 20, 150, 20), "" + FireGunLevel3.bullets);

            GUI.Label(new Rect(830, 1, 100, 20), "Clips");
            GUI.Box(new Rect(770, 20, 150, 20), "" + FireGunLevel3.clip);
        }

    }
}
