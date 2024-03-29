using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody2D ballRb;

    private float ballSpeedY = 4f;
    private float ballSpeedX = 6f;
    private float xDiff;
    private int yDirection = -1;
    
    Vector2 ballVelocityVector = Vector2.zero;

    float yThreshold = -5f;

    // Start is called before the first frame update
    void Start()
    {
        xDiff = 0f;
        yDirection = -1;

        // Apply initial Velocity
        ballVelocityVector = new Vector2(0, -1f * (ballSpeedY - 2f));
        ballRb.velocity = ballVelocityVector;
    }

    // Update is called once per frame
    void Update()
    {
        // Game Over
        if(transform.position.y < yThreshold)
        {
            FindAnyObjectByType<GameManager>().deadBall();
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        ballVelocityVector.x = xDiff * ballSpeedX;
        ballVelocityVector.y = yDirection * ballSpeedY;
        ballRb.velocity = ballVelocityVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        // If the ball collides with the player
        if(collision.gameObject.tag.Equals("Player") == true)
        {
            Vector2 playerVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            float velocityXComponent = -playerVelocity.x + ballRb.velocity.x;
            if((velocityXComponent >= 0 && velocityXComponent > ballSpeed) || (velocityXComponent < 0 && velocityXComponent < -1 * ballSpeed))
            {
                if(velocityXComponent >= 0) velocityXComponent = ballSpeed;
                else velocityXComponent = -ballSpeed;
            }
            ballRb.velocity = new Vector2(velocityXComponent, ballSpeed);
        }

        if(collision.gameObject.tag.Equals("UpperWall") == true)
        {
            float velocityYComponent = ballRb.velocity.y;
            ballRb.velocity = new Vector2(ballRb.velocity.x, -ballSpeed);
        }

        if(collision.gameObject.tag.Equals("RightWall") == true)
        {
            ballRb.velocity = new Vector2(-ballSpeed, ballRb.velocity.y);
        }

        if (collision.gameObject.tag.Equals("LeftWall") == true)
        {
            ballRb.velocity = new Vector2(ballSpeed, ballRb.velocity.y);
        }

        if(collision.gameObject.tag.Equals("Brick") == true)
        {
            ballRb.velocity = new Vector2(ballRb.velocity.x, -ballSpeed);
        }
        */

        /*
        if(collision.gameObject.tag.Equals("Player"))
        {
            xDiff = transform.position.x - collision.gameObject.transform.position.x;
            ballVelocityVector.x = xDiff * ballSpeedX;
            ballVelocityVector.y = ballSpeedY;
            ballRb.velocity = ballVelocityVector;
        }
        else if(collision.gameObject.tag.Equals("UpperWall"))
        {
            // ballVelocityVector.x = ballRb.velocity.x;
            ballVelocityVector.x = xDiff * ballSpeedX;
            ballVelocityVector.y = -1f * ballSpeedY;
            ballRb.velocity = ballVelocityVector;
        }
        else if(collision.gameObject.tag.Equals("RightWall"))
        {
            // x = xDiff * ballSpeedX * -1f;
            xDiff = -xDiff;
            ballVelocityVector.x = xDiff * ballSpeedX;
            ballVelocityVector.y = ballRb.velocity.y;
            ballRb.velocity = ballVelocityVector;
        }
        else if(collision.gameObject.tag.Equals("LeftWall"))
        {
            xDiff = -xDiff;
            ballVelocityVector.x = xDiff * ballSpeedX;
            ballVelocityVector.y = ballRb.velocity.y;
            ballRb.velocity = ballVelocityVector;
        }
        else if(collision.gameObject.tag.Equals("Brick"))
        {
            ballVelocityVector.x = xDiff * ballSpeedX;
            ballVelocityVector.y = -1f * ballSpeedY;
            ballRb.velocity = ballVelocityVector;
        }
        */

        /*
        // v3
        if (collision.gameObject.tag.Equals("Player"))
        {
            xDiff = transform.position.x - collision.gameObject.transform.position.x;
            yDirection = -yDirection;
        }
        else if(collision.gameObject.tag.Equals("UpperWall"))
        {
            yDirection = -yDirection;
        }
        else if (collision.gameObject.tag.Equals("RightWall"))
        {
            xDiff = -xDiff;
        }
        else if (collision.gameObject.tag.Equals("LeftWall"))
        {
            xDiff = -xDiff;
        }
        // 0.25
        else if (collision.gameObject.tag.Equals("Brick"))
        {
            float xPos = transform.position.x;
            if(xPos >= collision.gameObject.transform.position.x - 0.5f && xPos <= collision.gameObject.transform.position.x + 0.5f)
            {
                yDirection = -yDirection;
            }
            else
            {
                xDiff = -xDiff;
            }
        }
        */

        /*
        // v4 still broken T_T
        if (collision.gameObject.tag.Equals("Player"))
        {
            xDiff = transform.position.x - collision.gameObject.transform.position.x;
            yDirection = 1;
        }
        else if (collision.gameObject.tag.Equals("UpperWall"))
        {
            yDirection = -1;
        }
        else if (collision.gameObject.tag.Equals("RightWall"))
        {
            xDiff = -xDiff;
        }
        else if (collision.gameObject.tag.Equals("LeftWall"))
        {
            xDiff = -xDiff;
        }
        else if(collision.gameObject.tag.Equals("Brick"))
        {
            float xPos = transform.position.x;
            float yPos = transform.position.y;
            if(xPos >= collision.gameObject.transform.position.x + 0.5f + 0.123f)
            {
                if (xDiff <= 0) xDiff = -xDiff;
            }
            else if(xPos <= collision.gameObject.transform.position.y - 0.5f - 0.123f)
            {
                if (xDiff >= 0) xDiff = -xDiff;
            }

            if(yPos < collision.gameObject.transform.position.y - 0.25f - 0.123f)
            {
                if(yDirection == 1) yDirection = -yDirection;
            }
            else if(yPos > collision.gameObject.transform.position.y + 0.25f + 0.123f)
            {
                if(yDirection == -1) yDirection = -yDirection;
            }
        }
        */

        if (collision.gameObject.tag.Equals("Player"))
        {
            xDiff = transform.position.x - collision.gameObject.transform.position.x;
            yDirection = 1;
        }
        else if (collision.gameObject.tag.Equals("UpperWall"))
        {
            yDirection = -1;
        }
        else if (collision.gameObject.tag.Equals("RightWall"))
        {
            xDiff = -xDiff;
        }
        else if (collision.gameObject.tag.Equals("LeftWall"))
        {
            xDiff = -xDiff;
        }
        else if (collision.gameObject.tag.Equals("Brick"))
        {
            float xPos = transform.position.x;
            float yPos = transform.position.y;
            /*
            if (yPos <= collision.gameObject.transform.position.y + 0.25f + 0.122f && yPos >= collision.gameObject.transform.position.y - 0.25f - 0.122f && xPos >= collision.gameObject.transform.position.x + 0.5f + 0.122f && xPos <= collision.gameObject.transform.position.x - 0.5f - 0.122f)
            {
                xDiff = -xDiff;
            }
            else
            {
                yDirection = -yDirection;
            }
            */

            float brickXPos = collision.gameObject.transform.position.x;
            float brickYPos = collision.gameObject.transform.position.y;
            if(yPos >= brickYPos - 0.25f && yPos <= brickYPos + 0.25f)
            {
                xDiff = -xDiff;
            }
            else
            {
                yDirection = -yDirection;
            }

        }
    }
}
