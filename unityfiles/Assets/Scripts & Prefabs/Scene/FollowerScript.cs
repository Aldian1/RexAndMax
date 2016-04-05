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
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector2.SmoothDamp (transform.position, target.position, ref velocity, Time.deltaTime * smoothtime);
		transform.rotation = target.rotation;

	}
}
