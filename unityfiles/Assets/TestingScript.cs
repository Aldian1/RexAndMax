using UnityEngine;
using System.Collections;

public class TestingScript : MonoBehaviour {

    Animator ar;
    public bool triggerbased;

    
    // Use this for initialization
	void Start () {
        ar = GetComponent<Animator>();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (triggerbased)
        {
            if (col.tag == "Player")
            {
                Door(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (triggerbased)
        {
            if (col.tag == "Player")
            {
                Door(false);
            }
        }
    }


    void Door(bool open)
    {
        if(open == true)
        {
            ar.SetBool("Open", true);
        }
        if (open == false)
        {
            ar.SetBool("Open", false);
        }

    }
}
