using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadingNote : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject NoteUI;
    public bool DontMove;
    void Update(){
        if (NoteUI.activeSelf)
        {
            DontMove=true;
        }
        else
        {
            DontMove=false;
        }
    }
}
