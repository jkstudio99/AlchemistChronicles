using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    public int healAmount = 20; // Amount of health this object provides
    public AudioClip healSound; // Sound effect for healing
    public ParticleSystem healEffect; // Visual effect for healing

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collides with the healing object
        if (collision.CompareTag("Player"))
        {
            playerState player = collision.GetComponent<playerState>();

            if (player != null && !player.isDead)
            {
                // Heal the player
                player.HealPlayer(healAmount);

                // Play sound effect if assigned
                if (healSound != null)
                {
                    AudioSource.PlayClipAtPoint(healSound, transform.position);
                }

                // Play particle effect if assigned
                if (healEffect != null)
                {
                    Instantiate(healEffect, collision.transform.position, Quaternion.identity);
                }

                // Destroy the healing object after interaction
                Destroy(gameObject);
            }
        }
    }
}
