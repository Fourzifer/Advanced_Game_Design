using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 i_movement;
    float moveSpeed = 10f;
    public Rigidbody rb;
    private bool isJumpPressed;
    public float jumpForce;

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

    private void Move()
    {
        Vector2 movement = new Vector2(i_movement.x, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    private void OnMove(InputValue value)
    {
        Debug.Log("Moving");
        i_movement = value.Get<Vector2>();
    }


    private void OnMoveUp()
    {

        Debug.Log("Moving up");
        //transform.Translate(transform.up);
        //if (isJumpPressed)
        //{
            // the cube is going to move upwards in 10 units per second
            rb.velocity = new Vector3(0, jumpForce, 0);
            //isMoving = true;
            Debug.Log("jump");
        //}
    }

    private void OnMoveDown()
    {
        Debug.Log("Moving down");
        transform.Translate(-transform.up);
    }
}
