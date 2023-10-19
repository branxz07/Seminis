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
    public GameObject unObjeto = null;
    public lianas lian;
    public bool pesado = false;
    bool activo;

    // Start is called before the first frame update
    void Start()
    {
        oriWS = walkSpeed;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!pesado)
        {
        walkSpeed = oriWS;
        if (Input.GetKey(KeyCode.LeftShift))
        {
                walkSpeed += 10;
        }
                // Decrementar el timer en cada frame.
        }
        // Calcular la dirección del movimiento del jugador.
       

        if (controller.isGrounded)
        {
            // Solo toma la entrada del jugador para la componente Z (adelante/atrás) del movimiento
            // Obtener el valor del eje horizontal y vertical.
            muevete = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            muevete = transform.TransformDirection(muevete) * walkSpeed;


             if ((Input.GetKey(KeyCode.Space) || Input.GetButton("Jump")) && activo==false)
            {
                muevete.y = jumpSpeed;
            }
            else if ((Input.GetKey(KeyCode.Space) || Input.GetButton("Jump")) && activo==true)
            {
               Debug.Log("escalando");
            }
  
            
        }
        muevete.y -= gravity * Time.deltaTime;
        controller.Move(muevete * Time.deltaTime);
    }
}
