﻿using UnityEngine;
using System.Collections;


//this script handles the player's basic movement input and checks if it's fallen below the platforms, which causes a game over
[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {

	//Play an instance of boom sound using attached AudioSource component if the player loses
	public AudioClip loseSound = new AudioClip();

	//used to check for a high score
	private Score scoreScript;
	public float score;
	
	//player handling
	public float gravity = 20;
	public float speed = 8;
	public float acceleration = 50;
	public float jumpHeight = 12;

	private float currentSpeed;
	private float targetSpeed;
	private Vector2 amountToMove;
	private TextMesh timerScore;

	private PlayerPhysics playerPhysics;

	// Use this for initialization
	void Start () {
		playerPhysics = GetComponent<PlayerPhysics> ();
	}
	
	// Update is called once per frame
	void Update () {

		//reset speed if side collision
		if (playerPhysics.movementStopped) {
			targetSpeed = 0;
			currentSpeed = 0;
		}

		//Input
		targetSpeed = Input.GetAxisRaw ("Horizontal") * speed;
		currentSpeed = IncrementTowards (currentSpeed, targetSpeed, acceleration);

		if (playerPhysics.grounded) {
			amountToMove.y = 0; //resets gravity's effects

			//Jump
			if(Input.GetButtonDown ("Jump")) {
				amountToMove.y = jumpHeight;
			}
		}

		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime; //set to 0 if you don't want gravity
		playerPhysics.Move (amountToMove * Time.deltaTime);

		//if the player falls off the level, its game over. Back to the main menu. Sets a new high score if reached
		if (transform.position.y < -10) {
			scoreScript = (Score)FindObjectOfType (typeof(Score));
			score = scoreScript.score;
			if(score > PlayerPrefs.GetFloat ("high score")){
				PlayerPrefs.SetFloat ("high score", score);
			}
			GetComponent<AudioSource>().PlayOneShot(loseSound);
			Application.LoadLevel (0);
		}
	}

	//increase n towards target by speed
	private float IncrementTowards(float n, float target, float a) {
				if (n == target) {
						return n;
				} else {
						float dir = Mathf.Sign (target - n); //which direction to move n to get closer to target?
						n += a * Time.deltaTime * dir;
						return (dir == Mathf.Sign (target - n)) ? n : target; //if n has now passed target then return target, otherwise return n
				}
		}
}
