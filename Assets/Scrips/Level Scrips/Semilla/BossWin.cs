using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWin : MonoBehaviour
{
    // Start is called before the first frame update
    Rampage BossScript;
    Flotando scriptSeed1;
    nivelFin scriptSeed2;

    void Start()
    {
        scriptSeed1=FindObjectOfType<Flotando>();
        scriptSeed2=FindObjectOfType<nivelFin>();
    }

    // Update is called once per frame
    void Update()
    {
        BossScript=FindObjectOfType<Rampage>();
        
         Vector3 moveTo= new Vector3(-3.6400001f,1.55000222f,-75.0400009f);
        if (BossScript.hitts>=6)
        {
            scriptSeed1.enabled = false; 
            scriptSeed2.enabled = false;
            if (Vector3.Distance(transform.position, moveTo) > 0.1f)
            {
                gameObject.transform.position= Vector3.Lerp(gameObject.transform.position,moveTo,Time.deltaTime);
            }else{
            scriptSeed1.enabled = true; 
            scriptSeed2.enabled = true;
            }

            
        }
    }
}
