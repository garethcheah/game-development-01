using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTransform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveSphere();
        JumpSphere();
    }

    private void MoveSphere()
    {
        float mouseXAxis = Input.GetAxis("Mouse X");
        Debug.Log("mouseXAxis=" + mouseXAxis);
        transform.Translate(mouseXAxis, 0, 0);
    }

    private void JumpSphere()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.Translate(0f, 1f, 0f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            transform.Translate(0f, -1f, 0f);
        }
    }
}
