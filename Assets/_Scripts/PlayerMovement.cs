using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Animator animator;
    public Rigidbody2D rb;

    public bool changinsSounds = false; // variable created to alternate sounds in Step()

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // it makes the character moves on the same speed in diagonals
        movement = new Vector2(movement.x, movement.y).normalized;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void Step()
    {
        if (changinsSounds == false)
        {
            //Play footstep 1
            AudioManager.Instance.Play("step1");

            Debug.Log("One");

            changinsSounds = true;
        } else
        {
            //Play footstep 2
            AudioManager.Instance.Play("step2");

            Debug.Log("Two");

            changinsSounds = false;
        }
        
    }

}
