using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liner : MonoBehaviour
{
    [SerializeField] private LineRenderer _renderer;
    [SerializeField] private EdgeCollider2D _collider;

    //list of vector 2 to use in colliders
    private readonly List<Vector2> _points = new List<Vector2>();

    void Start()
    {
        //to match the collider with the line in simple explanation
        //taking the collider in transform position
        _collider.transform.position -= transform.position;
    }


    //to add new point or create new point
    public void SetPosition(Vector2 pos)
    {

        if (!CanDraw(pos))
        {
            return;
        }

        //increasing the number points in the line or list or array
        //also to draw the line 
        //The containers of the lines
        _renderer.positionCount++;

        //new point at the end of the line
        _renderer.SetPosition(_renderer.positionCount - 1, pos);

        //to instantiate the colliders
        _points.Add(pos);
        _collider.points = _points.ToArray();
    }

    //if the new point can be added
    private bool CanDraw(Vector2 pos)
    {
        //first point always say yes
        if(_renderer.positionCount == 0)
        {
            //allowing
            return true;
        }

        //newpoint or create continous point
        return Vector2.Distance(_renderer.GetPosition(_renderer.positionCount - 1), pos) > DrawManager.minDistance;

    }
}
