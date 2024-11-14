using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class birdFollow : MonoBehaviour
{
    public float speedBird, stopDistance;
    private Transform target;
    playerController playerController;
    public SpriteRenderer spriteBird;
    SpriteRenderer sprPlayer;
    float moveX;

    void Start()
    {
        //Writing data of the object with the tag "Player", To find out what is spriteRun_FX
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        speedBird = playerController.runSpeed;
        //Distance check
        if (Vector2.Distance(transform.position, target.position) > stopDistance)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speedBird * Time.deltaTime);
        //Directing the bird in the same direction as the player
        sprPlayer = playerController.spritePlayer;
        if (sprPlayer.flipX == true)
            spriteBird.flipX = true;
        else if (sprPlayer.flipX == false)
            spriteBird.flipX = false;
    }
}