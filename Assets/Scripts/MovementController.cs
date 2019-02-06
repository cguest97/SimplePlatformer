using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script manages the movement of the player */

[System.Serializable]
public class MovementController : MonoBehaviour
{

    public float speed = 5;
    public float jumpVel = 1;
    public LayerMask playerMask;
    public Animator animator;
    public SpriteRenderer sRenderer;

    public GameControl myController;

    bool grounded = false;
    bool facingRight;

    bool canMove;

    Transform myTrans, tagGround;
    Rigidbody2D myBody;

    private void Start()
    {

        myBody = gameObject.GetComponent<Rigidbody2D>();
        myTrans = this.transform;
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
        myBody.freezeRotation = true;
        facingRight = true;
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);
        float hInput = Input.GetAxisRaw("Horizontal");

        if (grounded)
            animator.SetBool("isJumping", false);

        animator.SetFloat("Speed", Mathf.Abs(hInput));


        /* Flip sprite when moving left/right so running in that direction */
        if (hInput > 0 && !facingRight)
        {
            sRenderer.flipX = false;
            facingRight = true;
        }
        else if (hInput < 0 && facingRight) {
            sRenderer.flipX = true;
            facingRight = false;
        }

        Move(hInput);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void Move(float horizontalInput)
    {

        Vector2 moveVelocity = myBody.velocity;
        moveVelocity.x = horizontalInput * speed;

        myBody.velocity = moveVelocity;
    }

    public void Jump()
    {
        if (grounded)
        {
            myBody.velocity += jumpVel * Vector2.up;
            animator.SetBool("isJumping", true);
            myController.playJumpSound();
        }
    }

    public Transform GetTransform() {
        return transform;
    }

}
