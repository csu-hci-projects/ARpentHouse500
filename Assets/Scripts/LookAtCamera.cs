using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform target;
    void Awake()
    {
        LookAt();
    }

    // Update is called once per frame
    void Update()
    {
        LookAt();
    }
    void LookAt() 
    {
        transform.LookAt(target);
        Vector3 euler = transform.localEulerAngles;
        euler.x = 0;
        transform.localEulerAngles = euler;
    }
}
