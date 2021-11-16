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

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Move();
    }

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
        
        if (isGrounded)
        {
            rb.velocity = new Vector3(0, jumpForce, 0);
            Debug.Log("jump");
        }
    }

    private void OnMoveDown()
    {
        Debug.Log("Moving down");
        transform.Translate(-transform.up);
    }
}
