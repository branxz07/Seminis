using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lianas : MonoBehaviour
{
   public bool activo;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "escalable" )
        {
            activo = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "escalable")
        {
            activo = false;
        }
       
    }
}
