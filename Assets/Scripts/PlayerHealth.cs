using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip deathAudio;

    public float playerHealth = 100;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damage)
    {
        playerHealth = playerHealth - damage;
        if (playerHealth <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
            print("Player Dead");
            audioSource.PlayOneShot(deathAudio, 11f);
        }
    }
}