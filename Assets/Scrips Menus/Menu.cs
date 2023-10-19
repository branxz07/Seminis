using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void start(string Nombrenivel){
        SceneManager.LoadScene(Nombrenivel);
    }
    public void salir(){
        Application.Quit();
    }
}
