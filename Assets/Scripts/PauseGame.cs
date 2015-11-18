using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

	private bool isPaused = false; 
	
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
	} 
	
	private void PauseGameMode() { 
		Time.timeScale = 0.0f; 
		isPaused = true;
        Screen.showCursor = true; 
		GetComponent<MouseLook>().enabled = false; 
	} 
	
	private void OnGUI() { 
		if(isPaused) 
			PauseGameGUI(); 
	} 
	
	private void PauseGameGUI(){ 
		string message = "Game Paused. Press ESC to resume or select a new quality setting below.";
 
		GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height)); 
		GUILayout.FlexibleSpace(); 
		GUILayout.BeginHorizontal(); 
		GUILayout.FlexibleSpace(); 
		GUILayout.BeginVertical(); 
		GUILayout.Label(message, GUILayout.Width(200)); 

		GUILayout.EndVertical(); 
		GUILayout.FlexibleSpace(); 
		GUILayout.EndHorizontal(); 
		GUILayout.FlexibleSpace(); 
		GUILayout.EndArea(); 
	}
}
