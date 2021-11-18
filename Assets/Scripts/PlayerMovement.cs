using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 i_movement;
    float moveSpeed = 10f;
    public Rigidbody rb;
    bool isJumpPressed;
    public float jumpForce;
    public float WallClimbForce;
    public float Runspeed;

    public bool HaveWallClimb;
    public bool HaveDash;

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
        if (isJumpPressed == true && isGrounded == false)
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

        if(OnWall == false)
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
        Vector2 movement = new Vector2(i_movement.x, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

     void OnMove(InputValue value)
    {
        
        i_movement = value.Get<Vector2>();

        
    }


     void OnMoveUp()
    {

        if (isGrounded)
        {

            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0);
            Debug.Log("jump");
            isJumpPressed = true;



        }

        if (OnWall && HaveWallClimb == true)
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

        if(DashPressed == true && HaveDash == true)
        {

            StartCoroutine(DashDuration());


        }


        if (LeftDashPressed == true && HaveDash == true)
        {

            StartCoroutine(LeftDashDuration());


        }


        if (DashPressed == false)
        {

            StopCoroutine(DashDuration());
            //Physics.IgnoreLayerCollision(3, 6,false);

        }


        if (LeftDashPressed == true)
        {

            StopCoroutine(LeftDashDuration());
            //Physics.IgnoreLayerCollision(3, 6, false);

        }

    }


    IEnumerator DashDuration() 
    {
        Debug.Log("Right Dash");
        yield return new WaitForSeconds(0.1f);
        //Physics.IgnoreLayerCollision(3, 6);
        rb.velocity = new Vector3(12, rb.velocity.y, 0);
        DashPressed = false;
        yield break;

    }


    IEnumerator LeftDashDuration()
    {
        Debug.Log("Left Dash");
        yield return new WaitForSeconds(0.1f);
        //Physics.IgnoreLayerCollision(3, 6);
        rb.velocity = new Vector3(-12, rb.velocity.y, 0);
        LeftDashPressed = false;
        yield break;

    }



}
