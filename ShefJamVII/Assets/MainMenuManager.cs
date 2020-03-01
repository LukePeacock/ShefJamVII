using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void start(){
      SceneManager.LoadScene("SampleScene");
    }

    public void  quit(){
      Debug.Log("QUITING SOFTWARE");
        Application.Quit();
    }
}
