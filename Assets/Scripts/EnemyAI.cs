using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour{

    public Transform player;
    public float playerDistance;
    public float rotationDamping;
    public float moveSpeed;

    void Update()
    {
        if (PlayerScript.isPlayerAlive)
        {
            playerDistance = Vector3.Distance(player.position, transform.position);

            if (playerDistance < 15f)
            {
                lookAtPlayer();
            }

            if (playerDistance < 12f)
            {
                Debug.Log("Attack");
                attack();
                if (playerDistance > 7f)
                {
                    chase();
                }
            }
        }
    }

    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
    }

    void chase()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                PlayerScript.curHealth -=  1;
            }
        }
    }

}
