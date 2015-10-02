using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public int enemyHealth = 100;

    void Update () {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage()
    {
        enemyHealth -= 50;
        PlayerScript.score += 20;
        Debug.Log("Hit head");
    }
}
