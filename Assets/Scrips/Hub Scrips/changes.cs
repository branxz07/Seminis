using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Unity.VisualScripting;
using UnityEngine;

public class changes : MonoBehaviour
{
    //PARA ALME¡¡ACENAR INFROMACION DE USSUARIO NO DATOS
    public int collectible;
    public int start;
    public int LevelCompleted;
    private string startPrefName="started";
    private string collectPrefName="Collectible";
    private string LevelsPrefName="Levels";
    private UserInterface userInterface;


    private void Awake(){
        LoadData();
    }
    void Start()
    {
        userInterface = GameObject.FindGameObjectWithTag("GameController").GetComponent<UserInterface>();
        RefreshUI();
    }

    // Update is called once per frame
    void Update()
    {
        RefreshUI();
    }

    private void RefreshUI()
    {
        userInterface.Refreshcollectible(collectible);
        userInterface.RefreshLevelCompleted(LevelCompleted);
    }

    private void OnDestroy(){
        SaveData();
    }
    private void SaveData(){
        PlayerPrefs.SetInt(collectPrefName,collectible);
        PlayerPrefs.SetInt(collectPrefName,collectible);
        PlayerPrefs.SetInt(startPrefName,start);
    }
    private void LoadData(){
        collectible=PlayerPrefs.GetInt(collectPrefName,0);
        LevelCompleted=PlayerPrefs.GetInt(LevelsPrefName,0);
        start=PlayerPrefs.GetInt(startPrefName,0);
    }

}
