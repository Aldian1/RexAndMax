using UnityEngine;
using System.Collections;

public class WheelPlatform : MonoBehaviour {


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.transform.parent = this.transform;
            Debug.Log("1");
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.transform.parent = null;
        }
    }
}
