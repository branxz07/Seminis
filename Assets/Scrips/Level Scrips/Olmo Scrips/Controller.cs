using UnityEngine;

public class Controller : MonoBehaviour
{
    CharacterController characterController;
    public GameObject imagen;
    public RuntimeAnimatorController[] anim1;
    public Animator animator;
    nivelFin Fin;

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
    ReadingNote reading;
    AudioSource actualWalk = null;
    public AudioSource walkWood=null;
    public AudioSource WalkStone=null;
    int velvalue;
    MoveToBoss inBoss;

    void Start()
    {
        Fin = FindObjectOfType<nivelFin>();
        inBoss = FindObjectOfType<MoveToBoss>();
        reading = FindObjectOfType<ReadingNote>();
        oriWS = walkSpeed;
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!Fin.collected)
        {
            if (!inBoss.Boss)
            {
                actualWalk = walkWood;
                velvalue=1;
            }
            else
            {
                actualWalk = WalkStone;
                velvalue=2;
            }
            if (!reading.DontMove || inBoss.Falling)
            {
                activo = lian.activo;
                if (!pesado)
                {
                    walkSpeed = oriWS;
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        walkSpeed += 3;
                        actualWalk.pitch = 1.25f*velvalue;
                    }
                }

                if (characterController.isGrounded)
                {
                    // Solo toma la entrada del jugador para la componente Z (adelante/atrás) del movimiento
                    move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

                    move = transform.TransformDirection(move) * walkSpeed;

                    if ((Input.GetKey(KeyCode.Space) || Input.GetButton("Jump")) && activo == false)
                    {
                        animator.GetComponent<Animator>().runtimeAnimatorController = anim1[3];
                        move.y = jumpSpeed;
                    }
                    else if ((Input.GetKey(KeyCode.Space) || Input.GetButton("Jump")) && activo == true)
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

                            // Solo inicia o reinicia el sonido cuando move[0] o move[2] son diferentes de 0
                            if (move[0] != 0 || move[2] != 0)
                            {
                                // Inicia o reinicia el sonido
                                if (!actualWalk.isPlaying)
                                {
                                    actualWalk.pitch =1f*velvalue;
                                    actualWalk.Play();
                                }
                            }
                        }
                        else
                        {
                            // Detiene el sonido cuando el personaje no se está moviendo
                            
                            actualWalk.Stop();
                        }
                        
                    }
                    else
                    {
                        // Si el objeto se está moviendo, ajusta su rotación para que mire en la dirección de movimiento
                        if (move.magnitude > 0.1f)
                        {
                            if (move[0] != 0 || move[2] != 0)
                            {
                                // Inicia o reinicia el sonido
                                actualWalk.pitch =.5f*velvalue;
                                if (!actualWalk.isPlaying)
                                {
                                    
                                    actualWalk.Play();
                                }
                            }
                        }
                        else
                        {
                            // Detiene el sonido cuando el personaje no se está moviendo
                            actualWalk.pitch =1f*velvalue;
                            actualWalk.Stop();
                        }
                    }
                }
                if (!characterController.isGrounded ||(move[0] == 0 && move[2] == 0))
                {
                    actualWalk.Stop();
                }
            }
            else
            {
                move[0] = 0;
                move[2] = 0;
            }
            if ((move[0] != 0 || move[2] != 0) && unObjeto == null)
            {
                animator.GetComponent<Animator>().runtimeAnimatorController = anim1[1];
            }
            else if (move[0] == 0 && move[2] == 0 && unObjeto == null)
            {
                animator.GetComponent<Animator>().runtimeAnimatorController = anim1[0];
            }
            else if ((move[0] != 0 || move[2] != 0) && unObjeto != null)
            {
                animator.GetComponent<Animator>().runtimeAnimatorController = anim1[4];
            }
            move.y -= gravity * Time.deltaTime;
            
            
            characterController.Move(move * Time.deltaTime);
        
        }
    }
}
