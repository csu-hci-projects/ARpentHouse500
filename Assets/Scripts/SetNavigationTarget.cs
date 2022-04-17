using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class setNavigationTarget : MonoBehaviour
{
    [SerializeField] 
    private Camera topDownCamera;
    [SerializeField] 
    private GameObject navTargetObject;

    private NavMeshPath path;
    private LineRenderer line;

    private bool lineToggle = false;

    //  Start is called before the first frame update 
    void Start() {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began)){
            lineToggle = !lineToggle;
        }

        if(lineToggle){
            NavMesh.CalculatePath(transform.position, navTargetObject.transform.position, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            line.SetPositions(path.corners);
            line.enabled = true;
        }
    }
}

