using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public CharacterController controller;
    [Header("Opciones de Personaje")]
    public float walkSpeed = 15.0f;
    public float jumpSpeed = 10.0f; // Ajusta el valor de jumpSpeed según tu preferencia
    
    private float oriWS;
    Vector3 muevete;
    public bool menu;
    public bool pesado = false;
    bool activo;

    public RuntimeAnimatorController[] anim1;
    public Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        menu=true;
        oriWS = walkSpeed;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!menu)
        {
            walkSpeed = oriWS;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                walkSpeed += 10;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 muevete = transform.right * x + transform.forward * z;

            controller.Move(muevete * walkSpeed * Time.deltaTime);

            // Cambiar la animación según la dirección del movimiento
            if (muevete[0] != 0 || muevete[2] != 0 && !Input.GetKey(KeyCode.LeftShift))
            {
                animator.runtimeAnimatorController = anim1[1];
            }
            else if (muevete[0] != 0 || muevete[2] != 0 && Input.GetKey(KeyCode.LeftShift))
            {
                animator.runtimeAnimatorController = anim1[2];
            }
            else if (muevete[0] == 0 && muevete[2] == 0)
            {
                animator.runtimeAnimatorController = anim1[0];
            }
        }
        
    }
}
