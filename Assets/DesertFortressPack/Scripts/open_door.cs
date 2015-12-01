using UnityEngine;
using System.Collections;

public class open_door : MonoBehaviour 
{
	public float smooth = (float)2.0;
	public float DoorOpenAngle = (float)110.0;
	public float DoorCloseAngle = (float)0.0;
	public bool open = false;
	public bool enter = false;
	public string defined_key = "e";
    public Transform player;
    public float playerDistance;
	
	// Update is called once per frame
	void Update () 
	{
		if(open == true)
		{
			var target = Quaternion.Euler (transform.localRotation.x, DoorOpenAngle, transform.localRotation.z);
			// Dampen towards the target rotation
			transform.localRotation = Quaternion.Slerp(transform.localRotation, target,
			Time.deltaTime * smooth);
		}
	
		if(open == false)
		{
			var target1 = Quaternion.Euler (transform.localRotation.x, DoorCloseAngle, transform.localRotation.z);
			// Dampen towards the target rotation
			transform.localRotation = Quaternion.Slerp(transform.localRotation, target1,
			Time.deltaTime * smooth);
		}
	
		if(enter == true)
		{
            playerDistance = Vector3.Distance(player.position, transform.position);
            if (Input.GetKeyDown(defined_key) && playerDistance < 5f)
			{
                    open = !open;
            }
		}	
	}

	//Activate the Main function when player is near the door
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			//Debug.Log("Trigger Enter");
			(enter) = true;
		}
	}
	
	//Deactivate the Main function when player is go away from door
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			//Debug.Log("Trigger Exit");
			(enter) = false;
		}
	}
}

