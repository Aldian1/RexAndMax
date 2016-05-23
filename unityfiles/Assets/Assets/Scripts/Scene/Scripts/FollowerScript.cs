using UnityEngine;
using System.Collections;

public class FollowerScript : MonoBehaviour {

	private Transform thistransform;

	public Transform target,attackpos, tailpos;

	public float smoothtime;

	private Vector2 velocity;

    public Animator ar;

    private bool follow;

    private bool KB;


    private int attackframe;

    private Player_Controller pr;




    // Use this for initialization
    void Start () {
		thistransform = transform;
        pr = target.parent.GetComponent<Player_Controller>();
        ar = GetComponent<Animator>();
        if(pr.keyboardcontrols == true)
        {
            KB = true;
        }
        tailpos = target;

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            pr.InCombat = true;

            pr.AR.SetFloat("Run", 0);
            target = attackpos;


            StopCoroutine("AttackTimer");
            if (attackframe == 0)
            {
                ar.SetBool("Atk1", true);
                attackframe = 1;
                StartCoroutine("AttackTimer");
               
                return;
            }
            if (attackframe == 1)
            {
                ar.SetBool("Atk2", true);
                attackframe = 2;
                StartCoroutine("AttackTimer");
               
                return;
            }
            if (attackframe == 2)
            {
                ar.SetBool("Atk3", true);
                attackframe = 0;
                StartCoroutine("AttackTimer");
               
                return;
            }


           
               
            }
        


        


        if (KB)
        {
            ar.SetFloat("Blend", Input.GetAxis("Horizontal"));
        }
			transform.position = Vector2.SmoothDamp (transform.position, target.position, ref velocity, Time.deltaTime * smoothtime);
		if(target.parent.localScale.x == 0.35F)
        {
            // transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.localScale = new Vector3(.35F, .35F, .35F);


        }
        else
        {
            //transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.localScale = new Vector3(-.35F, .35F, .35F);
           
        }
	}

    public void sliderfloater(float value)
    {
        ar.SetFloat("Blend", value);
    }

    public void AttackButton()
    {
        pr.InCombat = true;

        pr.AR.SetFloat("Run", 0);
        target = attackpos;


        StopCoroutine("AttackTimer");
        if (attackframe == 0)
        {
            ar.SetBool("Atk1", true);
            attackframe = 1;
            StartCoroutine("AttackTimer");
            return;
        }
        if (attackframe == 1)
        {
            ar.SetBool("Atk2", true);
            attackframe = 2;
            StartCoroutine("AttackTimer");
            return;
        }
        if (attackframe == 2)
        {
            ar.SetBool("Atk3", true);
            attackframe = 0;
            StartCoroutine("AttackTimer");
            return;
        }


    }

    IEnumerator AttackTimer()
    {
        yield return new WaitForSeconds(1);
        if (ar.GetBool("Atk1") == true && ar.GetBool("Atk2") == false)
        {
            ar.SetBool("Atk1", false);
            attackframe = 0;
            target = tailpos;
            pr.InCombat = false;
           
        }
        if (ar.GetBool("Atk2") == true && ar.GetBool("Atk3") == false)
        {
            ar.SetBool("Atk2", false);
            attackframe = 0;
            target = tailpos;
            pr.InCombat = false;
           

        }
        if (ar.GetBool("Atk3") == true)
        {
            ar.SetBool("Atk1", false);
            ar.SetBool("Atk2", false);
            ar.SetBool("Atk3", false);
            attackframe = 0;
            target = tailpos;
            pr.InCombat = false;

        }
        
    }

  
}
