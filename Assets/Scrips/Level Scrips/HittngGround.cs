using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittngGround : MonoBehaviour
{
    public string sueloTag = "Suelo";
    public AudioClip audioClip; // Asegúrate de asignar un audio clip en el editor de Unity
    private AudioSource audioSource;
    private Rigidbody rb;

    private bool isMoving = false;
    private bool canPlaySound = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    
        rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        // Verifica si el objeto se está moviendo
        audioSource.time=.2f;
        isMoving = rb.velocity.magnitude > 0.1f;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si la colisión es con un objeto que tiene el tag "Suelo"
        if (collision.gameObject.CompareTag(sueloTag) && isMoving && canPlaySound)
        {
            // Reproduce el sonido
            audioSource.PlayOneShot(audioClip);
            // Establece un temporizador para detener el sonido después de 2 segundos
            Invoke("StopSound", .4f);
            // Evita que se reproduzca el sonido nuevamente hasta que el objeto deje de tocar el suelo
            canPlaySound = false;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Restablece la capacidad de reproducir el sonido cuando el objeto ya no toca el suelo
        if (collision.gameObject.CompareTag(sueloTag))
        {
            canPlaySound = true;
        }
    }

    void StopSound()
    {
        // Detiene el sonido después de 2 segundos
        audioSource.Stop();
    }
}
