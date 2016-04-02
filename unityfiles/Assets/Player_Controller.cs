using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour {

	public Animator AR;

	public float speed;
	// Use this for initialization
	void Start () {
		AR = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.A)) {
			AR.SetBool ("Run", true);
			if (Input.GetKeyDown (KeyCode.D)) {
				transform.Rotate(Vector3.
			}

			if (Input.GetKeyDown (KeyCode.A)) {

			}

		}
		if (Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.A)) {
			AR.SetBool ("Run", false);

		}


		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (transform.right * speed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (-transform.right * speed * Time.deltaTime);
		}
	}
}
