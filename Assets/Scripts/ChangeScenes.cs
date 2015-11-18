using UnityEngine;
using System.Collections;

public class ChangeScenes : MonoBehaviour {

    public void ChangeScene(int scene) {
        Screen.showCursor = true;
        Application.LoadLevel(scene);
        if (scene == 1)
        {
            PlayerScript.curHealth = 100;
            PlayerScript.timeLimit = 180f;
            PlayerScript.score = 0;
            FireGunLevel1.bullets = 6;
            FireGunLevel1.clip = 1;
        }
       

	}
}
