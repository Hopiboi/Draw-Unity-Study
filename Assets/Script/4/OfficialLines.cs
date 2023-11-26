using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OfficialLines : MonoBehaviour
{
    [Header("Line")]
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float minDistance = 0.1f;
    [SerializeField] private EdgeCollider2D edgeColls;

    //list of vector 2 to use in colliders
    private readonly List<Vector2> colliderList = new List<Vector2>();

    //List of Points
    List<Vector2> pointers;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        //Adjusting the line collider
        edgeColls.transform.position -= transform.position;
    }

    //Based on movement or position
    //like a player movement or in mouse
    public void CreatingLine(Vector2 position)
    {
        //no points
        if (pointers == null)
        {
            //creating new list if there is none
            pointers = new List<Vector2>();
            SetPoint(position);

            return;
        }

        //New point and not duplicating or the same one
        //The one who creates smooth lines
        if (Vector2.Distance(pointers.Last(),position)> minDistance)
        {
            SetPoint(position);

            //to hold the collider arrays
            colliderList.Add(position);
            edgeColls.points = colliderList.ToArray();
        }

    }

    //Points that we have
    //array of points
    public void SetPoint(Vector2 point)
    {
        //Adding the point in points arrray
        pointers.Add(point);

        //How many points we have and also where are they
        lineRenderer.positionCount = pointers.Count;

        //New position of the new point
        lineRenderer.SetPosition(pointers.Count - 1, point);
    }
}
