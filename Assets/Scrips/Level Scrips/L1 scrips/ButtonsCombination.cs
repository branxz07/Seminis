using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonsCombination : MonoBehaviour
{
    // La secuencia correcta de botones
    List<int> secuenciaCorrecta = new List<int> { 1, 2, 3, 4 };
    public AudioSource activation;
    public AudioSource timer;
    public AudioSource error;
    public GameObject pared;
    public bool active;
    NumberRand key;
    void Start(){
        key=GameObject.FindObjectOfType<NumberRand>();
    }
    // Lista para almacenar los botones presionados por el jugador
    private List<int> botonesPresionados = new List<int>();
    void Update(){
        secuenciaCorrecta[0]=key.x[0];
        secuenciaCorrecta[1]=key.x[1];
        secuenciaCorrecta[2]=key.x[2];
        secuenciaCorrecta[3]=key.x[3];
    }

    // Método llamado cuando se presiona un botón
    public void OnButtonPress(int numeroBoton)
    {
    
        activation.PlayOneShot(activation.clip); // Reproduce el sonido una vez.
        //AudioSource.PlayClipAtPoint(tuClipDeSonido, transform.position);
        botonesPresionados.Add(numeroBoton);

        // Verificar si la secuencia es correcta hasta ahora
        if (botonesPresionados.Count==4)
        {
            if (VerificarSecuencia())
            {
            StartCoroutine(boxtimer());
            }
        }
    }

    // Verificar si la secuencia es correcta
    private bool VerificarSecuencia()
    {
        // Verificar si la longitud de la lista de botones presionados es la misma que la secuencia correcta
        for (int i = 0; i < 4; i++)
        {
            if (botonesPresionados[i] != secuenciaCorrecta[i])
            {
                // Si hay más o menos botones presionados, reiniciar la secuencia
                active=false;
                error.Play(); // Reproduce el sonido una vez.
                ReiniciarSecuencia();
                return false;
            }
        }
        active=true;
        pared.SetActive(false);
        timer.Play();
        return true;

    }

    // Método para reiniciar la secuencia
    private void ReiniciarSecuencia()
    {
        pared.SetActive(true);
        Debug.Log("Secuencia incorrecta. Reiniciando...");
        // Puedes agregar acciones adicionales aquí si es necesario

        // Limpiar la lista de botones presionados
        botonesPresionados.Clear();
    }
    IEnumerator boxtimer() {
      
    yield return new WaitForSeconds(8f);  

    timer.Stop();
    // Activa load después de 2 segundos
    active=false;
    ReiniciarSecuencia();

  }
}
