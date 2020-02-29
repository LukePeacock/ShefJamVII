using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public bool paused = false;
    public GameObject controlMenuUI;
    private float defaultTimeScale;
    private bool gameOver;

    void Start(){
        Debug.Log("Loading Menu");
        controlMenuUI.SetActive(false);
        defaultTimeScale = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        gameOver = GetComponent<ScoreManager>().gameOver;
        if (!gameOver && Input.GetKeyDown(KeyCode.Escape)){
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
      Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause() {
      Cursor.lockState = CursorLockMode.None;
    	Time.timeScale = 0.0f;
    	controlMenuUI.SetActive(true);
    	paused = true;
    }

    public void QuitGame(){
    	Debug.Log("QUITING SOFTWARE");
        Application.Quit();
    }
}
