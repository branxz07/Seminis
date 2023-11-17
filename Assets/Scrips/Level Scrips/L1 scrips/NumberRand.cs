using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberRand : MonoBehaviour
{
    public TextMeshProUGUI numbers;
    public int[] x = new int[4]; // Initialize the array with size 4

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            x[i] = UnityEngine.Random.Range(1, 5); // Use integers in the range (1, 5) to include 1 and 4
        }
        numbers.text = $"{x[0]} {x[1]} {x[2]} {x[3]}";
    }
}

