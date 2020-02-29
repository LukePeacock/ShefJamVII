using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public bool paused = false;
    public GameObject controlMenuUI;
    private float defaultTimeScale;

    void Start(){
        Debug.Log("Loading Menu");
        controlMenuUI.SetActive(false);
        defaultTimeScale = Time.timeScale;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
        	if (paused)
        		Resume();
        	else 
        		Pause();
        }
    }

    public void Resume(){
    	Time.timeScale = defaultTimeScale;
    	paused = false;
    	controlMenuUI.SetActive(false);
    }

    public void Pause() {
    	Time.timeScale = 0.0f;
    	controlMenuUI.SetActive(true);
    	paused = true;
    }

    // // public void SelectFile(){
    // //     SetSelectFileMessage("Please Wait ...");
    // //    //ImportFile("F:\\Dissertation\\Inside-The-Cloud\\stgallencathedral_station1_intensity_rgb.txt", this);
    // //     //StartCoroutine(importer.ImportFile("/Volumes/Luke32/Dissertation/Inside-The-Cloud/Clouds/stgallencathedral_station1_intensity_rgb.txt", this)); 
    // //     StartCoroutine(importer.ImportFile("/Volumes/Luke32/Dissertation/Inside-The-Cloud/Clouds/Cloud_file.txt", this)); 
    // // }

    // // public void SetSelectFileMessage(string message)
    // // {
    // // 	SelectFileText.text = message;
    // // }

    public void QuitGame(){
    	Debug.Log("QUITING SOFTWARE");
        Application.Quit();
    }
}
