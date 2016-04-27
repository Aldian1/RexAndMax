using UnityEngine;
using System.Collections;

public class Platform_Fall : MonoBehaviour {

    private Vector2 spawn;

    void Start()
    {
        spawn = transform.position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        GetComponent<Animation>().Play();
        StartCoroutine("Timer");
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2F);
        GetComponent<Rigidbody2D>().isKinematic = false;
        yield return new WaitForSeconds(5F);
        transform.position = spawn;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }
}
