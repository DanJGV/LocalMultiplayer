using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Cam : MonoBehaviour
{
	public bool mp;
	public float smoothing = 5f;
	public GameObject player;
	GameObject player2;
	private Vector3 offset;
	public bool playerFound = false;
	void Start()
	{


		


	}

	void FixedUpdate()
	{
		mp = player.GetComponent<spawner>().multiplayer;

		if (mp == false)
		{
			player2 = GameObject.Find("Player 2");
			playerFound = false;
		
			
		}
		else
		{
			playerFound = true;
			if (playerFound == true)
            {
				offset = transform.position - player2.transform.position;
			}
			Vector3 targetCamPos = player2.transform.position + offset;
			transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
			
		}
	}
}
