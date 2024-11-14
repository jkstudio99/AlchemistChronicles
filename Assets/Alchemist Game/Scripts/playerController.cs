using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class playerController : MonoBehaviour
{

    Animator animPlayer;
    public Rigidbody2D rb2d;
    public SpriteRenderer spritePlayer;
    public SpriteRenderer spriteRun_FX;
    Collider2D playerCollider2D;
    bool isGrounded;
    public GameObject groundCheckObj;
    public Transform groundCheckL, groundCheckR;
    public Transform runFX;
    public bool run;
    public float runSpeed, jumpForce;
    public float move_x;
    public float TimeFX, StartTimeFX;
    public GameObject run_FX, jump_FX;
    public GameObject OutlineBtnLeft, OutlineBtnRight, OutlineBtnJump; //Outlines buttons

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        animPlayer = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spritePlayer = GetComponent<SpriteRenderer>();
        playerCollider2D = GetComponent<Collider2D>();
        run = false;
    }
    private void Update()
    {
        rb2d.velocity = new Vector2(move_x * runSpeed, rb2d.velocity.y);
        //Check ground 
        if ((Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground"))) ||
                (Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground"))))
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
            jump_FX.SetActive(true);
            animPlayer.Play("Jump");
        }
    }
    void FixedUpdate()
    {
        //Right controll (Keyboard)
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            if (isGrounded)
            {
                animPlayer.Play("Run");
                //Effect run
                if (TimeFX <= 0)
                {
                    Instantiate(run_FX, runFX.transform.position, runFX.transform.rotation);
                    TimeFX = StartTimeFX;
                }
                else
                {
                    TimeFX -= Time.deltaTime;
                }
            }
            spritePlayer.flipX = false; 
            playerCollider2D.offset = new Vector2(0.63f, -0.134f);
            groundCheckObj.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        //Left controll (Keyboard)
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            if (isGrounded)
            {
                animPlayer.Play("Run");
                //Effect run
                if (TimeFX <= 0)
                {
                    Instantiate(run_FX, runFX.transform.position, runFX.transform.rotation);
                    TimeFX = StartTimeFX;
                }
                else
                {
                    TimeFX -= Time.deltaTime;
                }
            }
            spritePlayer.flipX = true; 
            playerCollider2D.offset = new Vector2(-0.55f, -0.134f);
            groundCheckObj.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            if (isGrounded && run == false)
            {
                animPlayer.Play("Idle");
            }
            //Checking running status
            if (isGrounded == true && run == true)
            {
                animPlayer.Play("Run");
                if (TimeFX <= 0)
                {
                    Instantiate(run_FX, runFX.transform.position, runFX.transform.rotation);
                    TimeFX = StartTimeFX;
                }
                else
                {
                    TimeFX -= Time.deltaTime;
                }
            }
        }
        //Jump controll 
        if (Input.GetKey("space") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            Instantiate(jump_FX, runFX.transform.position, runFX.transform.rotation);
            jump_FX.SetActive(false);
        }
    }

    // Button right UI
    public void RightBut(bool BtnRun)
    {
        if (BtnRun == true)
        {
            move_x = 1;
            rb2d.velocity = new Vector2(move_x * runSpeed, rb2d.velocity.y);
            run = true; OutlineBtnRight.SetActive(false);
            if (isGrounded)
            {
                animPlayer.Play("Run");
            }
            spritePlayer.flipX = false;
            playerCollider2D.offset = new Vector2(0.63f, -0.134f);
            groundCheckObj.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (BtnRun == false)
        {
            move_x = 0;
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            run = false; OutlineBtnRight.SetActive(true);
        }
    }

    // Button left UI
    public void LeftBut(bool BtnRun)
    {
        if (BtnRun == true)
        {
            run = true; OutlineBtnLeft.SetActive(false);
            move_x = -1;
            rb2d.velocity = new Vector2(move_x * runSpeed, rb2d.velocity.y);
            if (isGrounded)
            {
                animPlayer.Play("Run");
            }
            spritePlayer.flipX = true; 
            playerCollider2D.offset = new Vector2(-0.55f, -0.134f);
            groundCheckObj.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (BtnRun == false)
        {
            move_x = 0;
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            run = false; OutlineBtnLeft.SetActive(true);
        }
    }
    //Button Jump UI
    public void JumpBtn(bool BtnJump)
    {
        if (BtnJump == true && isGrounded == true)
        {
            Instantiate(jump_FX, runFX.transform.position, runFX.transform.rotation);
            animPlayer.Play("Jump");
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            OutlineBtnJump.SetActive(false);
        }
        else if (BtnJump == false)
        {
            OutlineBtnJump.SetActive(true);
        }
    }
}