using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonsMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float distance=-.04f;
    Vector3 OriginalPos;
    Vector3 moveTo;
    public void moveButton(){
        Vector3 moveTo= new Vector3(gameObject.transform.position.x+distance,gameObject.transform.position.y,gameObject.transform.position.z);
        gameObject.transform.position=moveTo;
        StartCoroutine(Delay());
    }
    IEnumerator Delay() {
        yield return new WaitForSeconds(.2f);  
        Vector3 OriginalPos= new Vector3(gameObject.transform.position.x-distance,gameObject.transform.position.y,gameObject.transform.position.z);
        gameObject.transform.position=OriginalPos;
    }
}
