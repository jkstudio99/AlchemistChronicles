using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public bool UP_DOWN, LEFT_RIGHT;
    public bool UP, DOWN, LEFT, RIGHT;
    public float speedPlatform;
    playerController playerController;

    private void Start()
    {
       playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
    }
    //Platform movement
    void FixedUpdate()
    {
        if (UP == true)
            transform.Translate(transform.up * speedPlatform * Time.deltaTime);
        if (DOWN == true)
            transform.Translate(transform.up * -speedPlatform * Time.deltaTime);
        if (LEFT == true)
            transform.Translate(transform.right * speedPlatform * Time.deltaTime);
        if (RIGHT == true)
            transform.Translate(transform.right * -speedPlatform * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (UP_DOWN == true)
        {
            if (other.CompareTag("UP_point"))
            {
                DOWN = true;
                UP = false;
            }
            if (other.CompareTag("DOWN_point"))
            {
                UP = true;
                DOWN = false;
            }
        }
        if (LEFT_RIGHT == true)
        {
            if (other.CompareTag("RIGHT_point"))
            {
                RIGHT = true;
                LEFT = false;
            }
            if (other.CompareTag("LEFT_point"))
            {
                RIGHT = false;
                LEFT = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(transform);
            if (LEFT_RIGHT == true || UP_DOWN == true)
                playerController.runSpeed = speedPlatform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
            playerController.runSpeed = 11f;
        }
    }
}
