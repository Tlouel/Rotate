using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttach : MonoBehaviour
{
  public GameObject Cube;

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject == Cube)
        {
            Cube.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision other) 
    
    {
          if(other.gameObject == Cube)
        {
            Cube.transform.parent = null;
           
        }
    }
}
