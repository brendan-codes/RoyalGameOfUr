using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        theDiceTray = GameObject.FindObjectOfType<DiceTray>(); 
        gameState = GameObject.FindObjectOfType<gameStateController>();

        if(StartingSlot){
            targetPosition = StartingSlot.transform.position;
        }
    }

    DiceTray theDiceTray;
    gameStateController gameState;


    Vector3 targetPosition;
    public StoneSlot StartingSlot;
    public Tile StartingTile;
    public int Player;
    Tile CurrentTile;

    int moveQueueIndex;
    Tile[] moveQueue;

    Vector3 velocity = Vector3.zero;
    float smoothTime = 0.25f;
    float smoothDistance = 0.01f;

    // Update is called once per frame
    void Update()
    {
        if(gameState.isMoving){
            Debug.Log(gameState.isMoving);
        }
        // if position is a reasonable distance from the target
        if( Vector3.Distance(this.transform.position, targetPosition) < smoothDistance ){
            // if we still have moves in our queue
            if(moveQueue != null && moveQueueIndex < moveQueue.Length){
                // animate!
                SetNewTarget( moveQueue[moveQueueIndex].transform.position );
                // move the index
                moveQueueIndex++;
            }else{
                gameState.isMoving = false;
            }
        }
        
        this.transform.position = Vector3.SmoothDamp( this.transform.position, targetPosition, ref velocity, smoothTime);

    }

    void SetNewTarget( Vector3 pos ){
        targetPosition = pos;
        velocity = Vector3.zero;
    }


    // void OnMouseEnter(){
    //     Debug.Log("Over!");
    // }

    void OnMouseUp(){

        

        // if the dice tray is done
        if(!theDiceTray.IsDoneRolling){
            return;
        }

        // grab the total and store it or bail
        int spacesToMove = theDiceTray.Total;
        if(spacesToMove == 0){ 
            return; 
        }

        // size move queue
        moveQueue = new Tile[spacesToMove];

        // start the pointer
        Tile endingTile = CurrentTile;

        gameState.isMoving = true;

        // loop spaces to move
        for (int i = 0; i < spacesToMove; i++)
        {

            // if it's not null
            if(endingTile == null){
                endingTile = StartingTile;
            }
            else {
                // if it runs off the board
                if(endingTile == null || endingTile.NextTiles.Length == 0){
                    // reach the end and score
                }
                // move pointer
                endingTile = endingTile.NextTiles[0];
            }

            // todo: add scoring logic

            // build movequeue as we walk
            moveQueue[i] = endingTile;
        }


        // SetNewTarget(endingTile.transform.position);
        CurrentTile = endingTile;
        moveQueueIndex = 0;

    }

}
