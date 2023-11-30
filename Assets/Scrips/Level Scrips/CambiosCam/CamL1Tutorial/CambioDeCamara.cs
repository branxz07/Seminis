using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CambioDeCamara : MonoBehaviour
{
    public GameObject camaraA, camaraB;

    public bool inside;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag=="Player")
        {
            inside=true;
            camaraA.SetActive(false);
            camaraB.SetActive(true);
            
        }
    }
    private void OnTriggerExit(Collider other){
if (other.gameObject.tag=="Player")
        {
            inside=false;
            camaraA.SetActive(true);
            camaraB.SetActive(false);

        }
    }
}
