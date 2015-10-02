using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

    public float duration = 1f;

	void Update () {
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            Destroy(gameObject);
        }
	}
}
