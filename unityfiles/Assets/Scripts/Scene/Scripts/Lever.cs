using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class Lever : MonoBehaviour {


    private bool playernear, tapped;
    public GameObject ObjecToInteractWith;
    public string animtosettrue;
    Animator ar;
    public GameObject tap;

    public enum Type
    {
        lever = 0,
        button = 1,
    };

    public Type Type_;
    void Start()
    {
        if (Type_ == Type.lever) {
            ar = GetComponent<Animator>();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //tap.SetActive(true);
           // if (tapped == true)
           // {
                if (Type_ == Type.lever)
                {

                    ar.SetBool("On", true);
                    ObjecToInteractWith.GetComponent<Animator>().SetBool(animtosettrue, true);
                    StartCoroutine("Timer", Camera.main.GetComponent<Camera2DFollow>().target);
               // }
            }
        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
         //   tap.SetActive(false);
        }
    }

	void OnCollisionEnter2D(Collision2D col)
	{
		if (Type_ == Type.button) {
			if (col.transform.name == "Box") {
				transform.localScale = new Vector3 (1,.5F,1);
				StartCoroutine ("Timer", Camera.main.GetComponent<Camera2DFollow> ().target);
				ObjecToInteractWith.GetComponent<Animator> ().SetBool (animtosettrue, true);
				return;
			}
		}

	}

    IEnumerator Timer(Transform go)
    {
		if (this.enabled == true) {
			Camera.main.GetComponent<Camera2DFollow> ().target = ObjecToInteractWith.transform;
			yield return new WaitForSeconds (2F);
			Camera.main.GetComponent<Camera2DFollow> ().target = go;
			this.enabled = false;
			StopCoroutine ("Timer");
		}
    }
}
