using UnityEngine;
using System.Collections;

public class Radial_SubComponent : MonoBehaviour {


    private Animation ar;

    void Start()
    {
        ar = GetComponent<Animation>();
       
    }

   public void MouseOver()
    {
        ar.Play("Radial_Sub");
    }

   public void MouseExit()
    {
        ar.Play("Radial_Unsub");
    }

    void Locked()
    {

    }
}
