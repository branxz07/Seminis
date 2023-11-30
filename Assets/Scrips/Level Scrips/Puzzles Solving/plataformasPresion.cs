using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformasPresion : MonoBehaviour
{
    public AudioSource activacion;
    Transform original;
    Vector3 abajo;
    Vector3 arriba;
    private int objetosEnTrigger = 0; // Variable para contar los objetos en el trigger.
    private bool presionado = false;
    private bool sonidoReproducido = false; // Para rastrear si el sonido ya se reprodujo.


    void Start()
    {
        original = this.transform;
        presionado = false;
        abajo = new Vector3(original.position.x, original.position.y - 0.10f, original.position.z);
        arriba = new Vector3(original.position.x, original.position.y, original.position.z);
    }

    void Update()
    {
        if (presionado)
        {
            transform.position = Vector3.Lerp(transform.position, abajo, Time.deltaTime);
            if (!sonidoReproducido)
            {
                activacion.PlayOneShot(activacion.clip); // Reproduce el sonido una vez.
                sonidoReproducido = true; // Marca el sonido como reproducido.
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, arriba, Time.deltaTime);
            sonidoReproducido = false; // Reinicia el estado del sonido al dejar de estar presionado.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.name.Contains("Box"))
        {
            objetosEnTrigger++;
            presionado = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.name.Contains("Box"))
        {
            objetosEnTrigger--;
            if (objetosEnTrigger <= 0)
            {
                presionado = false;
                objetosEnTrigger = 0; // Asegura que el contador no sea negativo.
            }
        }
    }

    public bool getPresion(){
        return presionado;
    }
}
