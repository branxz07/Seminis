using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nivelFin : MonoBehaviour
{
    public Flotando flotando;
    public GameObject letrero;
    public GameObject load;
    public GameObject camaraA, camaraB;
    private float delay = 2f; 

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {

    if(other.tag == "Player") {
        
      camaraA.SetActive(false);
      camaraB.SetActive(true);
      letrero.SetActive(true);
      
      // Delay de 2 segundos
      StartCoroutine(LoadDelay());
      StartCoroutine(Change());

    }

  }

  IEnumerator LoadDelay() {
      
    yield return new WaitForSeconds(delay);  
    
    // Activa load después de 2 segundos
    load.SetActive(true); 

  }

  IEnumerator Change() {
      
    yield return new WaitForSeconds(5f);  
    controlarColeccionables.Instance.L1=true;
    // Activa load después de 2 segundos
     SceneManager.LoadScene(0);

  }

}
