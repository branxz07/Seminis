using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlarColeccionables : MonoBehaviour
{
        [Header("Dungeons completadas")]
    public bool L1;
    public bool L2;
    public bool L3;
    public bool L4;
    public bool L5;
    public bool L6;


    // Start is called before the first frame update
    public static controlarColeccionables Instance; 
    [SerializeField] private float collectionables;
    [SerializeField] public bool activoMenu;
    void Awake()
    {
     if(controlarColeccionables.Instance==null){
        controlarColeccionables.Instance=this;
        DontDestroyOnLoad(this.gameObject);

     }  
     else
     {
        Destroy(gameObject);
     } 
    }
    public void sumarCollect(float cantidad){
        collectionables+=cantidad;
    }
    public void desacticvarMenu(){
        activoMenu=false;
    }
}
