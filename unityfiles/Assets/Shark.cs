using UnityEngine;
using System.Collections;

public class Shark : MonoBehaviour
{

	public bool flip;

	public float length;

	public float speed;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine ("Timer");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (flip) {
			if (transform.rotation.y == 0) {
				transform.Rotate (0, 180, 0);

				flip = false;
				return;
			}
			if (transform.rotation.y >= 170) {
				transform.Rotate (0, 0, 0);

				flip = false;
				return;
			}

		}

		if (transform.rotation.y >= 170) {
			transform.Translate (transform.right * Time.deltaTime * speed);
			Debug.Log ("titties");
		}

		if (transform.rotation.y == 0) {
			transform.Translate (-transform.right * Time.deltaTime * speed);
			Debug.Log ("titties123");
		}
	}

	IEnumerator Timer ()
	{
		yield return new WaitForSeconds (length);
		flip = true;
		StartCoroutine ("Timer");
	}
}
