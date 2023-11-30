using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letreros : MonoBehaviour
{
    [Header("dungeons")]
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
    public GameObject[] lampsEncendidaIzq;
    public GameObject[] lampsEncendidaDer;
    public GameObject[] lampsApagadaIzq;
    public GameObject[] lampsApagadaDer;
    public GameObject[] Puertas;
    public controlarColeccionables dungeons;
    public GameObject lights;
    public GameObject Olmo;
    public GameObject[] credits;
    // Start is called before the first frame update
    void Start()
    {
        dungeons=FindObjectOfType<controlarColeccionables>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dungeons.L1)
        {
            lights.SetActive(true);
        }
        if (dungeons.L1)
        {
            cL1.SetActive(true);
            iL1.SetActive(false);
            Puertas[0].SetActive(false);
            lampsApagadaIzq[0].SetActive(false);
            lampsApagadaDer[0].SetActive(false);
            lampsEncendidaIzq[0].SetActive(true);
            lampsEncendidaDer[0].SetActive(true);
        }
        if (dungeons.L2)
        {
            cL2.SetActive(true);
            iL2.SetActive(false);
            credits[0].SetActive(true);
            credits[1].SetActive(true);
            Olmo.SetActive(false);
            StartCoroutine(DelayToQuit());

        }
        if (dungeons.L3)
        {
            cL3.SetActive(true);
            iL3.SetActive(false);
        }
        if (dungeons.L4)
        {
            cL4.SetActive(true);
            iL4.SetActive(false);
        }
        if (dungeons.L5)
        {
            cL5.SetActive(true);
            iL5.SetActive(false);
        }
        if (dungeons.L6)
        {
            cL6.SetActive(true);
            iL6.SetActive(false);
        }
    }
    IEnumerator DelayToQuit(){
        yield return new WaitForSeconds(65f);
        Application.Quit();
    }
}
