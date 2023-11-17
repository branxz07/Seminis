using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject instruccion;
    public GameObject Note;
    void Update(){
        if (instruccion.activeSelf)
        {
            if (Input.GetKey(KeyCode.F))
            {
                Note.SetActive(true);
            }
        }
        if (Note.activeSelf && Input.GetKey(KeyCode.Escape))
        {
            Note.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            instruccion.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            instruccion.SetActive(false);
        }
    }
}
