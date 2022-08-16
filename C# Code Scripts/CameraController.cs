using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // create a different type of camera view so that the player feels a distinct difference for when they are in the level select screen as opposed to regular levels

    //create a transform variable to have a position in which to keep the camera focusing on
    public Transform cameraLockOnObject;
    //the distance from the lock on object the camera must maintain in the form ov a vector as there are 3 dimensions
    //this is important because we want the camera to focus on the player, and thus, when the player moves, the camera should move along with it
    private Vector3 distanceToLockOnObject;
    // Start is called before the first frame update
    void Start()
    {
        //when the system starts the distance to maintain is the position of this object - the target
        distanceToLockOnObject = transform.position - cameraLockOnObject.position;
    }

    // Update is called once per frame
    void Update()
    {
        //the current position should be the player + the distance that must be maintained
        transform.position = cameraLockOnObject.position + distanceToLockOnObject;
    }
}
