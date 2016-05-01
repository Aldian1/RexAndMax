﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityStandardAssets.Utility;
using UnityStandardAssets._2D;
using Spriter2UnityDX;

public class Player_Controller : MonoBehaviour
{

    public Animator AR;

    public float speed;

    public GameObject othercharacter;

    public Rigidbody2D rb;

    public float Jumpower;

    public GameObject camera_;
    public bool onground;

    private GameObject debugger;
    public GameObject balloon;

    public bool invincible;

    private Color sprite;

    private bool keyboardcontrols;

    public Sprite[] RexAttacks;

    public GameObject gorilla;


    // Use this for initialization
    void Start()
    {

        sprite = GetComponent<EntityRenderer>().Color;
        rb = GetComponent<Rigidbody2D>();
        AR = GetComponent<Animator>();
        Physics2D.IgnoreCollision(othercharacter.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());

        
    }

    // Update is called once per frame
    void Update()
    {


        Controls();
        Animation();

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
        GetComponent<EntityRenderer>().Color = sprite;
        yield return new WaitForSeconds(3);
        sprite.a = 1F;
        GetComponent<EntityRenderer>().Color = sprite;
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
   
		if (!invincible) {
			GameObject.Find ("Health_Max").GetComponent<HealthListener> ().updatehealth (damage);
			if (transform.rotation.y == 180) {
				rb.AddForce (new Vector2 (1, 1) * 600);
			}
			if (transform.rotation.y == 0) {
				rb.AddForce (new Vector2 (-1, 1) * 600);
			}
            
			invincible = true;
			StartCoroutine ("Invincible");
			return;
		}
    }
	#region movement
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



            if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(transform.right * speed * Time.deltaTime);
            //spriter works off scaling so we are changing from rotations to negative scale.
            transform.localScale = new Vector3(.35F,.35F,1);    


                //transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.A))
            {
            //transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.localScale = new Vector3(-.35F, .35F, 1);
            transform.Translate(-transform.right * speed * Time.deltaTime);
            }

          
    }
    public void Animation()
    {

        float run = Input.GetAxis("Horizontal");
        AR.SetFloat("Run", run);

    }
	#endregion

	void GorillaMode()
	{
		
        //	var temp = Resources.Load<Sprite> ("Gorilla_Max");
        //	GetComponent<EntityRenderer>().sprite = temp as Spriute;
        gorilla.SetActive(true);
        gorilla.transform.position = this.transform.position;
        Camera.main.GetComponent<Camera2DFollow>().target = gorilla.transform;
        this.gameObject.SetActive(false);
        othercharacter.SetActive(false);

        rb.gravityScale = 1F;
        gorilla.GetComponent<GorillaController>().StartCoroutine("Timer");
	}

    public void CollisionAgain()
    {
        Physics2D.IgnoreCollision(othercharacter.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
    }

}

//if hannah is great then hannah is fab 
	//yes



