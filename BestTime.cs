using UnityEngine;
using System.Collections;

//this script displays the best time a player has earned in the game on the main menu
public class BestTime : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<TextMesh>().text = "Best Time: " + PlayerPrefs.GetFloat ("high score");
	}
	
	// Update is called once per frame
	void Update () {
	}
}
