﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	public GameObject eventSystem;
	private MenuManager menuManager;
	private ScoreManager scoreManager;
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
	[Range(0, 2.0f)]
	public float CAM_SENS = 0.25f;	// Mouse Sensitivity

	[Range(0, 10f)]
	public float upDistance = 2.5f;

	private Vector3 lastMouse = new Vector3(255,255,255); 	// Middle(ish) of screen rather than top corner

    // Start is called before the first frame update
    void Start()
    {
			// Get score and menu manager components of event system
    	menuManager = eventSystem.GetComponent<MenuManager>();
    	scoreManager = eventSystem.GetComponent<ScoreManager>();
			// Get initial offset vector
    	offset = new Vector3(player.position.x + camPosX, player.position.y + camPosY, player.position.z + camPosZ);

    }

    // Update is called once per frame
    void Update()
    {
			// if not paused or game over, move camera
    	if (!menuManager.paused && !scoreManager.gameOver)
    	{
				// Get amount the mouse has moved, and apply to the offset vector
				lastMouse = Input.mousePosition - lastMouse;
    		offset = Quaternion.AngleAxis((Vector3.right.x * lastMouse.x) * CAM_SENS, Vector3.up)* offset; //* Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * CAM_SENS, Vector3.right) * offset;

				// Move camera by specified amount
    		transform.position = player.transform.position - offset + new Vector3(0, upDistance, 0);

				// Look at the player
    		transform.LookAt(player.position);
				player.transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
    	}
			// Store current mouse position
			lastMouse = Input.mousePosition;
    }
}
