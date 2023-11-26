using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreation : MonoBehaviour
{
    //Accessing game object and code 
    [Header("Line Prefab")]
    public GameObject linesPrefab;
    OfficialLines activeLine;
    private Camera cam;

    [Header ("Width")]
    [SerializeField] private LineRenderer lineRenderer;
    //Accesing the width of Line Renderer
    [SerializeField, Range(0, 1)] private float width;

    void Start()
    {
        cam = Camera.main;
        lineRenderer.startWidth = lineRenderer.endWidth = width; //can change the width
    }


    void Update()
    {
        //When press the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            //create the line
            GameObject newLines = Instantiate(linesPrefab);
            activeLine = newLines.GetComponent<OfficialLines>(); // Continuous line
            
        }

        //dont draw and finish the drawing
        //Done drawing that line and will not continue in the same prefab
        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        //if its null or its continue
        if (activeLine != null)
        {
            //Mouse position to the game world
            //Just like player movement or mouse movement
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            activeLine.CreatingLine(mousePos);
        }
    }
}
