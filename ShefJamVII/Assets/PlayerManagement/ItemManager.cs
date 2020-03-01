using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

	public GameObject eventSystem;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
    	if (other.gameObject.tag == "Oil"){
			GetComponent<AudioSource>().Play();

    		eventSystem.GetComponent<ScoreManager>().resetOil();
    		Debug.Log("Refill");
    		Destroy(other.gameObject);
    	}

    	if (other.gameObject.tag == "Water"){
    		// Water effect
				GetComponent<MovementManager>().speedPenalty = 0.25f;
				GetComponent<MovementManager>().jumpHeight = 0.25f;
    	}

    	if (other.gameObject.tag == "Ice"){
    		// Ice effect
    	}
    	if (other.gameObject.tag == "Fire"){
    		// Fire Effect
    		eventSystem.GetComponent<ScoreManager>().endGame();
    	}
    }

		void OnCollisionExit(Collision other){
			if (other.gameObject.tag == "Water"){
				GetComponent<MovementManager>().speedPenalty = 1.0f;
				GetComponent<MovementManager>().jumpHeight = 0.5f;
			}
		}
}
