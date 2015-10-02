using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

    public Texture2D texture;

	void OnGUI()
    {
       // float xMin = Screen.width - (Screen.width - Input.mousePosition.x) - (texture.width/2);
       // float yMin = (Screen.height - Input.mousePosition.y) - (texture.height/2);
        float xMin = (Screen.width / 2) - (texture.width / 2);
        float yMin = (Screen.height / 2) - (texture.height / 2);
        GUI.DrawTexture(new Rect(xMin, yMin, texture.width, texture.height), texture);
    }
}
