using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityStandardAssets.Utility;
using UnityStandardAssets._2D;

public class Player_Controller : MonoBehaviour {

	public Animator AR;

	public float speed;

	public GameObject othercharacter;

	public Rigidbody2D rb;

	public float Jumpower;

	public GameObject camera_;

	private bool isrex;

	public Transform rexfireball;

	public GameObject fireball;

	public  List<GameObject> fireballs = new List<GameObject>() ;

    public bool onground;
	// Use this for initialization
	void Start () {
  

		rb = GetComponent<Rigidbody2D> ();
		AR = GetComponent<Animator> ();
		Physics2D.IgnoreCollision (othercharacter.GetComponent<Collider2D> (), this.GetComponent<Collider2D> ());
		AR.SetBool ("Run", true);
		if (this.gameObject.tag == "Rex") {
			isrex = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if (isrex) {
			if (fireballs.Count > 0) {
				if (fireballs [0] == null) {
					fireballs.Clear ();
				}
			}
			if (fireballs.Count < 3) {
				if (Input.GetKeyDown (KeyCode.Mouse1)) {
					GameObject go = Instantiate (fireball, rexfireball.position, Quaternion.identity) as GameObject;
					fireballs.Add (go);
				}
			}
		}

		if (Input.GetKey (KeyCode.D)) {
                AR.SetBool("Run", true);
        }

		if (Input.GetKey (KeyCode.A)) {
                AR.SetBool("Run", true);
		}

	
		if (!Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.A)) {
			AR.SetBool ("Run", false);
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (transform.right * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

		if (Input.GetKey (KeyCode.A)) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate (-transform.right * speed * Time.deltaTime);
		}

	
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			othercharacter.GetComponent<FollowerScript> ().enabled = false;
			othercharacter.GetComponent<Player_Controller> ().enabled = true;
			this.GetComponent<FollowerScript> ().enabled = true;
			this.GetComponent<Player_Controller> ().enabled = false;
			camera_.GetComponent<Camera2DFollow> ().target = othercharacter.transform;
		}

        if (onground == true)
        {

            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up * 20);

        if (hit.transform.gameObject.layer == 8)
            {
          
               
                Debug.DrawRay(transform.position, -Vector2.up * 20, Color.red);

               
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //Debug.Log ("jump");
                    onground = false;
                    rb.AddForce(Vector2.up * Jumpower);
                   
                    return;
                }

            }
        }

      

        if (onground == false)
        {
            RaycastHit2D hit_ = Physics2D.Raycast(transform.position, -Vector2.up * 20);
            Debug.DrawRay(transform.position, -Vector2.up * 20, Color.green);

            Debug.Log(Vector2.Distance(hit_.transform.position, transform.position));
            Debug.Log(hit_.transform.name);

            if (Vector2.Distance(hit_.transform.position, transform.position) < 3.4F)
            {
                Debug.Log(Vector2.Distance(hit_.transform.position, transform.position));
                onground = true;
                return;
            }

        }
	}

}
