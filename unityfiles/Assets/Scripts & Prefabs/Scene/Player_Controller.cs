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

    private GameObject debugger;
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
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //Debug.Log ("jump");
                    onground = false;
                    rb.AddForce(Vector2.up * Jumpower);
                Debug.DrawRay(transform.position, -Vector2.up * 2.5F, Color.red);
                return;
                }
        }
        if (onground == false)
        {
            Debug.DrawRay(transform.position, -Vector2.up * 2.5F, Color.green);

          //  Debug.Log(Vector2.Distance(hit_.transform.position, transform.position));

        }
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        
            if (col.transform.tag == "Ground")
        {
            onground = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(onground == true)
        if (col.transform.tag == "Ground")
        {
                
                onground = false;
                OnCollisionEnter2D(col);
                return;
            }
    }
}
