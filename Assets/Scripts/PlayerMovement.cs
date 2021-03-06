using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 i_movement;
    float moveSpeed = 10f; //use 40f if using the rb movement
    public Rigidbody rb;
    bool isJumpPressed;
    public float jumpForce;
    public float WallClimbForce;
    public float Runspeed;

    public bool HaveWallClimb;
    public bool HaveDash;
    public bool HaveJump;

    bool DashPressed;
    bool LeftDashPressed;
    bool MoveLeft;
    bool MoveRight;

    bool isGrounded;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;

    bool OnWall;



    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    Transform LWallCheck;
    [SerializeField]
    Transform RWallCheck;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //if (Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        //{

        //    isGrounded = true;


        //}
        //else
        //{

        //    isGrounded = false;

        //}

        // to not make the player be able to jump in the air
        if (isJumpPressed && HaveJump && !isGrounded)
        {

            isJumpPressed = false;



        }


        if (Physics.Linecast(transform.position, LWallCheck.position, 1 << LayerMask.NameToLayer("Wall")))
        {

            OnWall = true;


        }
        else if (Physics.Linecast(transform.position, RWallCheck.position, 1 << LayerMask.NameToLayer("Wall")))
        {

            OnWall = true;

        }
        else
        {

            OnWall = false;

        }

        if(!OnWall)
        {



            rb.mass = 1;




        }




    }






    //void FixedUpdate()
    //{
    //    if (isJumpPressed)
    //    {
    //        // the cube is going to move upwards in 10 units per second
    //        rb.velocity = new Vector3(0, 10, 0);
    //        //isMoving = true;
    //        Debug.Log("jump");
    //    }
    //}





    void Move()
    {
        //Vector3 movement = new Vector3(i_movement.x, 0, 0) * moveSpeed * Time.deltaTime;
        //rb.MovePosition(rb.position + movement * Time.deltaTime * moveSpeed);
        Vector2 movement = new Vector2(i_movement.x, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    void OnMove(InputValue value)
    {
        
        i_movement = value.Get<Vector2>();

        
    }


     void OnMoveUp()
    {

        if (isGrounded && HaveJump)
        {

            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            Debug.Log("jump");
            isJumpPressed = true;



        }

        if (OnWall && HaveWallClimb)
        {

            rb.mass = 1f;
            rb.velocity = new Vector3(rb.velocity.x, WallClimbForce, 0);
            Debug.Log("Wall Climb");
            isJumpPressed = true;



        }

    }

     void OnMoveDown()
    {
        DashPressed = true;
        Dash();
        Debug.Log("Dashed right");

    }

    void OnLeftDash()
    {
        LeftDashPressed = true;
        Dash();
        Debug.Log("Dashed left");

    }


    void Dash()
    {

        if(DashPressed && HaveDash)
        {

            StartCoroutine(DashDuration());
            StartCoroutine(PassDuration());


        }


        if (LeftDashPressed && HaveDash)
        {

            StartCoroutine(LeftDashDuration());
            StartCoroutine(PassDuration());


        }


        if (!DashPressed)
        {

            StopCoroutine(DashDuration());

        }


        if (LeftDashPressed)
        {

            StopCoroutine(LeftDashDuration());


        }

    }

    IEnumerator PassDuration()
    {
        Debug.Log("Pass through");
        Physics.IgnoreLayerCollision(7, 10);
        Physics.IgnoreLayerCollision(8, 10);
        yield return new WaitForSeconds(0.5f);
        Physics.IgnoreLayerCollision(7, 10, false);
        Physics.IgnoreLayerCollision(8, 10, false);
        yield break;

    }

    IEnumerator DashDuration() 
    {
        Debug.Log("Right Dash");
        yield return new WaitForSeconds(0.1f);
        rb.velocity = new Vector3(12, rb.velocity.y, 0);
        DashPressed = false;
        yield break;

    }


    IEnumerator LeftDashDuration()
    {
        Debug.Log("Left Dash");
        yield return new WaitForSeconds(0.1f);
        rb.velocity = new Vector3(-12, rb.velocity.y, 0);
        LeftDashPressed = false;
        yield break;

    }



}
