using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class MoveToBoss : MonoBehaviour
{
    public CinemachineBrain cinemachineBrain;
    public Controller olmo;
    public GameObject BossObj;
    public GameObject camaraMain;
    public GameObject camaraFall;
    public GameObject camBossB,camBossA,camBossC;
    public GameObject olmoFall;
    public GameObject OlmoPlayer;
    public bool Boss=false;
    public bool Falling=false;

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
            Falling=true;

        }
        

    }

    IEnumerator LoadDelay() {
      
    yield return new WaitForSeconds(3f);  
    CinemachineBlendDefinition defaultBlend = cinemachineBrain.m_DefaultBlend;
    defaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
    cinemachineBrain.m_DefaultBlend = defaultBlend;    
    Vector3 boss = new Vector3(6.94f,26f,-89.69f);
    OlmoPlayer.transform.position=boss;
    BossObj.SetActive(true);
    camaraFall.SetActive(false);
    camBossC.SetActive(true);
    Boss=true;
    Falling=false;
    StartCoroutine(Delay());
    
    
    
  }
  IEnumerator Delay() {
      
    yield return new WaitForSeconds(1f);  
    CinemachineBlendDefinition defaultBlend = cinemachineBrain.m_DefaultBlend;
    defaultBlend.m_Style = CinemachineBlendDefinition.Style.EaseInOut;
    cinemachineBrain.m_DefaultBlend = defaultBlend;
    olmo.enabled=false;
    yield return new WaitForSeconds(.12f);  
    
    camBossC.SetActive(false);
    camBossB.SetActive(true);
    yield return new WaitForSeconds(7.5f);  
    olmo.enabled=true;
    camBossA.SetActive(true);
    camBossB.SetActive(false);
    }
}

    
