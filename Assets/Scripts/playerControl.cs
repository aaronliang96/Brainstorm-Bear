using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

    public KeyCode fwd;
    public KeyCode bwd;
    public KeyCode run;
    public KeyCode jump;

    float nrmlSpeed = 10;
    float runSpeed = 15;

    bool isGrounded = true;

    private Rigidbody2D rb2d;
    private Collider2D groundCheck;

    Animator anim;

    

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
		
	}

    



    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKey(fwd))
        {
            rb2d.velocity = new Vector2(nrmlSpeed, 0);
        }
        else if (Input.GetKey(bwd))
        {
            rb2d.velocity = new Vector2(-nrmlSpeed, 0);
        }
        else if (Input.GetKey(jump))
        {
            if (isGrounded)
            {

                rb2d.velocity = new Vector2(0, 60);
                new WaitForSeconds(1);



            }
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);
            anim.SetInteger("state", 0);
        }

        if (Input.GetKeyDown(fwd) || Input.GetKeyDown(bwd))
        {
            anim.SetInteger("state", 1);
        }
        if (Input.GetKeyDown(jump) )
        {
            anim.SetInteger("state", 2);
             
        }



    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("yo");

            isGrounded = true;
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("ya");
            isGrounded = false;

    }


}
