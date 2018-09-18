using UnityEngine;
using System.Collections;

//this script is used to calculate and display the high score during the game
public class Score : MonoBehaviour {
	
	public float score = 0;					// The player's score. 
	public float startTime = 0;				// The time the player starts should be zero
	public TextMesh ts;

	void Awake ()
	{
	}

	void Start(){
		startTime=Time.time; //just in case the time is not zero
		ts = (TextMesh)gameObject.GetComponent(typeof(TextMesh));
	}

	void Update ()
	{
		// Set the score text.
		score = Time.time - startTime;
		ts.text = "" + score;

	}
}
