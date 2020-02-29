using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeFollow : MonoBehaviour {
	public Transform mTarget;
	float mSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	// transform.LookAt(mTarget.position);
    	// transform.Translate(0.0f, mSpeed*Time.deltaTime, 0.0f);
        
    }
}
