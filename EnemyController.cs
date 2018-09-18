using UnityEngine;
using System.Collections;

//this script is for manipulating individual enemies and handling collisions with the player
[RequireComponent (typeof(BoxCollider))]
public class EnemyController : MonoBehaviour {

	//Play an instance of boom sound using attached AudioSource component if the player loses
	public AudioClip loseSound = new AudioClip();

	//used to check for a high score
	public Score scoreScript;
	public float score;

	public float speed = 3;
	public float acceleration = 50;
	private BoxCollider collider;

	// Use this for initialization
	void Start () { 
		collider = GetComponent<BoxCollider> ();
	}
	
	// Update is called once per frame
	void Update () { 
		transform.position += new Vector3(-speed, 0, 0);

		//destroy the enemy if the player has dodged it
		if (transform.position.x < -20) {
			GameObject.Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		//collision with the player means game over and back to the main menu. Sets a new high score if reached
		if (collider.gameObject.tag == "Player") {
			scoreScript = (Score)FindObjectOfType (typeof(Score));
			score = scoreScript.score;
			if(score > PlayerPrefs.GetFloat ("high score")){
					PlayerPrefs.SetFloat ("high score", score);
			}
			GetComponent<AudioSource>().PlayOneShot(loseSound);
			Application.LoadLevel (0);
		}
	}
}
