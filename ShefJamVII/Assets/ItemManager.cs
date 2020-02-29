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
    		eventSystem.GetComponent<ScoreManager>().oil = 10000;
    		Debug.Log("Refill");
    		Destroy(other.gameObject);
    	}
    }
}
