using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 i_movement;
    float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movement = new Vector2(i_movement.x, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void OnMove(InputValue value)
    {
        Debug.Log("Moving");
        i_movement = value.Get<Vector2>();
    }

    private void OnMoveUp()
    {
        Debug.Log("Moving up");
        transform.Translate(transform.up);
    }

    private void OnMoveDown()
    {
        Debug.Log("Moving down");
        transform.Translate(-transform.up);
    }
}
