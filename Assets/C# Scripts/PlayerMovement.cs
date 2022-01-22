using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Initializing variables
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D box;
    private SpriteRenderer spr;
    private float dirX = 0;
    [SerializeField] private float speed = 7;
    [SerializeField] private float jump = 10;
    [SerializeField] private LayerMask jumpableGround;

    // Start is called before the first frame update
    void Start()
    {

        //Creating instances
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        spr = GetComponent<SpriteRenderer>();

        Debug.Log("Hubert has gotten me so hard that im now spider-man");
    }

    // Update is called once per frame
    void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && grounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }

        UpdateAnimation();

    }

    private void UpdateAnimation()
    {
        if (dirX > 0)
        {
            anim.SetBool("Running", true);
            spr.flipX = false;
        }

        else if (dirX < 0)
        {
            anim.SetBool("Running", true);
            spr.flipX = true;
        }

        else
        {
            anim.SetBool("Running", false);
        }

        if (rb.velocity.y > .1f)
        {
            anim.SetBool("Jump", true);
        }

        else if (rb.velocity.y < -.1f)
        {
            anim.SetBool("Fall", true);
        }

        else
        {
            anim.SetBool("Fall", false);
            anim.SetBool("Jump", false);
        }

    }


    private bool grounded()
    {

        return Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0, Vector2.down, .1f, jumpableGround);

    }


}
