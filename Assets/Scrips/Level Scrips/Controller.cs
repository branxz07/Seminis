using UnityEngine;

public class Controller : MonoBehaviour
{
    CharacterController characterController;
    public GameObject imagen;
    public RuntimeAnimatorController[] anim1;
    public Animator animator;

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
            if (move[0]!=0 ||move[2]!=0 && unObjeto==null)
            {
                animator.GetComponent<Animator>().runtimeAnimatorController = anim1[1];
            }
            else if (move[0]==0 && move[2]==0 && unObjeto==null)
            {
                animator.GetComponent<Animator>().runtimeAnimatorController = anim1[0];
            }
            else if ((move[0]!=0 || move[2]!=0) && unObjeto!=null)
            {
                animator.GetComponent<Animator>().runtimeAnimatorController = anim1[4];
            }
            
            
            move = transform.TransformDirection(move) * walkSpeed;

            if ((Input.GetKey(KeyCode.Space) || Input.GetButton("Jump")) && activo==false)
            {
                animator.GetComponent<Animator>().runtimeAnimatorController = anim1[3];
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
                    Vector3 moveXZ = new Vector3(move.x, 0, move.z);
                    moveXZ = moveXZ.normalized;
                    Quaternion targetRotation = Quaternion.LookRotation(moveXZ);
                    imagen.transform.rotation = Quaternion.Slerp(imagen.transform.rotation, targetRotation, Time.deltaTime * 10f);
                }
            }
        }

        move.y -= gravity * Time.deltaTime;

        characterController.Move(move * Time.deltaTime);
    }
}
