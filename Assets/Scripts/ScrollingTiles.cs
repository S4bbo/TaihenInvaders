using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTiles : MonoBehaviour
{
    #region(Variables)
    // Public
    public Vector3 startPos;
    public Vector3 currentPos;
    public Vector3 pointToMoveBack;

    // Private

    #endregion

    #region(Unity Functions)
    void Start()
    {
        //Get the starting position
        startPos = this.gameObject.transform.position;
        pointToMoveBack = new Vector3(0, -10, 0);
    }

    void Update()
    {
        //Get the current position
        currentPos = gameObject.transform.position;
        //Move the background
        currentPos.y += Time.deltaTime * 1;
        //Reset back to point other texture ends
        if(currentPos.y >= 10)
        {
            currentPos = pointToMoveBack;
        }
        //Set the position to the new current position;
        gameObject.transform.position = currentPos;
    }
    #endregion
}
