using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	public float speed;

    public Vector2 orig;

	void Start()
	{
        orig = transform.position;
		StartCoroutine ("Timer");
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (transform.up * speed * Time.deltaTime);
	}


	void OnCollisionEnter2D(Collision2D coll)
	{
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        if(coll.transform.tag == "Rex" || coll.transform.tag == "Player")
        {
            coll.gameObject.GetComponent<Player_Controller>().UpdateHealth(.2F);
            coll.gameObject.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * 800);
        }
	}

	IEnumerator Timer()
	{
		yield return new WaitForSeconds (5);
        transform.position = orig;
        this.gameObject.GetComponent<Collider2D>().enabled = true;
        StartCoroutine("Timer");
    }
}
