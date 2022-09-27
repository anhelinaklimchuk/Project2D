using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float jumpHeight = 5.0f;

    Vector2 movementVector;

    Rigidbody2D rbody ;
    CircleCollider2D circleCollider;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerVelocity = new Vector2(movementVector.x * movementSpeed, rbody.velocity.y);
        rbody.velocity = playerVelocity;

    }

    //Input System
    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            if (!circleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                return;
            }
            if (Input.GetButtonDown("Jump"))
            {
                rbody.velocity += new Vector2(0f, jumpHeight);
            }
        }
    }
    private void OnMove(InputValue value)
    {
        movementVector = value.Get<Vector2>();
        Debug.Log(movementVector);
    }
}
