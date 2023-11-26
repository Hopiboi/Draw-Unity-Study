using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{
    //the one will gonna draw
    //This is the ink if the class is the pen/container
    private LineRenderer liners;
    //mouse position
    private Vector3 previousPosition;


    //to draw the line distance, the shorter, the better
    [SerializeField] private float minDistance = .1f;
    [SerializeField, Range(0,1)] private float width;

    private void Start()
    {
        liners = GetComponent<LineRenderer>();

        //position Count
        liners.positionCount = 1;

        //starting position of the line
        //position of the mouse to game object
        previousPosition = -transform.position;

        //customable width
        liners.startWidth = liners.endWidth = width;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //mouse position in the unity
            //the line will gonna get the mouse position coordinates or position

            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0f;

            //draw when the minimum distance is greater than the mouse
            //add a new point
            if (Vector3.Distance(currentPosition, previousPosition) > minDistance)
            {

                if( previousPosition == transform.position)
                {
                    liners.SetPosition(0, currentPosition);
                }

                else
                {
                    liners.positionCount++; //position will add in the array, can see in the linerenderer
                    liners.SetPosition(liners.positionCount - 1, currentPosition); //add the current index to the index

                }

                previousPosition = currentPosition; // update the current position to previous position
            }
        }
    }
}
