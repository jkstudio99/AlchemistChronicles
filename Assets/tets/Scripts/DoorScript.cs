using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool doorClosed, doorOpen;
    public static GameManager GM;
    public Animator anim;
    public float timeAnim = -1f;
    private float timeCD;

    // Start is called before the first frame update
    void Start()
    {
        doorClosed = false;
        doorOpen = false;
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checking if the keys are collected
        if (GM.keysСollected == true)
        {
            doorOpen = true;
        }
        //At death we clean everything
        if (GM.playerDeath == true)
        {
            doorClosed = false;
            doorOpen = false;
            Destroy(gameObject);
            GM.keysСollected = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        //There will be a check next to the door, have all the keys been collected? If so, the "opening the door" animation is triggered
        if (collider.gameObject.tag == "Player" && doorOpen == true)
        {
            anim.SetBool("DoorOpen", true);
            timeCD -= Time.deltaTime;
            if (timeCD <= timeAnim)
            {
                anim.SetBool("DoorOpen", true);
            }
            GM.enterButton.SetActive(true);
        }
        else
        {
            doorOpen = false;
            GM.enterButton.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && doorOpen == true)
        {
            GM.enterButton.SetActive(false);
        }
    }
}

