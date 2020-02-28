using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
	public float jumpHeight = 1.0f;
	public GameObject camera;
	//public GameObject pauseMenu;
	float MAIN_SPEED = 10.0f;	// Regular speed
	// float SHIFT_ADD = 50.0f;	// Shift speed multiplifer
	// float MAX_SHIFT = 500.0f;	// Maximum speed with shift
	
	private float totalRun = 1.0f ;
	private Vector3 camForward;
	private Vector3 camRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (true){//!MenuManager.paused) {

        

 			
        	camForward = camera.transform.forward;
        	camForward.y = 0f;
        	camForward.Normalize();


        	camRight = camera.transform.right;
        	camRight.y = 0f;
        	camRight.Normalize();

            //Keyboard Commands
           //float f = 0.0f;
            Vector3 p = GetBaseInput();
            // if (Input.GetKey(KeyCode.LeftShift)){	//Run
            // 	totalRun += Time.deltaTime;
            // 	p = p *totalRun * SHIFT_ADD;
            // 	p.x = Mathf.Clamp(p.x, -MAX_SHIFT, MAX_SHIFT);
            // 	p.y = Mathf.Clamp(p.y, -MAX_SHIFT, MAX_SHIFT);
            // 	p.z = Mathf.Clamp(p.z, -MAX_SHIFT, MAX_SHIFT);
            // }
            // else{
            	totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            	p = p * MAIN_SPEED;
            // }

            p = p * Time.deltaTime;
            Vector3 newPosition = transform.position;
            if (Input.GetKey(KeyCode.LeftShift)){	//Move only on X and Z axis
            	transform.Translate(p);
            	newPosition.x = transform.position.x;
            	newPosition.z = transform.position.z;
            	transform.position = newPosition;
            }
            else {
            	transform.Translate(p);
            }
        }
    }

    // Return basic values. If no input present, return 0
    // --------------------------------------------------
    private Vector3 GetBaseInput() {
    	Vector3 p_Velocity = new Vector3();
    	if (Input.GetKey(KeyCode.W)){
    		p_Velocity += camForward;
    	}
    	if (Input.GetKey(KeyCode.S)) {
    		p_Velocity += -camForward;
    	}
    	if (Input.GetKey(KeyCode.A)){
    		p_Velocity += -camRight;
    	}
    	if (Input.GetKey(KeyCode.D)) {
    		p_Velocity += camRight;
    	}
       	if (Input.GetKey(KeyCode.Space)){
       		p_Velocity += new Vector3(0,jumpHeight,0);
       	}
       	return p_Velocity;
    }
}
