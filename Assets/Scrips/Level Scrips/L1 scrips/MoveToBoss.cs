using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class MoveToBoss : MonoBehaviour
{
    public CinemachineBrain cinemachineBrain;
    public GameObject camaraMain;
    public GameObject camaraFall;
    public GameObject camBoss;
    public GameObject olmoFall;
    public GameObject OlmoPlayer;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" )
        {
            CinemachineBlendDefinition defaultBlend = cinemachineBrain.m_DefaultBlend;
            defaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
            cinemachineBrain.m_DefaultBlend = defaultBlend;    
            camaraMain.SetActive(false);
            camaraFall.SetActive(true);
            olmoFall.GetComponent<Rigidbody>().useGravity = true;
            StartCoroutine(LoadDelay());
            

        }
        

    }

    IEnumerator LoadDelay() {
      
    yield return new WaitForSeconds(3f);  
    CinemachineBlendDefinition defaultBlend = cinemachineBrain.m_DefaultBlend;
    defaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
    cinemachineBrain.m_DefaultBlend = defaultBlend;    
    Vector3 boss = new Vector3(6.94f,26f,-89.69f);
    OlmoPlayer.transform.position=boss;
    camaraFall.SetActive(false);
    camBoss.SetActive(true);

    
    
  }
}
