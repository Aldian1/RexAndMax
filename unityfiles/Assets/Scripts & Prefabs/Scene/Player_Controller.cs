using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour {

	public Animator AR;

	public float speed;

	public GameObject rex;

	public Rigidbody2D rb;

	public float Jumpower;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		AR = GetComponent<Animator> ();
		Physics2D.IgnoreCollision (rex.GetComponent<Collider2D> (), this.GetComponent<Collider2D> ());
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.D) && !Input.GetKey(KeyCode.A)) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
			AR.SetBool ("Run", true);
		}

		if (Input.GetKeyDown (KeyCode.A) && !Input.GetKey(KeyCode.D)) {
			transform.rotation = Quaternion.Euler (0, 180, 0);
			AR.SetBool ("Run", true);

		}

	
		if (!Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.A)) {
			AR.SetBool ("Run", false);
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (transform.right * speed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (-transform.right * speed * Time.deltaTime);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("jump");
			rb.AddForce (Vector2.up * Jumpower);
		}
	}
}
