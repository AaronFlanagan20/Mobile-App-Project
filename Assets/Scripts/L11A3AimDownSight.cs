using UnityEngine;
using System.Collections;

public class L11A3AimDownSight : MonoBehaviour {

    public Texture texScope; // drag the scope image here
    public Camera scopeCam;   // drag the scope camera here
    private Rect rCamera = new Rect(0, 0, Screen.width, Screen.height);
    private Rect rScope = new Rect(0, 0, Screen.width, Screen.height);
    public static bool enableAim = false; // set enableAim to true to aim

    public GameObject player;

    void OnGUI()
    {
        MouseLook fpLook = player.GetComponent<MouseLook>();
        if (enableAim)
        {
            fpLook.sensitivityY = 0.5f;
            fpLook.sensitivityX = 0.5f;
            rCamera.x = (Screen.width - rCamera.width); // center rCamera
            rCamera.y = (Screen.height - rCamera.height) / 2;
            rScope.x = (Screen.width - rScope.width) / 2; // center rScope
            rScope.y = (Screen.height - rScope.height) / 2;
            scopeCam.pixelRect = rCamera;
            scopeCam.enabled = true;
            GUI.DrawTexture(rScope, texScope, ScaleMode.ScaleToFit, true, 0);
        }
        else
        {
            scopeCam.enabled = false;
            fpLook.sensitivityY = 15f;
            fpLook.sensitivityX = 15f;
        }
    }

    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            enableAim = true;
        }
        else
        {
            enableAim = false;
        }
    }

}
