using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public AudioSource paperFX;
    public GameObject instruccion;
    public GameObject Note;

    private bool noteActive = false; // Variable para rastrear el estado de reproducción

    void Update()
    {
        if (instruccion.activeSelf)
        {
            if (Input.GetKey(KeyCode.F) && !noteActive)
            {
                ActivarNota();
            }
        }

        if (Note.activeSelf && Input.GetKey(KeyCode.Escape))
        {
            DesactivarNota();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            instruccion.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            instruccion.SetActive(false);
        }
    }

    void ActivarNota()
    {
        Note.SetActive(true);
        paperFX.time = 0.3f;
        paperFX.Play();
        noteActive = true; // Establece el estado de reproducción a true
    }

    void DesactivarNota()
    {
        Note.SetActive(false);
        noteActive = false; // Establece el estado de reproducción a false para permitir la reproducción nuevamente
    }
}
