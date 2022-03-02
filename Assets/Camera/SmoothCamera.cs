using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform target;
    //Transform is used if we want to know targets position, rotation or scale

    public float smoothSpeed = 0.1f;
    //smoothSpeed determines how fast camera locks onto target (in range 0 < x < 1)

    public Vector3 offset;
    //Vector3 allows manipulation in three dimensions
    //offset place camera to rear of target

    void FixedUpdate()//FixedUpdate prevents jitter as function is called after target position has changed
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //Lerp = linear interpolation, Vector3.Lerp gets us closer to desired position
        transform.position = smoothedPosition;
        //position of camera = position of the target + offset vector
        //this makes the camera follow the target object


        transform.LookAt(target);
        //rotates camera to follow target
    }
}
