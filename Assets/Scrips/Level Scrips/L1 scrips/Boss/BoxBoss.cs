using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBoss : MonoBehaviour
{
    GameObject Box;
    public GameObject BoxPfab;
    public Transform[] spawns;
    public Button button;

    // Update is called once per frame
    void Update()
    {
        Box=GameObject.Find("BoxBoss(Clone)");
        if (Box==null && button.press)
        {
            Instantiate(BoxPfab, spawns[Random.Range(0,5)].position, Quaternion.identity);
            
        }

    }
     
}
