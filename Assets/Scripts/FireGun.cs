using UnityEngine;
using System.Collections;

public class FireGun : MonoBehaviour {

    public AudioClip shotSound;
    public AudioClip reloadSound;
    public AudioClip clickSound;

    private bool reloading = false;//is true while reloading

    public int clip = 2; //how many clips you have
    public int bullets = 6;//how many bullets per clip
    public int reloadTime = 3;//time to reload

    public float fireRate;
    public float nextFire = 1;
  
    public GameObject bulletPrefab;
    private EnemyController enemy;

    // Use this for initialization
    void Start () {
        Screen.showCursor = false;
    }
	
	// Update is called once per frame
	void Update () {
        Screen.showCursor = false;

        if (Input.GetMouseButton(0) &&  fireRate <= Time.time)
        {
            fireRate = Time.time + nextFire;
            if (bullets > 0 && !reloading)//if you have bullets
            {
                Debug.Log("Calling shoot");
                Shoot();//call method
            }
            else if (clip > 0 && reloading != true)//and have clips
            {
                StartCoroutine(Reload());//call reload
                Debug.Log("reloaded");
            }
            else if (clickSound)//play click sound
            {
                audio.PlayOneShot(clickSound);
            }
        }
	}

    private void Shoot()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            Vector3 hitPoint = hitInfo.point;
            Instantiate(bulletPrefab, hitPoint, Quaternion.identity);

            if(bulletPrefab != null)
            {
                audio.PlayOneShot(shotSound);
                bullets--;

                enemy = hitInfo.collider.GetComponent<EnemyController>();
                if (hitInfo.collider.tag == "soldier")
                {
                    enemy.Damage();
                }
            }
        }
    }

    IEnumerator Reload()
    {
        clip -= 1;//minus a clip
        reloading = true;
        audio.PlayOneShot(reloadSound);//play sound
        bullets = 6;//bullets now available
        yield return new WaitForSeconds(reloadTime); // wait the reload time
        reloading = false;
    }
}
