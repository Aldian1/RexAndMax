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
	
		if (Input.GetKeyDown (KeyCode.D) && !Input.GetKey(KeyCode.A)) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
			AR.SetBool ("Run", true);
		}

		if (Input.GetKeyDown (KeyCode.A) && !Input.GetKey(KeyCode.D)) {
			transform.rotation = Quaternion.Euler (0, 180, 0);

		}

		/*if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp(KeyCode.D)) {
			AR.SetBool ("Run", false);
		}*/


		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (transform.right * speed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (-transform.right * speed * Time.deltaTime);
		}
	}
}
