using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	public float score = 0.0f;
    // Start is called before the first frame update
    void Start()
    {	
        score = 0.0f;
        InvokeRepeating("updateScoreTime", 0, 1.0f);
    }


    void updateScoreTime(){
    	score += 10;
    }

    void updateScore(int i){
    	score += i;
    }

    void OnGUI(){
  
    	GUI.BeginGroup (new Rect(5, 5, 200.0f, 20));
		GUI.Box (new Rect (0, 0, 200.0f, 20.0f), "Score: " + score);
		GUI.EndGroup ();
    }



}
