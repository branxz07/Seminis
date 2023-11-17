using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Transform toCamera;
    public GameObject toShelf;
    public AudioSource activacion;
    bool active = false;
    private float startTime;

    void Start()
    {
        startTime = -1; // Inicializamos startTime a un valor negativo para indicar que aún no se ha activado.
    }

    void Update()
    {
        if (active)
        {
            transform.position = Vector3.Lerp(transform.position, toCamera.position, 3 * Time.deltaTime);
            transform.rotation = toCamera.rotation;
            this.gameObject.transform.LookAt(toCamera);

            // Verificamos si ha pasado un tiempo suficiente desde la activación.
            if (Time.time - startTime >= 1f)
            {
                toShelf.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Solo activamos si no hemos sido activados antes.
            if (!active)
            {
                controlarColeccionables.Instance.sumarCollect(1);
                active = true;
                startTime = Time.time;
                activacion.Play();
            }
        }
    }
}
