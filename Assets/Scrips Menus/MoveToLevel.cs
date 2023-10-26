using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveToLevel : MonoBehaviour
{
    public string Nombrenivel;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" )
        {
            SceneManager.LoadScene(Nombrenivel);
        }

    }
}
