using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarrarObj : MonoBehaviour
{
    public GameObject cubo;
    public Controller player; 
    public Transform mano;
    float fuerza;

    private bool activo;
    private bool enMano;
    private Vector3 escala;
    private float oriWS;
    private float oriJF;
    private float oriF;
    public float factorDeReduccion = .005f; 

    public RuntimeAnimatorController[] anim1;
    public Animator animator;
    private void Start()
    {

        player=FindObjectOfType<Controller>();
        oriWS=player.walkSpeed;
        oriJF=player.jumpSpeed;
        oriF=player.fuerza;
        escala = cubo.transform.localScale;
    }

    void Update()
    {
        fuerza = player.fuerza;
        if(activo == true && player.unObjeto ==null)
        {
            if(Input.GetKeyDown(KeyCode.E) && this.tag== "equipable" && enMano == false)
            {
                animator.GetComponent<Animator>().runtimeAnimatorController = anim1[0];
                cubo.transform.SetParent(mano);
                cubo.transform.position = mano.position;
                cubo.transform.rotation = mano.rotation;
                cubo.GetComponent<Rigidbody>().isKinematic = true;
                enMano = true;
                player.unObjeto = cubo;   
                if (cubo.transform.localScale.y>2)
                {
                    pequeño();
                }
            }

            if(Input.GetKeyDown(KeyCode.E) && this.tag== "pesado"  && enMano == false)
            {
                animator.GetComponent<Animator>().runtimeAnimatorController = anim1[0];
                cubo.transform.SetParent(mano);
                cubo.GetComponent<Rigidbody>().isKinematic = false;
                enMano = true;
                player.walkSpeed=player.walkSpeed/Mathf.Clamp(cubo.GetComponent<Rigidbody>().mass/fuerza, 1f,10000f);
                player.jumpSpeed=0;
                player.fuerza=player.fuerza/2*player.walkSpeed/cubo.GetComponent<Rigidbody>().mass;
                player.pesado=true;
                player.unObjeto = cubo;
            }
        }

        if(Input.GetMouseButtonDown(0)&& enMano==true)
        {
            animator.GetComponent<Animator>().runtimeAnimatorController = anim1[1];
            cubo.transform.SetParent(null);
            cubo.GetComponent<Rigidbody>().isKinematic = true;
            if (this.tag=="equipable")
            {
                cubo.GetComponent<Rigidbody>().isKinematic = false;
            }
            else if(this.tag=="pesado")
            {
                cubo.GetComponent<Rigidbody>().isKinematic = true;
            }
            cubo.transform.localScale = escala;
            player.walkSpeed=oriWS;
            player.jumpSpeed=oriJF;
            player.fuerza=oriF;
            if(enMano == true)
            {
                cubo.GetComponent<Rigidbody>().AddForce(transform.forward * fuerza, ForceMode.Impulse);
                player.walkSpeed=oriWS;
                player.jumpSpeed=oriJF;
                player.fuerza=oriF;
            }
            player.pesado=false;
            enMano = false;
            player.unObjeto = null;
        }
        if(Input.GetMouseButtonDown(1) && enMano==true)
        {
            animator.GetComponent<Animator>().runtimeAnimatorController = anim1[1];
            cubo.transform.SetParent(null);
            cubo.GetComponent<Rigidbody>().isKinematic = true;
            if (this.tag=="equipable")
            {
                cubo.GetComponent<Rigidbody>().isKinematic = false;
            }
            else if(this.tag=="pesado")
            {
                cubo.GetComponent<Rigidbody>().isKinematic = true;
            }
            cubo.transform.localScale = escala;
            player.walkSpeed=oriWS;
            player.jumpSpeed=oriJF;
            player.fuerza=oriF;
            if(enMano == true)
            {
                cubo.GetComponent<Rigidbody>().AddForce(transform.up * fuerza, ForceMode.Impulse);
                player.walkSpeed=oriWS;
                player.jumpSpeed=oriJF;
                player.fuerza=oriF;
            }
            player.pesado=false;
            enMano = false;
            player.unObjeto = null;
        }

        if(Input.GetKeyDown(KeyCode.Q)&&enMano==true)
        {
            animator.GetComponent<Animator>().runtimeAnimatorController = anim1[1];
            cubo.transform.SetParent(null);

            if (this.tag=="equipable")
            {
                cubo.GetComponent<Rigidbody>().isKinematic = false;
            }
            else if(this.tag=="pesado")
            {
                cubo.GetComponent<Rigidbody>().isKinematic = true;
            }
            cubo.transform.localScale = escala;
            player.walkSpeed=oriWS;
            player.jumpSpeed=oriJF;
            player.fuerza=oriF;
            player.pesado=false;
            enMano = false;
            player.unObjeto = null;

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" )
        {
            activo = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            activo = false;
        }
       
    }

    
    void pequeño()
    {
        // Reduce el tamaño del objeto
        cubo.transform.localScale *= factorDeReduccion;
    }
}
