using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour
{

    public LineRenderer lineRenderer;

    //List of points
    List<Vector2> points;

    public void UpdateLine(Vector2 position)
    {
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(position);
            return;
        }

        //the one who draws
        if (Vector2.Distance(points.Last(), position) > .1f)
        {
            SetPoint(position);

        }

    }

    //Vector2
    public void SetPoint(Vector2 point)
    {
        //Lists
        points.Add(point);

        //How many points
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1 , point);



    }


}
