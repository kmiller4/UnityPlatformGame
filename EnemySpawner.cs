using UnityEngine;
using System.Collections;

//this script is for using the enemySpawner to spawn enemies
public class EnemySpawner : MonoBehaviour {
	
	public float spawnTime = 3f;		// The amount of time between each spawn.
	public float spawnDelay = 2f;		// The amount of time before spawning starts.
	public GameObject[] enemies;		// Array of enemy prefabs.
	
	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}
	
	void Spawn ()
	{
		// Instantiate a random enemy(the enemies are the same for now, just different positions to spawn from)
		int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate(enemies[enemyIndex], enemies[enemyIndex].transform.position, enemies[enemyIndex].transform.rotation);
	}
}