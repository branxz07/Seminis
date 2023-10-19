using UnityEngine;

public class Controller : MonoBehaviour
{
    CharacterController characterController;
    public GameObject imagen;

    [Header("Opciones de Personaje")]
    public float walkSpeed = 15.0f;
    public float jumpSpeed = 20.0f;
    public float gravity = 40f;
    public float fuerza = 10;
    private Vector3 move = Vector3.zero;
    private float oriWS;
    public GameObject unObjeto = null;
    public lianas lian;
    public bool pesado = false;
    bool activo;

    void Start()
    {
        oriWS = walkSpeed;
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        activo=lian.activo;
        if (!pesado)
        {
            walkSpeed = oriWS;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                walkSpeed += 3;
            }
        }

        if (characterController.isGrounded)
        {
            // Solo toma la entrada del jugador para la componente Z (adelante/atrás) del movimiento
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            move = transform.TransformDirection(move) * walkSpeed;

            if ((Input.GetKey(KeyCode.Space) || Input.GetButton("Jump")) && activo==false)
            {
                move.y = jumpSpeed;
            }
            else if ((Input.GetKey(KeyCode.Space) || Input.GetButton("Jump")) && activo==true)
            {
               Debug.Log("escalando");
            }
            

            // No cambies la rotación si pesado es verdadero
            if (!pesado)
            {
                // Si el objeto se está moviendo, ajusta su rotación para que mire en la dirección de movimiento
                if (move.magnitude > 0.1f)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(move.normalized);
                    imagen.transform.rotation = Quaternion.Slerp(imagen.transform.rotation, targetRotation, Time.deltaTime * 10f);
                }
            }
        }

        move.y -= gravity * Time.deltaTime;

        characterController.Move(move * Time.deltaTime);
    }
}
