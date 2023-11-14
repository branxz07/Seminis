using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public class Menu : MonoBehaviour
{
    public move Olmo;
    public GameObject menuCamera;
    public GameObject olmoCamara;
    public CinemachineBrain cinemachineBrain;
    public GameObject instrucciones;
    public GameObject tittle;
    public GameObject menu;

    private void Start(){
        if (!controlarColeccionables.Instance.activoMenu)
        {
            tittle.SetActive(false);
            menu.SetActive(false);
            StartCoroutine(Delay());
        }
        
    }
    public void continueStory(){
        CinemachineBlendDefinition defaultBlend = cinemachineBrain.m_DefaultBlend;
        defaultBlend.m_Style = CinemachineBlendDefinition.Style.EaseInOut;
        cinemachineBrain.m_DefaultBlend = defaultBlend;
        cinemachineBrain = Camera.main.GetComponent<CinemachineBrain>();
        menuCamera.SetActive(false);
        olmoCamara.SetActive(true);
        StartCoroutine(LoadDelay());
        

    }
    public void storymode(){
        
       
        CinemachineBlendDefinition defaultBlend = cinemachineBrain.m_DefaultBlend;
        defaultBlend.m_Style = CinemachineBlendDefinition.Style.EaseInOut;
        cinemachineBrain.m_DefaultBlend = defaultBlend;

        cinemachineBrain = Camera.main.GetComponent<CinemachineBrain>();
        tittle.SetActive(false);
        menu.SetActive(false);
        menuCamera.SetActive(false);
        olmoCamara.SetActive(true);
        StartCoroutine(LoadDelay());
        controlarColeccionables.Instance.desacticvarMenu();
        if (instrucciones.tag!="notLoad")
        {
        instrucciones.SetActive(true);
        }

    }
    IEnumerator LoadDelay() {
      
    yield return new WaitForSeconds(2f);  
    
    // Activa load después de 2 segundos
    Olmo.menu=false;
    
   

    CinemachineBlendDefinition defaultBlend = cinemachineBrain.m_DefaultBlend;
    defaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
    cinemachineBrain.m_DefaultBlend = defaultBlend;    
    
  }

  IEnumerator Delay() {
      
    yield return new WaitForSeconds(.5f);  
    continueStory();
  }
    public void salir(){
        Application.Quit();
    }
}
