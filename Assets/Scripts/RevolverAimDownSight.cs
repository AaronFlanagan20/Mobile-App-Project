using UnityEngine;
using System.Collections;

public class RevolverAimDownSight : MonoBehaviour {

    public Transform gun;
    private float nextPos = -0.2393376f;
    private float nextField = 40.0f;
    private float nextPos2 = -0.3882463f;
    private float dampVelocity = 0.4f;
    private float dampVelocity2 = 0.4f;
    private float dampVelocity3 = 0.4f;
    private float smoothTime = 0.3f;

    // Update is called once per frame
    void Update()
    {

        float newPos = Mathf.SmoothDamp(gun.transform.localPosition.x, nextPos, ref dampVelocity, smoothTime);
        float newField = Mathf.SmoothDamp(Camera.main.fieldOfView, nextField, ref dampVelocity2, smoothTime);
        float newPos2 = Mathf.SmoothDamp(gun.transform.localPosition.y, nextPos2, ref dampVelocity3, smoothTime);

        Vector3 newP1 = new Vector3(gun.transform.localPosition.x, gun.transform.localPosition.y, 0);

        newP1.x = newPos;
        newP1.y = newPos2;
        Camera.main.fieldOfView = newField;


        if (Input.GetButton("Fire2"))
        {
            //adjust viewpoint and gun position
            nextField = 20.0f;
            nextPos = -0.5241224f;
            nextPos2 = -0.349839f;

            //slow down turning and movement speed
            //GetComponent("MouseLook").sensitivityX = 2;
            //camera.main.GetComponent("MouseLook").sensitivityX = 2;
            //camera.main.GetComponent("MouseLook").sensitivityY = 2;
        }
        else
        {
            //adjust viewpoint and gun position
            nextField = 60.0f;
            nextPos = -0.2393376f;
            nextPos2 = -0.3882463f;

            //speed up turning and movement speed
            // GetComponent("MouseLook").sensitivityX = 6;
            //  camera.main.GetComponent("MouseLook").sensitivityX = 6;
            // camera.main.GetComponent("MouseLook").sensitivityY = 6;
        }
    }
}
