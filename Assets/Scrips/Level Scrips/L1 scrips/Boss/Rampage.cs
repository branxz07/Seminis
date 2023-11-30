
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rampage : MonoBehaviour
{
    public GameObject BossCam;
    public GameObject health;
    public AudioSource wipe;
    public AudioSource hit;
    public AudioSource BoxDes;
    public GameObject[] load;
    public GameObject[] Olmolives;
    public GameObject[] lives;
    public RuntimeAnimatorController[] anim1;
    public Animator animator;
    public GameObject weakness;
    public GameObject interfaceLives;
    public GameObject Seed;

    public GameObject Olmo;
    public float movementSpeed = 10f; // Ajusta la velocidad según tus necesidades
    Vector3 originalPosition;
    Vector3 attackPosition;
    private bool attacking;
    private bool dizzy;
    private bool returnig=false;
    public int hitts=0;
    public int Olmohitts=0;
    public AudioSource WalkStone;
    void Start()
    {
        originalPosition = transform.position;
        StartCoroutine(AttackRoutine());
    }

    void Update()
    {
        if (BossCam.activeSelf&&(hitts<6||Olmohitts<2))
        {
            health.SetActive(true);
        }
        // Puedes mantener esta parte si necesitas que el objeto siempre mire hacia Olmo
        weakness=GameObject.Find("BoxBoss(Clone)");
        if (!attacking&&!returnig)
        {
            gameObject.transform.LookAt(new Vector3(Olmo.transform.position.x, -0.01f, Olmo.transform.position.z));
        }
        if (Olmohitts>=3&&!returnig)
        {
            Olmo.SetActive(false);
            Destroy(health);
            returnig=true;
            StartCoroutine(Loose());
        }
        if (hitts>=6&&!returnig)
        {
            BoxDes.Play();
            StartCoroutine(DestroyWithDelay(.2f, weakness));
            animator.GetComponent<Animator>().runtimeAnimatorController = anim1[3];
            Destroy(health);
            interfaceLives.SetActive(false);
            onCooldown=true;
            returnig=true;
            cooldownTime = 99999999f;
            StopAllCoroutines();
            wipe.volume=0;
            WalkStone.volume=0;
            StartCoroutine(CooldownRoutine());
        }
    }

    IEnumerator AttackRoutine()
    {
        yield return new WaitForSeconds(2f); // Espera 5 segundos antes de comenzar la embestida
        animator.GetComponent<Animator>().runtimeAnimatorController = anim1[1];
        yield return new WaitForSeconds(.3f);
        animator.GetComponent<Animator>().runtimeAnimatorController = anim1[2];
        // Guarda la posición de Olmo en el momento del ataque
        attackPosition = new Vector3(Olmo.transform.position.x, -0.01f, Olmo.transform.position.z);

        // Mueve el objeto hacia la posición de ataque
        attacking=true;
        WalkStone.pitch = 3f;
        WalkStone.Play();
        while ((Vector3.Distance(transform.position, attackPosition) > 0.1f)&&!dizzy)
        {
            
            wipe.Play();
            transform.position = Vector3.MoveTowards(transform.position, attackPosition, movementSpeed*6 * Time.deltaTime);
            yield return null;
        }
        WalkStone.Stop();
        if (dizzy)
        {
            animator.GetComponent<Animator>().runtimeAnimatorController = anim1[3];
            yield return new WaitForSeconds(1f);
            animator.GetComponent<Animator>().runtimeAnimatorController = anim1[4];
            yield return new WaitForSeconds(2.5f);
            dizzy=false;

        }
        animator.GetComponent<Animator>().runtimeAnimatorController = anim1[5];
        yield return new WaitForSeconds(.7f); // Espera 2 segundos en la posición de ataque
        gameObject.transform.LookAt(new Vector3(originalPosition.x,-0.01f,originalPosition.z));
        yield return new WaitForSeconds(1f); // Espera 2 segundos en la posición de ataque

        // Mueve el objeto de regreso a su posición original
        WalkStone.pitch = 2f;
        WalkStone.Play();
        while (Vector3.Distance(transform.position, originalPosition) > 0.1f)
        {
            
            animator.GetComponent<Animator>().runtimeAnimatorController = anim1[6];
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, (movementSpeed) * Time.deltaTime); // Utiliza la mitad de la velocidad para el regreso
            yield return null;
        }
        WalkStone.Stop();
        animator.GetComponent<Animator>().runtimeAnimatorController = anim1[0];
        attacking=false;
        Olmo=GameObject.Find("Olmo Player");

        // Puedes reiniciar el proceso si lo deseas
        StartCoroutine(AttackRoutine());
    }
    private void OnTriggerEnter(Collider other)
    {
        if(onCooldown) return;
        if (other.tag == "Player")
        {
            onCooldown = true;
            StartCoroutine(CooldownRoutine());
            Olmohitts++;
            hit.Play();
            Destroy(Olmolives[Olmohitts-1]);
        }
        if (other.tag == "BossWeakness" && !onCooldown)
        {
            cooldownTime = 1.5f;
            StartCoroutine(CooldownRoutine());
            cooldownTime = 4f;
            BoxDes.Play();
            dizzy=true;
            if (!onCooldown)
            {
                hitts++;
                onCooldown=true;
            }
            if (hitts>1)
            {   
                Destroy(lives[hitts-1]);
            }
            StartCoroutine(DestroyWithDelay(.2f, weakness));
            
        }
    }
    IEnumerator DestroyWithDelay(float time, GameObject obj){
        yield return new WaitForSeconds(time);
        Destroy(obj);
    }

    public float cooldownTime = 4f;
    private bool onCooldown;
    IEnumerator CooldownRoutine() {
    yield return new WaitForSeconds(cooldownTime);
    onCooldown = false; 
    }

    IEnumerator Win() {
        yield return new WaitForSeconds(.5f);
        this.gameObject.SetActive(false);
        
  }

    IEnumerator Loose() {
        wipe.volume=0;
        WalkStone.volume=0;
        BoxDes.volume=0;
        health.SetActive(false);
        interfaceLives.SetActive(false);
        load[0].SetActive(true);
        yield return new WaitForSeconds(2f);
        load[0].SetActive(false);
        load[1].SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Hub");
  }


}
