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
        this.GetComponent<Animator>().SetBool("running", true);
	}
	
	// Update is called once per frame
	void Update () {


			transform.position = Vector2.SmoothDamp (transform.position, target.position, ref velocity, Time.deltaTime * smoothtime);
		if(target.parent.localScale.x == 0.35F)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

          

        

	}
}
