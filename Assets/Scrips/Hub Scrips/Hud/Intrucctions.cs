using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intrucctions : MonoBehaviour
{
    public GameObject InstruccionMove;
    public GameObject InstruccionRun;
    bool walk=false;
    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(AppearDelay(InstruccionMove,1.5f));
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D))&&!walk&&InstruccionMove.activeSelf)
        {
            StartCoroutine(DisppearDelay(InstruccionMove,1f));
            walk=true;
            StartCoroutine(AppearDelay(InstruccionRun,2f));

        }
        if(Input.GetKey(KeyCode.LeftShift)&&walk&&InstruccionRun.activeSelf){
            StartCoroutine(DisppearDelay(InstruccionRun,1f));
        }
    }
    IEnumerator DisppearDelay(GameObject instruction, float delay) {
      
    yield return new WaitForSeconds(delay);  
    instruction.SetActive(false);

    }
    IEnumerator AppearDelay(GameObject instruction, float delay) {
      
    yield return new WaitForSeconds(delay);  
    instruction.SetActive(true);

    }
}
