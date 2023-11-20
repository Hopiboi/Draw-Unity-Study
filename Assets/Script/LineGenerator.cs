using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    //Game object
    public GameObject linePrefab;

    //the class
    Line activeLine;

    void Update()
    {
        //to draw when press
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newLine = Instantiate(linePrefab);
            activeLine = newLine.GetComponent<Line>();
            Debug.Log("Happy");
        }

        //not to draw when release
        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
            Debug.Log("sad");
        }

        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }
    }
}
