using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
	public float jumpHeight = 0.5f;
	public GameObject camera;


	public GameObject eventSystem;
	private MenuManager menuManager;
	private ScoreManager scoreManager;
	float MAIN_SPEED = 10.0f;	// Regular speed


	private Vector3 camForward;
	private Vector3 camRight;
    // Start is called before the first frame update
    void Start()
    {
				// Get score and menu manager components of event system
				scoreManager = eventSystem.GetComponent<ScoreManager>();
        menuManager = eventSystem.GetComponent<MenuManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!menuManager.paused && !scoreManager.gameOver) {

					// Get camera forward, remove y axis, and normalise
        	camForward = camera.transform.forward;
        	camForward.y = 0f;
        	camForward.Normalize();

					// Get camera right, remove y axis, and normalize
        	camRight = camera.transform.right;
        	camRight.y = 0f;
        	camRight.Normalize();

          //Keyboard Commands
          // Rotate player based on camera forward direction to always face away
					transform.rotation = Quaternion.Euler(0.0f, camera.transform.eulerAngles.y, 0.0f);

					// Get user input
          Vector3 p = GetBaseInput();

					// Apply main speed and delta time to counter frame rate changes
					p = p * MAIN_SPEED * Time.deltaTime;

					// Translate
					transform.position += p;
        }
    }

    // Return basic values. If no input present, return just forward move
		// @return: vector3 p - direction(s) to move in stored as vector3
    // --------------------------------------------------
    private Vector3 GetBaseInput() {
    	Vector3 p_Velocity = new Vector3();

			// Constant move forwards
    	p_Velocity += camForward;//transform.forward;

			// If left, add left amount
    	if (Input.GetKey(KeyCode.A)){
    		p_Velocity += -camRight;//transform.right;
    	}
			// If right, add right amount
    	if (Input.GetKey(KeyCode.D)) {
    		p_Velocity += camRight;//transform.right;
    	}
			// If space if pressed, add up amount
      if (Input.GetKey(KeyCode.Space)){
      	p_Velocity += new Vector3(0,jumpHeight,0);
      }
			return p_Velocity;
    }
}
