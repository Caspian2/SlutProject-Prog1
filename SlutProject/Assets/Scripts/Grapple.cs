using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{

    [SerializeField] private Transform lineStart;
    [SerializeField] private GameObject shootPoint;
    private Vector3 mousePos;
    private Vector3 shootPos;
    private Camera mainCamera;
    LayerMask mask;


    private bool check;

    private DistanceJoint2D distanceJoint;
    private SpringJoint2D springJoint;

    private LineRenderer lineRenderer;
    private Vector3 tempPos;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        lineRenderer = GetComponent<LineRenderer>();
        distanceJoint = GetComponent<DistanceJoint2D>();
        distanceJoint.enabled = false;
        check = true;
        lineRenderer.positionCount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {   

        GetMousePos();
        DrawLine();
        shootPos = shootPoint.transform.position;
       
        if(Input.GetButtonDown("Fire2") && check)
        {   
            mask |= (1 << LayerMask.NameToLayer("Ground"));
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, mask); 
            if(hit.collider != null)
            {   
                Debug.Log("Target name: " + hit.collider.name);
                distanceJoint.enabled = true;
                distanceJoint.connectedAnchor = mousePos;
                check = false;  
                lineRenderer.positionCount = 2;
                tempPos = mousePos; 
            }
            
        } else if(Input.GetButtonUp("Fire2"))
        {
            distanceJoint.enabled = false;
            check = true;
            lineRenderer.positionCount = 0;
        }
    }

    private void DrawLine()
    {
        if(lineRenderer.positionCount <=0) return;
        lineRenderer.SetPosition(0, lineStart.position);
        lineRenderer.SetPosition(1, tempPos);
    }

    private void GetMousePos()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

}
