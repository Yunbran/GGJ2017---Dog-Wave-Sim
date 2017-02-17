using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public int score;

	public GameObject ui;
	private StartOptions options;

	void Awake () {
		options = ui.GetComponent<StartOptions> ();
	}

    //Reference to the UI Slider for Health
    public Slider uneaseSlider;

     //Reference to Collision Detection
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Doggo")) {
			if (++uneaseSlider.value >= uneaseSlider.maxValue) {
				Reset ();
			}
		}
	}
		
    void Reset() {
	SceneManager.LoadScene(0);


        //playerMovement.enabled = false;
        //playerShooting.enabled = false;
    }
}