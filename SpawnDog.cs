using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDog : MonoBehaviour {

	public GameObject dog;
	public float spawnTime = 3f;
	public float barkTime = 5f;
	public Transform[] spawnPoints;
	public AudioSource[] barks;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		InvokeRepeating ("Bark", barkTime, barkTime);
	}
	
	// invoked every spawnTime seconds
	void Spawn () {
		int spawnIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (dog, spawnPoints [spawnIndex].position, spawnPoints [spawnIndex].rotation);
		int barkIndex = Random.Range (0, barks.Length);
		barks [barkIndex].Play ();
	}

	void Bark() {
		int barkIndex = Random.Range (0, barks.Length);
		barks [barkIndex].Play ();
	}
}
