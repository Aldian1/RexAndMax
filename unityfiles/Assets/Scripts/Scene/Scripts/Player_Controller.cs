using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityStandardAssets.Utility;
using UnityStandardAssets._2D;

public class Player_Controller : MonoBehaviour
{

    public Animator AR;

    public float speed;

    public GameObject othercharacter;

    public Rigidbody2D rb;

    public float Jumpower;

    public GameObject camera_;

    private bool isrex;

    public Transform rexfireball;

    public GameObject fireball;

    public List<GameObject> fireballs = new List<GameObject>();

    public bool onground;

    private GameObject debugger;
    public GameObject balloon;

    public bool invincible;

    private Color sprite;

    private bool keyboardcontrols;

    public Sprite[] RexAttacks;


    // Use this for initialization
    void Start()
    {

        sprite = GetComponent<SpriteRenderer>().color;
        rb = GetComponent<Rigidbody2D>();
        AR = GetComponent<Animator>();
        Physics2D.IgnoreCollision(othercharacter.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());

        if (this.gameObject.tag == "Rex")
        {
            isrex = true;
        }
    }

    // Update is called once per frame
    void Update()
    {


        Controls();


        if (onground == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log ("jump");
                onground = false;
                rb.AddForce(Vector2.up * Jumpower);
                Debug.DrawRay(transform.position, -Vector2.up * 2.5F, Color.red);
                return;
            }
        }
        if (onground == false)
        {
            Debug.DrawRay(transform.position, -Vector2.up * 2.5F, Color.green);

            //  Debug.Log(Vector2.Distance(hit_.transform.position, transform.position));

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!invincible)
        {
            if (col.transform.tag == "Spikes")
            {
                rb.AddForce(new Vector2(-1, 1) * 600);
                invincible = true;
                StartCoroutine("Invincible");
                UpdateHealth(.2F);
            }
        }

        if (col.transform.tag == "Ground")
        {
            onground = true;
        }

    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (onground == true)
            if (col.transform.tag == "Ground")
            {

                onground = false;
                OnCollisionEnter2D(col);
                return;
            }
    }

    IEnumerator Invincible()
    {
        sprite.a = .5F;
        GetComponent<SpriteRenderer>().color = sprite;
        yield return new WaitForSeconds(3);
        sprite.a = 1F;
        GetComponent<SpriteRenderer>().color = sprite;
        invincible = false;
        StopCoroutine("Invincible");

    }


    public void GetItem(ItemDetection.Items item)
    {
        if (item == ItemDetection.Items.BalloonPowerup)
        {
            balloon.SetActive(true);
            rb.gravityScale = -.2F;
        }

        if (item == ItemDetection.Items.Stars)
        {
            GameObject.Find("StarCounter").GetComponent<StarCounter>().AddStars(1);
        }

		if (item == ItemDetection.Items.GorillaMilk) {
			GorillaMode ();
		}

    }

    //Debugger to change controls
    public void ToggleButton(bool active)
    {
        if (active == true)
        {
            keyboardcontrols = true;
        }
        if (active == false)
        {
            keyboardcontrols = false;
        }
    }

    public void SliderStick(float value)
    {

    }



    public void UpdateHealth(float damage)
    {
        if (isrex)
        {
            GameObject.Find("Health_Rex").GetComponent<HealthListener>().updatehealth(damage);
        }
        else
        {
            GameObject.Find("Health_Max").GetComponent<HealthListener>().updatehealth(damage);
        }
    }

    public void Controls()
    {
        //setting the wait thing, atm this is just a hack way
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (othercharacter.GetComponent<FollowerScript>().enabled == false)
            {
                othercharacter.GetComponent<FollowerScript>().enabled = true;
            }
            else
            {
                othercharacter.GetComponent<FollowerScript>().enabled = false;
            }


        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && balloon.activeSelf == true)
        {
            balloon.SetActive(false);
            rb.gravityScale = 2.5F;
        }

            if (Input.GetKey(KeyCode.D))
            {
                AR.SetBool("running", true);
            }

            if (Input.GetKey(KeyCode.A))
            {
                AR.SetBool("running", true);
            }


            if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                AR.SetBool("running", false);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(transform.right * speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                transform.Translate(-transform.right * speed * Time.deltaTime);
            }

            /*
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                AR.enabled = true;
                othercharacter.GetComponent<FollowerScript>().enabled = false;
                othercharacter.GetComponent<Player_Controller>().enabled = true;
                this.GetComponent<FollowerScript>().enabled = true;
                this.GetComponent<Player_Controller>().enabled = false;
                camera_.GetComponent<Camera2DFollow>().target = othercharacter.transform;
            }
        */
    }


	void GorillaMode()
	{
		AR.enabled = false;
		var temp = Resources.Load<Sprite> ("Gorilla_Max");
		GetComponent<SpriteRenderer> ().sprite = temp;
		rb.gravityScale = .75F;
		StartCoroutine ("Powerup_Timer", 10F);
	}

	IEnumerator Powerup_Timer(float time)
	{
		yield return new WaitForSeconds (time);
		AR.enabled = true;
		rb.gravityScale = 2.5F;
	}
}

