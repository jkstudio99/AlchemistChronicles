using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelTrap : MonoBehaviour
{
    public Animator anim;
    public Collider2D colliderTrap;
    public float timeLead;
    public bool timer;
    private void Start()
    {
        colliderTrap.GetComponent<Collider2D>().enabled = false;
    }
    private void FixedUpdate()
    {
        if (timer == true)
        {
            timeLead -= Time.deltaTime;
        }
        
       if (timeLead <= 0)
        {
            anim.enabled = true;
            colliderTrap.GetComponent<Collider2D>().enabled = true;
        }
        if (timeLead <= -0.25)
        {
            colliderTrap.GetComponent<Collider2D>().enabled = false;
            timer = false;
        }    
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            timer = true;
        }
    }
}
