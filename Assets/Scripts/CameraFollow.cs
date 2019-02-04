using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;
    public float cameraSize = 0.5f;

    public Camera thisCam;
    public Vector3 offset;


    void LateUpdate(){ // like update, but later
        transform.position = target.position + offset;
        // thisCam.orthographicSize = thisCam.orthographicSize + cameraSize;
    }


    // camera follow script

    // - alerted when movement is happening
    // - accepts target moving tile
    // - updates orthographicSize to see the board and 'zoom out'
    // - resets to original location

}
