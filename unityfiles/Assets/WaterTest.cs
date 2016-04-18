using UnityEngine;
using System.Collections;

public class WaterTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        col.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
    }
}
