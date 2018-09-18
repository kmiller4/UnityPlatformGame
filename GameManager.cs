using UnityEngine;
using System.Collections;

//this script spawns the player and the camera while assinging the camera to the player
public class GameManager : MonoBehaviour {

	public GameObject player;
	private GameCamera cam;

      

	// Use this for initialization
	void Start () {
		cam = GetComponent<GameCamera> ();
		spawnPlayer ();


	}

	private void spawnPlayer(){
		cam.setTarget ((Instantiate (player, Vector3.zero, Quaternion.identity) as GameObject).transform);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
