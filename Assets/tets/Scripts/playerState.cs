using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerState : MonoBehaviour
{
    public bool isDead;
    private GameManager GM;
    public ParticleSystem deathEffect;
    public float deadTimmer, startDeadTimmer;
    public static playerState playState;
    public playerController playerCont;
    public AudioMixerGroup Mixer;
    public AudioSource deadBubble, keyAudio;
    bool isPaused = false;
    public GameObject pausePanel, musicOn, musicOff;
    bool checkMusic;
    public void Start()
    {
        checkMusic = Convert.ToBoolean(PlayerPrefs.GetInt("musicCheck"));
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        isDead = false;
        playerCont.enabled = true;
        playerCont.GetComponent<SpriteRenderer>().enabled = true;

        if (checkMusic == true)
        {
            Mixer.audioMixer.SetFloat("masterMusic", -80);
            musicOff.SetActive(true);
            musicOn.SetActive(false);
        }
        else if (checkMusic == false)
        {
            Mixer.audioMixer.SetFloat("masterMusic", 0);
            musicOn.SetActive(true);
            musicOff.SetActive(false);
        }
    }
    // Update is called once per frame
    public void Update()
    {

        if (isDead == true)
        {
            playerCont.rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            deadTimmer -= Time.deltaTime;
            playerCont.enabled = false;
            playerCont.GetComponent<SpriteRenderer>().enabled = false;
            if (deadTimmer <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                GM.DamagePlayer(1);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trap"))
        {
            isDead = true;
            Instantiate(deathEffect, playerCont.groundCheckL.transform.position, playerCont.groundCheckL.transform.rotation);
        }
        if (isDead == true)
        {
            deadBubble.Play();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Key")
        {
            GM.KeyTaked(1);
            keyAudio.Play();
        }
    }
    public void btnPause()
    {
        if (isPaused)
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    public void settingMusic()
    {
        if (checkMusic == true)
        {
            Mixer.audioMixer.SetFloat("masterMusic", 0);
            checkMusic = false;
            musicOff.SetActive(false);
            musicOn.SetActive(true);
        }
        else if (checkMusic == false)
        {
            Mixer.audioMixer.SetFloat("masterMusic", -80);
            checkMusic = true;
            musicOn.SetActive(false);
            musicOff.SetActive(true);
        }
        PlayerPrefs.SetInt("musicCheck", Convert.ToInt32(checkMusic));
        checkMusic = Convert.ToBoolean(PlayerPrefs.GetInt("musicCheck"));
    }
    public void goMenu()
    {
        GM.GoMenu();
    }
}
