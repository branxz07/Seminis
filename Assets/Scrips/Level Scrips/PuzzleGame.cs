using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PuzzleGame : MonoBehaviour
{
    public GameObject Game;
    public GameObject visual;
    public Entraralpuzzle condition;
    public GameObject olmo;
    // Update is called once per frame

    void Update()
    {

        if (condition.inGame)
        {
            
            Game.SetActive(true);
            visual.SetActive(false);
        }
        else{
            visual.SetActive(true);
            Game.SetActive(false);
            
            
        }
    }

    
}
