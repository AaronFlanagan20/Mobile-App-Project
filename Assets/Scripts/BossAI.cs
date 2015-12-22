using UnityEngine;
using System.Collections;

public class BossAI : MonoBehaviour {
    public Transform player;
    public float playerDistance;
    private float rotationDamping = 10;
    public GameObject bullet;
    public AudioClip spas;

    private float fireRate;
    private float nextFire = 2f;

    void Update()
    {
        if (PlayerScript.isPlayerAlive)
        {
            if (PlayerScript.isLevel3)
            {
                playerDistance = Vector3.Distance(player.position, transform.position);

                if (playerDistance < 50f)
                {
                    lookAtPlayer();
                }

                if (playerDistance < 45f && fireRate <= Time.time)
                {
                    fireRate = Time.time + nextFire;
                    attack();
                }
            }
            else
            {
                playerDistance = Vector3.Distance(player.position, transform.position);

                if (playerDistance < 20f)
                {
                    lookAtPlayer();
                }

                if (playerDistance < 15f && fireRate <= Time.time)
                {
                    fireRate = Time.time + nextFire;
                    attack();
                }
            }

        }
    }

    private void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
    }

    private void attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                PlayerScript.curHealth -= 35;
                audio.PlayOneShot(spas);
            }
        }
    }
}
