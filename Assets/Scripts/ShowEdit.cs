using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEdit : MonoBehaviour
{
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        if (active) 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    }
}
