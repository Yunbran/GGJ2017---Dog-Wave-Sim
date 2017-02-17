using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogController : MonoBehaviour {

	public bool babySighted;
	public bool calmedDown;
	public Transform escapePoint;

	GameObject baby;
	NavMeshAgent nav;
	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		baby = GameObject.FindGameObjectWithTag ("Player");
		playerController = baby.GetComponent<PlayerController> ();
		nav = GetComponent<NavMeshAgent> ();
		babySighted = false;
		calmedDown = false;
	}

	// Update is called once per frame
	void LateUpdate() {
		if (!calmedDown) {
			Vector3 fwd = transform.TransformDirection (Vector3.forward);
			babySighted = Physics.Raycast (transform.position, fwd, 100);

			nav.SetDestination (baby.transform.position);
			transform.LookAt (baby.transform.position);
		}
	}



	void OnParticleCollision(GameObject other)
	{
		playerController.score++;
		calmedDown = true;
		nav.SetDestination(escapePoint.position);
	//	Debug.Log("asd");
	}


	void OnMouseDown() {
		playerController.score++;
		calmedDown = true;
		nav.SetDestination(escapePoint.position);
	}
}
