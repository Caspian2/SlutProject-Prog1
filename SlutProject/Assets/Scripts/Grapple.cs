using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{

    private Vector3 mousePos;
    private Camera mainCamera;


    private bool check;

    private DistanceJoint2D distanceJoint;
    private SpringJoint2D springJoint;

    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        distanceJoint = GetComponent<DistanceJoint2D>();
    
        distanceJoint.enabled = false;
    
        check = true;
    }

    // Update is called once per frame
    void Update()
    {
        GetMousePos();
        if(Input.GetButtonDown("Fire2") && check)
        {
            distanceJoint.enabled = true;
            distanceJoint.connectedAnchor = mousePos;
            check = false;
        } else if(Input.GetButtonUp("Fire2"))
        {
            distanceJoint.enabled = false;
            check = true;

        }
    }

    private void GetMousePos()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
