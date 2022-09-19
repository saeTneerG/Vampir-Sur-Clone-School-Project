using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public GameObject Menu;
    
    public void StartGame(){
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame(){
        Debug.Log("Exiting Game...");
        Application.Quit();
    }
}
