using UnityEngine;
using System.Collections;

public class MusicContinue : MonoBehaviour {

    private static MusicContinue instance = null;
    public static MusicContinue Instance
    {
        get { return instance; }
    }

	// Use this for initialization
	void Awake () {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }else {
            instance = this;
        }

        if (Application.loadedLevel == 0 || Application.loadedLevel == 2 || Application.loadedLevel == 3)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (Application.loadedLevel == 0 || Application.loadedLevel == 2 || Application.loadedLevel == 3)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
