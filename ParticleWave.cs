using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class test : MonoBehaviour
{
	public Vector2 mouse;
	public int w = 128;
	public int h = 128;

	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;

	public Ray ray;
	public Vector3 point;
	public ParticleSystem particleChild;

	public int waveLeft = 0;
	public int waveRight = 0;
	public int timer = 0;


	public Vector2 previousHandPosition;
	public Vector2 currentHandPosition;

	public Vector3 previousForward;

    public Transform r;
    public float distance = 1.5f;

    public Texture2D cursor;
    public Transform rab;

	public bool derp;	// particle.emmisions.enabled handle

    void Start()
    {

        //Get reference to the Transform of GameObject
        rab = GetComponent<Transform>();

        //particle System

        particleChild = GetComponent<ParticleSystem>();

       // particleChild.collision.enabled;
		particleChild.Stop();
        //particleChild.

        Cursor.visible = false;
        currentHandPosition = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        previousHandPosition = currentHandPosition;
		previousForward = transform.forward;
    }
    //public Ray ray;
    //public Vector3 point;


    void LateUpdate()
    {

        currentHandPosition = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        //rab.position = mouse;
        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        point  = ray.origin + (ray.direction * distance);

		if (Vector3.Cross (transform.forward, previousForward).y > 0/*currentHandPosition.x < previousHandPosition.x*/) {
			previousForward = transform.forward;
            waveLeft++;
        }
		else if (Vector3.Cross (transform.forward, previousForward).y < 0/*currentHandPosition.x > previousHandPosition.x*/) {
			previousForward = transform.forward;
			waveRight++;
        }
		else {

            if (timer < 1) {
                waveLeft = 0;
                waveRight = 0;
				//particleChild.Stop ();
				Debug.Log ("RESET");
            }

        }

        previousHandPosition = currentHandPosition;
		Debug.Log ("before: " + waveLeft + waveRight);
        if (waveLeft > 10 && waveRight > 10) {
			particleChild.Emit (1);

			Debug.Log ("Particles have executed");
			//particleChild.Play ();
            if(timer < 0)
            {

                timer = 15;
            }
        }


        timer--;

	 //Debug.Log (timer);
       // Debug.Log(waveLeft);
     //  Debug.Log(waveRight);
        //Debug.Log();

        rab.position = point;

        //particleChild.enableEmission = false;
    }


    void OnGUI()
    {
        //GUI.DrawTexture(new Rect(mouse.x - (w / 2), mouse.y - (h / 2), w, h), cursor);
    }
}