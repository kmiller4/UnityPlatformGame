using UnityEngine;
using System.Collections;

//this script is for keeping the camera focused on the player
public class GameCamera : MonoBehaviour {

	private Transform target;
	private float trackSpeed = 10;

	public void setTarget(Transform t){
		target = t;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//After each frame, move the camera to the player's new position
	void LateUpdate(){
		if (target) {
			float x = IncrementTowards (transform.position.x, target.position.x, trackSpeed);
			float y = IncrementTowards (transform.position.y, target.position.y, trackSpeed);
			transform.position = new Vector3(x, y, transform.position.z);
		}
	}

	//the camera moves the same way the player does
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
