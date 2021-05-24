using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMov : MonoBehaviour
{
    private bool clockWiseRotation = false;

    // Update is called once per frame
    void Update()
    {
        if(clockWiseRotation && (transform.eulerAngles.z > 270 || transform.eulerAngles.z <= 0))
        {
            transform.Rotate(0,0,-1);
        }
        else if(!clockWiseRotation && transform.eulerAngles.z >= 0)
        {
            transform.Rotate(0, 0, 1);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            clockWiseRotation = !clockWiseRotation;
        }
    }
}
