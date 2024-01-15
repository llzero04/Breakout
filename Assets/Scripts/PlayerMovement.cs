using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;

    float playerSpeed = 15f;

    // 0 is stay, 1 is right, -1 is left
    int movementDirection = 0;

    Vector2 movementVelocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        movementDirection = 0;
        movementVelocity = new Vector2(playerSpeed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // moving the player to the left
            movementDirection = -1;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // moving the player to the right
            movementDirection = 1;
        }
    }

    private void FixedUpdate()
    {
        /* if(movementDirection != 0)
        {
            movePlayer();
            movementDirection = 0;
        } */
        movePlayer();
    }

    private void movePlayer()
    {
        playerRb.velocity = movementVelocity * movementDirection;
        movementDirection = 0;
    }
}
