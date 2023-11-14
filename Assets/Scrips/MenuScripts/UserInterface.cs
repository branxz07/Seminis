using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UserInterface : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI Collectible;
    [SerializeField]
    private TextMeshProUGUI levelCompleted;

    private changes genericScript;

    void Start()
    {
        genericScript = FindObjectOfType<changes>();
    }

    void Update()
    {
        
    }

    public void Refreshcollectible(int collectible)
    {
        Collectible.text = collectible.ToString();
    }

    public void RefreshLevelCompleted(int completes)
    {
        levelCompleted.text = completes.ToString();
    }
}
