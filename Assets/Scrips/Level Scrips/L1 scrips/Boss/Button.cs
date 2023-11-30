using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool playerInside = false;
    public GameObject interact;
    public AudioSource click;
    public float distance=.85f;
    public bool press;
    Vector3 OriginalPos;
    Vector3 moveTo;
    bool pressed;
    void Update()
    {
         if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            if (!pressed)
            {
                click.PlayOneShot(click.clip);
                pressed=true;
            }
            interact.SetActive(false);
            moveButton();
            press=true;
        }else
        {
            press=false;
        }
    }
        void moveButton(){
        
        Vector3 moveTo= new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z+distance);
        gameObject.transform.position=moveTo;
        StartCoroutine(Delay());
    }
    IEnumerator Delay() {
        yield return new WaitForSeconds(.2f);  
        Vector3 OriginalPos= new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z-distance);
        gameObject.transform.position=OriginalPos;
        pressed=false;
    }
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra es el jugador
        if (other.gameObject.CompareTag("Player"))
        {
            // Establecer la bandera de que el jugador está dentro del área
            playerInside = true;
            interact.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Verificar si el objeto que entra es el jugador
        if (other.gameObject.CompareTag("Player"))
        {
            // Establecer la bandera de que el jugador está dentro del área
            playerInside = false;
            interact.SetActive(false);
        }
    }
}
