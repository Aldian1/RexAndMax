using UnityEngine;
using System.Collections;
using UnityStandardAssets.Utility;
using UnityStandardAssets._2D;

public class GorillaController : MonoBehaviour {


    private Animator ar;
    private Rigidbody2D rb;
    public float speed;
    public GameObject player;
    public float jumppower;
    private bool onground;
    private bool onwall;

    // Use this for initialization
    void Start () {
        ar = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        	
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
       
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
            //spriter works off scaling so we are changing from rotations to negative scale.
            transform.localScale = new Vector3(.65F, .65F, 1);


            //transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.localScale = new Vector3(-.65F, .65F, 1);
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }

        if (onground == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log ("jump");
                ar.SetBool("Slide", false);
                onground = false;
                rb.AddForce(Vector2.up * jumppower);
                Debug.DrawRay(transform.position, -Vector2.up * 2.5F, Color.red);
                return;
            }
        }
        if (onground == false)
        {
            Debug.DrawRay(transform.position, -Vector2.up * 2.5F, Color.green);

            //  Debug.Log(Vector2.Distance(hit_.transform.position, transform.position));

        }

        if(onwall == true)
        {
            float currentx = transform.position.x;
            transform.position = new Vector3(currentx, transform.position.y, transform.position.z);
            ar.SetBool("Slide", true);
            ar.SetFloat("Run", h);
            onground = true;

        }
        else
        {
            ar.SetFloat("Run", h);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.transform.tag == "Ground")
        {
            onground = true;
            onwall = false;
            ar.SetBool("Slide", false);
        }

        if (col.transform.tag == "Wall")
        {
            onwall = true;
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



    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(15);
        player.SetActive(true);
        player.transform.position = this.transform.position;
        Camera.main.GetComponent<Camera2DFollow>().target = player.transform;
        player.GetComponent<Player_Controller>().CollisionAgain();
        this.gameObject.SetActive(false);
        

    }
}
