using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

	private bool isPaused = false;
    private int buttonWidth = 200;
    private int buttonHeight = 50;
    private int groupWidth = 200;
    private int groupHeight = 250;

    private void Update() { 
		if (Input.GetKeyDown(KeyCode.Escape)) { 
			if (isPaused) 
				ResumeGameMode(); 
			else 
				PauseGameMode(); 
		} 
	} 
	
	private void ResumeGameMode() { 
		Time.timeScale = 1.0f; 
		isPaused = false; 
		Screen.showCursor = false; 
		GetComponent<MouseLook>().enabled = true;
        GetComponent<FireGunLevel1>().enabled = true;
        GetComponent<CharacterController>().enabled = true;
        Camera.main.GetComponent<MouseLook>().enabled = true;
    } 
	
	private void PauseGameMode() { 
		Time.timeScale = 0.0f; 
		isPaused = true;
        Screen.showCursor = true; 
		GetComponent<MouseLook>().enabled = false;
        GetComponent<FireGunLevel1>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        Camera.main.GetComponent<MouseLook>().enabled = false;
    } 
	
	private void OnGUI() { 
		if(isPaused) 
			PauseGameGUI(); 
	}

    private void PauseGameGUI() {

        GUI.BeginGroup(new Rect(((Screen.width / 2) - (groupWidth / 2)), ((Screen.height / 2) - (groupHeight / 2)), groupWidth, groupHeight));
        if (GUI.Button(new Rect(0, 0, buttonWidth, buttonHeight), "Continue")){
            ResumeGameMode();
        }
        if (GUI.Button(new Rect(0, 60, buttonWidth, buttonHeight), "Restart"))
        {
            ResumeGameMode();
            Application.LoadLevel(1);
            PlayerScript.setTime(100f);
        }
        if (GUI.Button(new Rect(0, 120, buttonWidth, buttonHeight), "Quit"))
        {
            ResumeGameMode();
            Screen.showCursor = true;
            Application.LoadLevel(0);
            Screen.showCursor = true;
        }
        GUI.EndGroup();

        //string message = "Game Paused. Press ESC to resume";
        /*GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height)); 
		GUILayout.FlexibleSpace(); 
		GUILayout.BeginHorizontal(); 
		GUILayout.FlexibleSpace(); 
		GUILayout.BeginVertical(); 
		GUILayout.Label(message, GUILayout.Width(200)); 

		GUILayout.EndVertical(); 
		GUILayout.FlexibleSpace(); 
		GUILayout.EndHorizontal(); 
		GUILayout.FlexibleSpace(); 
		GUILayout.EndArea(); */
    }
}
