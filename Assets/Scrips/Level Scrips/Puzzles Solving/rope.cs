using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rope : MonoBehaviour
{
    public Vector3 FuerzaPrueba;

void Start()
    {
        StartCoroutine(accion());
    }

    IEnumerator accion()
    {
        while (true)
        {

            yield return new WaitForSeconds(10f);
            transform.GetChild(transform.childCount-1).GetComponent<Rigidbody>().AddForce(FuerzaPrueba, ForceMode.Impulse);
        }
    }
}
