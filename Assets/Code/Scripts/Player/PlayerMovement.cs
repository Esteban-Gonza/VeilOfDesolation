using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float speed;
    // bool for flipping the object given its facing direction
    private bool faceRight = true;
    public float jumpSpeed;
    [SerializeField] private Transform feetPosition;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private LayerMask groundLayer;


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        FlipSides(); // flip orientation

        //jump mechanic
        if ((verticalInput > 0f) && IsGrounded())
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpSpeed);
        }

    }
    private void FixedUpdate()
    {
        playerRb.velocity = new Vector2(horizontalInput* speed, playerRb.velocity.y);
    }

    private bool IsGrounded()
    {
        // checks if the feet position is in a radious of 0.2 from the ground level
        bool isGrounded = Physics2D.OverlapCircle(feetPosition.position, 0.2f, groundLayer);
        return isGrounded;
    }

    private void FlipSides()
    {
        if (faceRight && (horizontalInput < 0f) || !faceRight && (horizontalInput > 0f) )
        {
            Vector2 newLocalScale = transform.localScale;
            // we flip sides
            faceRight = !faceRight;
            newLocalScale.x *= -1f; 
            transform.localScale = newLocalScale;
        }
    }
}
