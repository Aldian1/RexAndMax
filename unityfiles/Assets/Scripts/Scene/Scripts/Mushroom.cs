using UnityEngine;
using System.Collections;

public class Mushroom : MonoBehaviour {

    Animation an;
    public float force;

	// Use this for initialization
	void Start () {
        an = GetComponent<Animation>();
	}
	


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
            {
            an.Play();
            StartCoroutine("Timer", col);
        }
    }

    IEnumerator Timer(Collider2D col)
    {
        yield return new WaitForSeconds(.45F);
        col.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
    }
}
