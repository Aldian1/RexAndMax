using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

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
        
        
        StartCoroutine("Timer", Camera.main.GetComponent<Camera2DFollow>().target);

    }

    IEnumerator Timer(Transform go)
    {
        Camera.main.GetComponent<Camera2DFollow>().target = ObjecToInteractWith.transform;
        yield return new WaitForSeconds(2F);
        Camera.main.GetComponent<Camera2DFollow>().target = go;
        this.enabled = false;
    }
}
