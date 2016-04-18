using UnityEngine;
using System.Collections;

public class FollowerScript : MonoBehaviour {

	private Transform thistransform;

	public Transform target;

	public float smoothtime;

	private Vector2 velocity;

	// Use this for initialization
	void Start () {
		thistransform = transform;
		target.parent.GetComponent<Animator> ().SetBool ("Run", true);
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector2.Distance (transform.position, target.position) < 8) {
			transform.position = Vector2.SmoothDamp (transform.position, target.position, ref velocity, Time.deltaTime * smoothtime);
			transform.rotation = target.rotation;


		}

	}
}
