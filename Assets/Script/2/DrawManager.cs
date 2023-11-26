using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private Liner _linePrefab;

    //constant in the world or all of it
    //when we can draw the next point based on the distance
    public const float minDistance = 0.1f;

    //getting the liner code and being drawn
    private Liner _currentLine;
    void Start()
    {
        _cam = Camera.main;

    }


    void Update()
    {
        //position of the mouse in the world
        Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);


        if (Input.GetMouseButtonDown(0))
        {
            //instantiate the new line
            //the starting point
            _currentLine = Instantiate(_linePrefab, mousePos, Quaternion.identity);
            Debug.Log(mousePos);
        }

        //holding the left mousr button
        if (Input.GetMouseButton(0))
        {
            //drawing the line 
           _currentLine.SetPosition(mousePos);

        }
    }
}
