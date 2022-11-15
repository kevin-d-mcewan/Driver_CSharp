using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    /* This things position (the camera) should be the same as the car's position */

    [SerializeField] GameObject thingToFollow;
    float cameraBufferZaxis = -10;


    private void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, cameraBufferZaxis);
    }







}
