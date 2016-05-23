using UnityEngine;
using System.Collections;

public class Physcis_controller : MonoBehaviour {


	Rigidbody2D rb;

	public Transform target;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (Vector2.Distance (transform.position, target.transform.position) < 1.5F) {
			rb.isKinematic = true;
		}

		Debug.Log (Vector2.Distance (transform.position, target.transform.position));
	}
}
