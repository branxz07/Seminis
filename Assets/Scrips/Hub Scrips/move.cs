using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{

    public CharacterController controller;
    [Header("Opciones de Personaje")]
    public float walkSpeed = 15.0f;
    public float jumpSpeed = 20.0f;
    public float gravity = 40f;
    public float fuerza = 10;
    private float oriWS;
    Vector3 muevete;
    public bool pesado = false;
    bool activo;

    public RuntimeAnimatorController[] anim1;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        oriWS = walkSpeed;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        walkSpeed = oriWS;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            
            walkSpeed += 10;
        }

        // Calcular la dirección del movimiento del jugador.
       

        if (controller.isGrounded)
        {
            // Solo toma la entrada del jugador para la componente Z (adelante/atrás) del movimiento
            // Obtener el valor del eje horizontal y vertical.
            controller.detectCollisions = false;
            muevete = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            if (muevete[0]!=0 ||muevete[2]!=0 && !Input.GetKey(KeyCode.LeftShift))
            {
                animator.GetComponent<Animator>().runtimeAnimatorController = anim1[1];
            }
            else if(muevete[0]!=0 ||muevete[2]!=0 && Input.GetKey(KeyCode.LeftShift)){
                animator.GetComponent<Animator>().runtimeAnimatorController = anim1[2];
            }
            else if (muevete[0]==0 && muevete[2]==0)
            {
                animator.GetComponent<Animator>().runtimeAnimatorController = anim1[0];
            }
            muevete = transform.TransformDirection(muevete) * walkSpeed;


             if ((Input.GetKey(KeyCode.Space) || Input.GetButton("Jump")) && activo==false)
            {
                animator.GetComponent<Animator>().runtimeAnimatorController = anim1[3];
                muevete.y = jumpSpeed;
            }
  
            
        }
        muevete.y -= gravity * Time.deltaTime;
        controller.Move(muevete * Time.deltaTime);
    }
}
