using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	public GameObject eventSystem;
	private MenuManager menuManager;
	private Vector3 offset;
	
	public Transform player;

	[Space]
	[Header("Position")]
	public float camPosX;
	public float camPosY;
	public float camPosZ;

	[Space]
	[Header("Rotation")]
	public float camRotX;
	public float camRotZ;
	public float camRotY;

	[Space]
	[Range(0, 10f)]
	public float CAM_SENS = 0.25f;	// Mouse Sensitivity

	[Range(0, 10f)]
	public float upDistance = 2.5f;

	//private Vector3 lastMouse = new Vector3(255,255,255); 	// Middle(ish) of screen rather than top corner

    // Start is called before the first frame update
    void Start()
    {
    	menuManager = eventSystem.GetComponent<MenuManager>();
    	offset = new Vector3(player.position.x + camPosX, player.position.y + camPosY, player.position.z + camPosZ);
       // transform.rotation = Quaternion.Euler(camRotY, camRotY, camRotZ);
    }

    // Update is called once per frame
    void Update()
    {
    	if (!menuManager.paused)
    	{
    		offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * CAM_SENS, Vector3.up)* offset; //* Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * CAM_SENS, Vector3.right) * offset;
    		Vector3 tempPos = transform.position;
    		transform.position = player.transform.position - offset + new Vector3(0, upDistance, 0);
    		
    		transform.LookAt(player.position);
    	}
   //  	lastMouse = Input.mousePosition - lastMouse;
       

   //     	//Quaternion rot = transform.rotation;
 		// //rot.y += Input.mousePosition.y * CAM_SENS * lastMouse.y; //change position, add symbol"+"
   //      transform.Rotate(Vector3.right.y * lastMouse.y, 0, 0);
     
   //   	//rot.y = Mathf.Clamp(rot.y, -20, 20);
   //      //transform.rotation = rot;

        
 		
			
   // 			//And check for your diapason
   // 	// 		if (transform.rotation.x > 20) {
   // 	// 			Debug.Log("x > 20");
 		// 	// 	rot.x = 20; 
			// 	// transform.rotation = rot;
   // 	// 		} else if (transform.rotation.x < -20) {
   // 	// 			Debug.Log("X < -20");
 		// 	// 	rot.x = -20; 
			// 	// transform.rotation = rot;
   // 	// 		}

   //          // lastMouse = Input.mousePosition - lastMouse;
   //          // lastMouse = new Vector3(transform.right * - lastMouse * CAM_SENS);
   //          // //lastMouse = new Vector3(-lastMouse.y * CAM_SENS, lastMouse.x * CAM_SENS, 0);
   //          // //lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
   //          // transform.eulerAngles = lastMouse;
   //          lastMouse = Input.mousePosition;
            //Mouse Camera Angle computed
    }
}
