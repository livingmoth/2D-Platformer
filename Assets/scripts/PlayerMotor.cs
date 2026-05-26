using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    private bool canJump = true;
    private Rigidbody2D rigidbody2D;
    public float speed = 5;
    private float jumpForce = 10;
    public float maxSpeed = 10;
    private float stoppingForce = 15;
    public float jumpAmmount = 1;
    public float maxjumps = 1;
    private bool canDash = true;
    public float dashForce = 5;
    public float dashAmmount = 1;
    public float maxDash = 1;
    private bool isDashing = false;
    public float dashtime = 0.5f;
    private Animator animator;
    private float scaleX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        scaleX = transform.localScale.x;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if(direction.x != 0)
        {
            animator.SetBool("isMoving",true);
        }
        else
        {
            animator.SetBool("isMoving",false);
        }

        if(direction.x > 0)
        {
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }

        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-scaleX, transform.localScale.y, transform.localScale.z);
        }

            MovePlayer();
        HandleMaxSpeed();
        PlayerStopping();
    }

    private void MovePlayer()
    {
        rigidbody2D.AddForce(new Vector2(direction.x, 0) * speed);
    }

    private void HandleMaxSpeed()
    {
        if (canDash!)
        {
            return;
        }
        if (rigidbody2D.linearVelocityX >= maxSpeed)
        {
            rigidbody2D.linearVelocityX = maxSpeed;
        }

        else if (rigidbody2D.linearVelocityX <= -maxSpeed)
        {
            rigidbody2D.linearVelocityX = -maxSpeed;
        }
    }

    private void PlayerStopping()
    {
        if (direction.x == 0 && rigidbody2D.linearVelocityX != 0)
        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * stoppingForce, 0));
        }
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    private void OnJump()
    {
        if (canJump)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if (jumpAmmount > 0)
            {
                jumpAmmount--;
            }
            else if (jumpAmmount == 0)
            {
                canJump = false;
            }
        }

    }


    private void OnDash()
    //{
    //    if (canDash)
    //    {
    //        rigidbody2D.AddForce(new Vector2(direction.x, 0) * dashForce, ForceMode2D.Impulse);
    //        Debug.Log(direction.x);
    //        if (direction.x == 0)
    //        {
    //            rigidbody2D.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
    //        }

    //        if (dashAmmount == 1)
    //        {
    //            dashAmmount--;
    //            canDash = false;
    //        }
    //    }


    //}
    { 
        if (isDashing)
        {
            return;
        }
        isDashing = true;
        rigidbody2D.AddForce(new Vector2(direction.x * dashForce,0), ForceMode2D.Impulse);
        StartCoroutine(ResetDash(dashtime));

        if (direction.x == 0)
        {
            rigidbody2D.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
        }

    }

    IEnumerator ResetDash(float timeToRest)
    {
        yield return new WaitForSeconds(timeToRest);
        isDashing = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        jumpAmmount = maxjumps;
        //canDash = true;
        //dashAmmount = maxDash;
    }
}
