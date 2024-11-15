using UnityEngine;

public class Potion : MonoBehaviour
{
    public int healAmount = 20; // จำนวนพลังชีวิตที่ฟื้นฟู
    public AudioClip potionSound; // เสียงที่จะเล่นเมื่อโดน Potion
    public float volume = 1.0f; // ระดับเสียง

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerState player = collision.GetComponent<playerState>();
            if (player != null)
            {
                player.HealPlayer(healAmount); // ฟื้นฟูพลังชีวิตให้ผู้เล่น

                // ตรวจสอบและเล่นเสียง Potion
                if (potionSound != null)
                {
                    AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                    audioSource.clip = potionSound;
                    audioSource.volume = volume;
                    audioSource.Play();

                    // ทำลาย AudioSource หลังเสียงจบ
                    Destroy(audioSource, potionSound.length);
                }

                Destroy(gameObject); // ลบ Potion ออกจากฉาก
            }
        }
    }
}
