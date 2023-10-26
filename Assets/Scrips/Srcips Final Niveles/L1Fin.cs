using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1Fin : MonoBehaviour
{
    public GameObject jefe;
    public AudioSource activacion;
    public plataformasPresion placa1;
    public plataformasPresion placa2;
    public plataformasPresion placa3;
    public plataformasPresion placa4;

    private bool sonidoReproducido = false; // Variable para rastrear si el sonido se ha reproducido
    private float startTime;

    void Start()
    {
        startTime = -1; // Inicializamos startTime a un valor negativo para indicar que aún no se ha activado.
    }
    void Update()
    {
        bool presion1 = placa1.getPresion();
        bool presion2 = placa2.getPresion();
        bool presion3 = placa3.getPresion();
        bool presion4 = placa4.getPresion();

        // Verifica si todas las plataformas están presionadas
        if (presion1 && presion2 && presion3 && presion4)
        {
            
            // Reproduce el sonido una vez si aún no se ha reproducido
            if (!sonidoReproducido)
            {
                startTime = Time.time;
                activacion.PlayOneShot(activacion.clip);
                sonidoReproducido = true;
            }
            if(Time.time - startTime >= 1.1f){
                jefe.SetActive(false);
            }
        }
        else
        {
            startTime = -1;
            jefe.SetActive(true);
            sonidoReproducido = false; // Reinicia el estado del sonido si no todas las plataformas están presionadas
        }
    }
}


