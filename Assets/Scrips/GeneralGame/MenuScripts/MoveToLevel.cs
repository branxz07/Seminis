using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveToLevel : MonoBehaviour
{
    public string Nombrenivel;
    public GameObject camaraMain;
    public GameObject camaraFall;
    public GameObject olmoFall;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" )
        {
            camaraMain.SetActive(false);
            camaraFall.SetActive(true);
            olmoFall.GetComponent<Rigidbody>().useGravity = true;
            StartCoroutine(LoadDelay());
        }
        

    }

    IEnumerator LoadDelay() {
      
    yield return new WaitForSeconds(3f);  

    
    // Activa load después de 2 segundos
    SceneManager.LoadScene(Nombrenivel);

  }
}
