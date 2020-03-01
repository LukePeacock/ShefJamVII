using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
	public GameObject main;
	public GameObject howTo;

    public void start(){
      SceneManager.LoadScene("SampleScene");
    }

    public void  quit(){
      Debug.Log("QUITING SOFTWARE");
        Application.Quit();
    }

    public void showHowTo(){
    	main.SetActive(false);
    	howTo.SetActive(true);
    }

    public void hideHowTo(){
    	howTo.SetActive(false);
    	main.SetActive(true);
    }
}
