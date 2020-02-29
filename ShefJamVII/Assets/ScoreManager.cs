using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	private MenuManager pauseMenu;
	public int score = 0;
	private Dictionary<int, string> countries = new Dictionary<int, string>(){
				{280, "Poland"},
				{290, "France"},
				{320, "Turkey"},
				{330, "Italy"},
				{380, "Australia"},
				{390, "United Kingdom"},
				{430, "South Africa"},
				{440, "Indonesia and Mexico"},
				{450, "Brazil"},
				{530, "Saudi Arabia"},
				{550, "Canada and Iran"},
				{590, "South Korea"},
				{730, "Germany"},
				{1140, "Japan"},
				{1470, "Russia"},
				{2070, "India"},
				{5000, "United States"},
				{9040, "China"}
												};		//http://worldpopulationreview.com/countries/pollution-by-country/
	private string country = "Most People";
    // Start is called before the first frame update
    void Start()
    {	
    	pauseMenu = GetComponent<MenuManager>();
        score = 0;
        InvokeRepeating("updateScoreTime", 0, 1.0f);
    }


    void updateScoreTime(){
    	//Debug.Log(pauseMenu.paused);
    	if (!pauseMenu.paused)
    		updateScore(10);
    }

    void updateScore(int i){
    	//Debug.Log(pauseMenu.paused);
    	if (!pauseMenu.paused)
    		score += i;
    		if (countries.ContainsKey(score))
    			country = countries[score];
    	
    }

    private string finalScore(){
    	string s = "You're more polluting than: ";
    	s += country;
    	s += "\n\n";
    	s += "You produced " + score + "million metric tons";
    	return s;
    }

    void OnGUI(){
  
    	GUI.BeginGroup (new Rect(5, 5, 500.0f, 50));
		GUI.Box (new Rect (0, 0, 200.0f, 20.0f), "Score: " + score);
		GUI.Box (new Rect (0, 30, 300.0f, 20.0f), "You're More Polluting Than: " + country);
		GUI.EndGroup ();
    }



}
