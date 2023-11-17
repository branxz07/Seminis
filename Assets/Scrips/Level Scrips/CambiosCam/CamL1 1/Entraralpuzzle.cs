using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entraralpuzzle : MonoBehaviour
{
    public GameObject camaraA, camaraB;
    public GameObject Olmo,buttons;
    // Flag para controlar si el jugador está dentro del área del trigger
    private bool playerInside = false;

    ButtonsCombination combination;

    // Update is called once per frame
    void Start(){
        combination=GameObject.FindObjectOfType<ButtonsCombination>();
    }
    void Update()
    {
        // Verificar si el jugador está dentro del área del trigger y presiona la tecla E
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            camaraA.SetActive(false);
            camaraB.SetActive(true);
            Olmo.SetActive(false);
            buttons.SetActive(true);
            Cursor.visible=true;
            Cursor.lockState = CursorLockMode.None; //Establece el estado del cursor al bloqueado
        }

        // Verificar si se presiona la tecla Escape
        if ((playerInside &&Input.GetKey(KeyCode.Escape))||combination.active)
        {
            combination.active=false;
            camaraA.SetActive(true);
            camaraB.SetActive(false);
            buttons.SetActive(false);
            Olmo.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked; //Establece el estado del cursor al bloqueado
            Cursor.visible=false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra es el jugador
        if (other.gameObject.CompareTag("Player"))
        {
            // Establecer la bandera de que el jugador está dentro del área
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verificar si el objeto que sale es el jugador
        if (other.gameObject.CompareTag("Player"))
        {
            // Establecer la bandera de que el jugador ya no está dentro del área
            playerInside = false;
            buttons.SetActive(false);
            Olmo.SetActive(true);
            // Restaurar cámaras según sea necesario
            camaraA.SetActive(true);
            camaraB.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked; //Establece el estado del cursor al bloqueado
            Cursor.visible=false;
        }
    }
}
