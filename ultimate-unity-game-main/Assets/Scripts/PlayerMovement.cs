using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    // This is for the animation.
    public string parameter = "Idle";
    public float x = 1;
    public float y = 1;


    //private string direction;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        rb.velocity = movement.normalized * moveSpeed;
        
        // This is terrible code, you can do ahead and find a better solution if you feel the need.
        if (horizontal > 0)
        {
            ToggleXDirection(1);
        }
        else
        {
            ToggleXDirection(-1);
        }
        if (vertical > 0)
        {
            ToggleYDirection(1);
        }
        else
        {
            ToggleYDirection(-1);
        }

        if (rb.velocity.x != 0) {
            TurnOffCurrentParameter();
            ToggleAnimation("Walk");
        }
        else if (rb.velocity.y != 0) {
            TurnOffCurrentParameter();
            ToggleAnimation("Walk");
        }
        else
        {
            TurnOffCurrentParameter();
            ToggleAnimation("Idle");
        }
    }
    
    // The current animation like "Walk", "Idle", etc.
    public void TurnOffCurrentParameter()
    {
        animator.SetBool(parameter, false);
    }
    
    // Change the animation.
    public void ToggleAnimation(string nextParameter)
    {
        animator.SetBool(nextParameter, true);
        parameter = nextParameter;
    }

    // Flips x direction
    public void ToggleXDirection(float x)
    {
        animator.SetFloat("X", x);
    }
    // Flips y direction.
    public void ToggleYDirection(float y)
    {
        animator.SetFloat("Y", y);
    }
}
