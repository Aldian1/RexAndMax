using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	public float speed;

	void Start()
	{
		StartCoroutine ("Timer");
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (transform.right * speed * Time.deltaTime);
	}


	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.transform.tag != "Rex")
		Destroy (this.gameObject);
	}

	IEnumerator Timer()
	{
		yield return new WaitForSeconds (3);
		Destroy (this.gameObject);
	}
}
