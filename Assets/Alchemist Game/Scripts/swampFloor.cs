using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swampFloor : MonoBehaviour
{
    private playerController slFloor;
    public float speedInSlime;
    private float speedPlayer, jumpForcePlayer;

    // Update is called once per frame
    void Start()
    {
        slFloor = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        speedPlayer = slFloor.runSpeed; jumpForcePlayer = slFloor.jumpForce;
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            slFloor.runSpeed = speedInSlime;
            slFloor.jumpForce = 0f;
            slFloor.jump_FX.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            slFloor.runSpeed = speedPlayer;
            slFloor.jumpForce = jumpForcePlayer;
            slFloor.jump_FX.SetActive(true);
        }
    }
}
