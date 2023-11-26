using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour
{

    public LineRenderer lineRenderer;

    //List of points
    List<Vector2> points;

    // moving the updates points, movement for mouse and basing on player movement
    public void UpdateLine(Vector2 position)
    {
        // if there are no points
        if (points == null)
        {
            //create new list or points, initialize it
            points = new List<Vector2>();
            SetPoint(position);
            return;
        }

        //THe list is now exist and create new point, the one who creates color, creating new point 
        //based on the distance
        if (Vector2.Distance(points.Last(), position) > .1f)
        {
            SetPoint(position);

        }

    }

    //Creating points
    public void SetPoint(Vector2 point)
    {
        //Adding the point in points arrray
        points.Add(point);

        //How many points we have and also where are they
        lineRenderer.positionCount = points.Count;

        //New position of this
        lineRenderer.SetPosition(points.Count - 1 , point);
    }


}
