using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {


    void Update()
    {

            transform.Translate(0, -25 * Time.deltaTime, 0);
        
    }

    void OnEnable()
    {
        Invoke("Destroy", 2F);
    }

    void Destroy()
    {
        GetComponent<TrailRenderer>().enabled = false;
        gameObject.SetActive(false);
        GetComponent<Rigidbody2D>().gravityScale = .1F;

    }

    void OnDisable()
    {
        CancelInvoke();

       
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag == "Ground")
        {
        
            Destroy();
        }
    }
}
