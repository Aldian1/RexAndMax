using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {


    private bool playernear;
    public GameObject ObjecToInteractWith;
    public string animtosettrue;
    Animator ar;

    void Start()
    {
        ar = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        ar.SetBool("On", true);
        ObjecToInteractWith.GetComponent<Animator>().SetBool(animtosettrue, true);
    }
}
