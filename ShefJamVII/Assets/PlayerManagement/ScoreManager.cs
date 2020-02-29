using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public GameObject player;
	private MenuManager pauseMenu;
	public GameObject gameOverScreen;
	public GameObject finalScoreLabel;
	public GameObject finalCountryLabel;
	public GameObject camera;
	private CameraManager cameraManager;
	public bool gameOver = false;
	public int score = 0;
	public int oil;
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
	private float defaultTimeScale;
    // Start is called before the first frame update
    void Start()
    {
				cameraManager = camera.GetComponent<CameraManager>();
    		pauseMenu = GetComponent<MenuManager>();
				defaultTimeScale = Time.timeScale;
				resetGame();
    }
		public void resetOil(){
			oil = 1000;
		}

		void resetGame(){
			score = 0;
			resetOil();
			player.transform.position = new Vector3(3,3,3);
			player.GetComponent<Animator>().SetBool("Death", false);
			player.GetComponent<Animator>().SetBool("GameOver", false);
			player.GetComponent<Animator>().SetBool("Playing", false);
			player.transform.rotation = new Quaternion(0,0,0,0);
			player.SetActive(true);
			gameOver = false;
			gameOverScreen.SetActive(false);
			Time.timeScale = defaultTimeScale;
			cameraManager.resetCamera();
			InvokeRepeating("updateScoreTime", 0, 1.0f);
		}

    void Update(){
    	if (!pauseMenu.paused)
    	{
	    	if (oil > 2)
	    		oil -= 2;
	    	else
	    	{
					endGame();
	    	}
	    }
	    if (gameOver &&Input.GetKeyDown(KeyCode.Return))
					resetGame();
    }

		public void endGame(){

			oil = 0;
			CancelInvoke();
			//Debug.Log(player.GetComponent<Animator>().GetBool("Death"));
			if (!gameOver && !player.GetComponent<Animator>().GetBool("Death"))
			{
			
				player.GetComponent<Animator>().SetBool("Death", true);
				Debug.Log("DIE!");
			}

			if (player.GetComponent<Animator>().GetBool("GameOver"))
			{
				player.SetActive(false);
				finalScore();
				gameOver = true;
			}


			// if(player.GetComponent<Animation>().isPlaying)
			// 	Debug.Log("Playing");
			// if (!player.GetComponent<Animation>().isPlaying)
			// 	finalScore();
		}

    void updateScoreTime(){
    	//Debug.Log(pauseMenu.paused);
    	if (!pauseMenu.paused && !gameOver)
    		updateScore(100);
    }

    void updateScore(int i){
    	//Debug.Log(pauseMenu.paused);
    	if (!pauseMenu.paused && !gameOver)
    		score += i;
    		if (countries.ContainsKey(score))
    			country = countries[score/100];

    }

    private void finalScore(){
    	finalCountryLabel.GetComponent<Text>().text = country;
    	finalScoreLabel.GetComponent<Text>().text = "You Produced " + score + " million metric tons of pollution";
    	gameOverScreen.SetActive(true);
    	Time.timeScale = 0.0f;
    }

    void OnGUI(){
  		if(!gameOver) {
	    	GUI.BeginGroup (new Rect(5, 5, 300.0f, 50));
				GUI.Box (new Rect (0, 0, 200.0f, 20.0f), "Score: " + score);
				GUI.Box (new Rect (0, 30, 300.0f, 20.0f), "You're More Polluting Than: " + country);
				GUI.EndGroup ();

				GUI.BeginGroup (new Rect(Screen.width-205, 5, 300.0f, 50.0f));
				GUI.Box(new Rect(0 ,0, 200.0f, 20.0f), "Remaining Oil: " + (oil/10.0f));
				GUI.EndGroup();
			}
    }

		bool AnimatorIsPlaying(){
			Debug.Log("Playing");
         return player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length >
                player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime;
    }


}
