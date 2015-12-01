using UnityEngine;
using System.Collections;

public class SwitchWeapons : MonoBehaviour {

    public int currentWeapon;
    public GameObject[] weapons;

    public bool isMachine = true;
    public bool isPistol = false;
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            changeWeapon(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            changeWeapon(2);
        }
    }

    public void changeWeapon(int num)
    {
        currentWeapon = num;
        for (int i = 0; i < weapons.Length; i++)
        {
            if (num == 1)
            {
                weapons[0].gameObject.SetActive(true);
                weapons[1].gameObject.SetActive(false);
                gameObject.GetComponent<FireGunLevel2>().enabled = true;
                gameObject.GetComponent<FireGunLevel1>().enabled = false;
                isMachine = true;
                isPistol = false;
            }
            if(num == 2)
            {
                weapons[0].gameObject.SetActive(false);
                weapons[1].gameObject.SetActive(true);
                gameObject.GetComponent<FireGunLevel2>().enabled = false;
                gameObject.GetComponent<FireGunLevel1>().enabled = true;
                isPistol = true;
                isMachine = false;
            }
        }
    }
}
