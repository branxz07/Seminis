using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.IK;


public class Puzzle : MonoBehaviour
{
    public bool[] correct;
    public GameObject[] image; 
    public GameObject Olmo;
    public GameObject rope;
    public CinemachineBrain cinemachineBrain;
    public GameObject camaraMain;
    public GameObject camaraPuzzle;
    public Entraralpuzzle condition;
    public AudioSource solved;
    void Update()
    {
        float tolerance = Screen.width*.01f;

        float targetX1 = Screen.width *0.615752604f; 
        float targetY1 = Screen.height * 0.680673333f; 
        float distanceX1 = Mathf.Abs(image[0].transform.position.x - targetX1);
        float distanceY1 = Mathf.Abs(image[0].transform.position.y - targetY1);
        if (distanceX1 < tolerance && distanceY1 < tolerance)
        {
            correct[0]=true;
        }
        else
        {
            correct[0]=false;
        }
        float targetX2 = Screen.width *0.60575f; 
        float targetY2 = Screen.height * 0.404f; 
        float distanceX2 = Mathf.Abs(image[1].transform.position.x - targetX2);
        float distanceY2 = Mathf.Abs(image[1].transform.position.y - targetY2);
        if (distanceX2 < tolerance && distanceY2 < tolerance)
        {
            correct[1]=true;
        }
        else
        {
            correct[1]=false;
        }
        float targetX3 = Screen.width * 0.442177448f; 
        float targetY3 = Screen.height * 0.3279f; 
        float distanceX3 = Mathf.Abs(image[2].transform.position.x - targetX3);
        float distanceY3 = Mathf.Abs(image[2].transform.position.y - targetY3);
        if (distanceX3 < tolerance && distanceY3 < tolerance)
        {
            correct[2]=true;
        }
        else
        {
            correct[2]=false;
        }
        float targetX4 = Screen.width * 0.442912448f; 
        float targetY4 = Screen.height * 0.670475556f; 
        float distanceX4 = Mathf.Abs(image[3].transform.position.x - targetX4);
        float distanceY4 = Mathf.Abs(image[3].transform.position.y - targetY4);
        if (distanceX4 < tolerance && distanceY4 < tolerance)
        {
            correct[3]=true;
        }
        else
        {
            correct[3]=false;
        }
        if (correct[0]&&correct[1]&&correct[2]&&correct[3]&&condition.inGame==true)
        {
            
            StartCoroutine(Delay());
           
        }
    }
    IEnumerator Delay(){
        solved.Play();
        yield return new WaitForSeconds(1.5f);
        condition.inGame=false;
        CinemachineBlendDefinition defaultBlend = cinemachineBrain.m_DefaultBlend;
        defaultBlend.m_Style = CinemachineBlendDefinition.Style.EaseInOut;
        cinemachineBrain.m_DefaultBlend = defaultBlend;
        camaraMain.SetActive(true);
        camaraPuzzle.SetActive(false);
        yield return new WaitForSeconds(0.01f);
        Olmo.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        
        rope.SetActive(false);
    }


}
