using UnityEngine;
using System.Collections;

public class FireGun : MonoBehaviour {

    public AudioClip shotSound;
    public AudioClip reloadSound;
    public AudioClip clickSound;

    private bool reloading = false;//is true while reloading

    // private float range = 100.0f;
    public int clip = 2; //how many clips you have
    public int bullets = 6;//how many bullets per clip
    public int reloadTime = 100;//time to reload

    public float fireRate = 0.1f;
    public float nextFire = 0.0f;
  
    public GameObject bulletPrefab;
    private EnemyController enemy;

    // Use this for initialization
    void Start () {
        Screen.showCursor = false;
    }
	
	// Update is called once per frame
	void Update () {
        Screen.showCursor = false;

        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (bullets > 0)//if you have bullets
            {
                Debug.Log("Calling shoot");
                Shoot();//call method
            }
            else if (clip > 0 && reloading != true)//and have clips
            {
                StartCoroutine(Reload());//call reload
                reloading = false;//done reload
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
        reloading = true;//reloading is true
        clip -= 1;//minus a clip
        audio.PlayOneShot(reloadSound);//play sound
        bullets = 6;//bullets now available
        yield return new WaitForSeconds(reloadTime); // wait the reload time
    }
}
