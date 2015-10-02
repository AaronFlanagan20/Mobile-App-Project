using UnityEngine;
using System.Collections;

public class ChangeScenes : MonoBehaviour {

	public void ChangeScene (int scene) {
        Application.LoadLevel(scene);
	}
}
