using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideArraw : MonoBehaviour
{
    public LookAtCamera lookat;
    private void Start()
    {
        lookat.target = Camera.main.transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.GetComponent<AgentController>() != null) 
        {
            Destroy(other.transform.root.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.root.GetComponent<AgentController>() != null)
        {
            Destroy(other.transform.root.gameObject);
        }
    }
}
