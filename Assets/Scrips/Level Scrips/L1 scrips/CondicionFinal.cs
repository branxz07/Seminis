using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionFinal : MonoBehaviour
{
    public GameObject[] jefe;
    public AudioSource activacion;
    public plataformasPresion[] plates;

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
        bool presion3 = plates[2].getPresion();
        bool presion4 = plates[3].getPresion();

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
                SetScale(jefe[0], new Vector3(0.142f, 0.04780718f, 0.142f));
                SetScale(jefe[1], new Vector3(0.142f, 0.04780718f, 0.142f));
                SetScale(jefe[2], new Vector3(0.142f, 0.04780718f, 0.142f));
                SetScale(jefe[3], new Vector3(0.142f, 0.04780718f, 0.142f));

                jefe[0].GetComponent<Rigidbody>().isKinematic = false;
                jefe[1].GetComponent<Rigidbody>().isKinematic = false;
                jefe[2].GetComponent<Rigidbody>().isKinematic = false;
                jefe[3].GetComponent<Rigidbody>().isKinematic = false;


            }
        }
        else
        {
            startTime = -1;
            sonidoReproducido = false; // Reinicia el estado del sonido si no todas las plataformas están presionadas
        }
    }
    void SetScale(GameObject target, Vector3 newScale)
    {
        if (target != null)
        {
            // Apply the new scale to the target object
            target.transform.localScale = newScale;
        }
        else
        {
            Debug.LogError("Target object is null. Please assign a valid GameObject.");
        }
    }
}
