using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    void Start(){
        gameState = GameObject.FindObjectOfType<gameStateController>();

        originalCamera = thisCam;
    }

    gameStateController gameState;

    public Transform target;

    public float smoothSpeed = 0.125f;
    public float cameraSize = 6f;

    public Camera thisCam;
    public Vector3 offset;

    public Camera originalCamera;

    // thisCam.orthographicSize = cameraSize;

    void LateUpdate(){ // like update, but later

        Debug.Log(gameState.isMoving);

        if(gameState.isMoving){
            transform.position = target.position + offset;
        }
    }


    // camera follow script

    // - alerted when movement is happening
    // - accepts target moving tile
    // - updates orthographicSize to see the board and 'zoom out'
    // - resets to original location

}
