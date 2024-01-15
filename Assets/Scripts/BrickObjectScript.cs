using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickObjectScript : MonoBehaviour
{
    private int brickHealth = 3;

    string brickHealth2Color = "47A44E";
    string brickHealth1Color = "5ED267";

    string[] brickColors = { "5ED267", "47A44E" };

    float[] rValues = { 17f, 255f, 255f };
    float[] gValues = { 255f, 244f, 48f };
    float[] bValues = { 0f, 0f, 0f };
    float[] aValues = { 255f, 255f, 255f };


    // Start is called before the first frame update
    void Start()
    {
        setBrickHealth(brickHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getBrickHealth() { return brickHealth; }
    public void setBrickHealth(int health) {
        brickHealth = health;

        // Destroy Brick if health is 0
        if(brickHealth == 0)
        {
            FindAnyObjectByType<AudioManager>().playAudio("BrickBreak");
            FindAnyObjectByType<GameManager>().incrementScore(1);
            Destroy(gameObject);
            return;
        }
        FindAnyObjectByType<AudioManager>().playAudio("BrickHit");
        setBrickColor();
    }

    public void setBrickColor()
    {
        // gameObject.GetComponent<SpriteRenderer>().color = brickColors[brickHealth - 1];
        gameObject.GetComponent<SpriteRenderer>().color = new Color(rValues[brickHealth - 1]/256 , gValues[brickHealth - 1]/256, bValues[brickHealth - 1]/256);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Ball") == true)
        {
            if(brickHealth > 0)
            {
                setBrickHealth(brickHealth - 1);
            }
        }
    }
}
