using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWall : MonoBehaviour
{
    public GameObject glass;
    public AudioSource activacion;
    public plataformaMini[] plates;

    private bool sonidoReproducido = false; // Variable para rastrear si el sonido se ha reproducido
    private float startTime;

    void Start()
    {
        startTime = -1; // Inicializamos startTime a un valor negativo para indicar que aún no se ha activado.
    }
    void Update()
    {
        bool presion1 = plates[0].getPresion();
        bool presion2 = plates[1].getPresion();


        // Verifica si todas las plataformas están presionadas
        if (presion1 && presion2)
        {
            // Reproduce el sonido una vez si aún no se ha reproducido
            if (!sonidoReproducido)
            {
                startTime = Time.time;
                activacion.PlayOneShot(activacion.clip);
                sonidoReproducido = true;
            }
            if(Time.time - startTime >= 1.1f){
                glass.SetActive(false);
            }
        }
        else
        {
            startTime = -1;
            glass.SetActive(true);
            sonidoReproducido = false; // Reinicia el estado del sonido si no todas las plataformas están presionadas
        }
    }
}
