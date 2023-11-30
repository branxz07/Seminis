using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nivelFin : MonoBehaviour
{
    public AudioSource founded;
    public Flotando flotando;
    public GameObject letrero;
    public GameObject load;
    public GameObject camaraA, camaraB;
    public controlarColeccionables dungeon;
    private float delay = 2f; 
    public bool collected=false;

    
    // Start is called before the first frame update
    void Start()
    {
      dungeon=FindObjectOfType<controlarColeccionables>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {

    if(other.tag == "Player") {
      collected=true;
      camaraA.SetActive(false);
      camaraB.SetActive(true);
      letrero.SetActive(true);
      founded.Play();
      // Delay de 2 segundos
      StartCoroutine(LoadDelay());
      StartCoroutine(Change());

    }

  }

  IEnumerator LoadDelay() {
      
    yield return new WaitForSeconds(delay);  
    founded.Stop();
    // Activa load después de 2 segundos
    load.SetActive(true); 

  }

  IEnumerator Change() {
      
    yield return new WaitForSeconds(5f);  
    if (this.gameObject.name=="Seed")
    {
      dungeon.L1=true;
    }
    if (this.gameObject.name=="SeedL2")
    {
      dungeon.L2=true;
    }
    // Activa load después de 2 segundos
     SceneManager.LoadScene(0);

  }

}
