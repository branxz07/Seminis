using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotesUI : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI values;
    NumberRand key;
    void Start(){
        key=GameObject.FindObjectOfType<NumberRand>();
    }

    // Update is called once per frame
    void Update()
    {
        values.text=key.numbers.text;
    }
}
