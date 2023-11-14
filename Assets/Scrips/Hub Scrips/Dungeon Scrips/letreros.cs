using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letreros : MonoBehaviour
{
    [Header("Letreros dungeons")]
    public GameObject cL1;
    public GameObject iL1;
    public GameObject cL2;
    public GameObject iL2;
    public GameObject cL3;
    public GameObject iL3;
    public GameObject cL4;
    public GameObject iL4;
    public GameObject cL5;
    public GameObject iL5;
    public GameObject cL6;
    public GameObject iL6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controlarColeccionables.Instance.L1)
        {
            cL1.SetActive(true);
            iL1.SetActive(false);
        }
        if (controlarColeccionables.Instance.L2)
        {
            cL2.SetActive(true);
            iL2.SetActive(false);
        }
        if (controlarColeccionables.Instance.L3)
        {
            cL3.SetActive(true);
            iL3.SetActive(false);
        }
        if (controlarColeccionables.Instance.L4)
        {
            cL4.SetActive(true);
            iL4.SetActive(false);
        }
        if (controlarColeccionables.Instance.L5)
        {
            cL5.SetActive(true);
            iL5.SetActive(false);
        }
        if (controlarColeccionables.Instance.L6)
        {
            cL6.SetActive(true);
            iL6.SetActive(false);
        }
    }
}
