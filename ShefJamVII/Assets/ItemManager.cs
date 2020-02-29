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
    		eventSystem.GetComponent<ScoreManager>().resetOil();
    		Debug.Log("Refill");
    		Destroy(other.gameObject);
    	}

    	if (other.gameObject.tag == "Water"){
    		// Water effect
    	}

    	if (other.gameObject.tag == "Ice"){
    		// Ice effect
    	}
    	if (other.gameObject.tag == "Fire"){
    		// Fire Effect
    		eventSystem.GetComponent<ScoreManager>().endGame();
    	}
    }
}
