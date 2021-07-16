using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    public float damage = 15f;

    AudioSource audioSource;
    public AudioClip hitAudio;

    PlayerHealth playerHealthCom;

    public Image hitImage;

    void Start()
    {
        hitImage.gameObject.SetActive(false);
        playerHealthCom = FindObjectOfType<PlayerHealth>();
        audioSource = GetComponent<AudioSource>();
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        var distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
        if (distanceToTarget <= 4f)
        {
            target.TakeDamage(damage);
            print("Gotcha!!!!!!");
            hitImage.gameObject.SetActive(true);
            Invoke("DeactivateHitImage", .2f);
            if (playerHealthCom.playerHealth < 1)
            {
                return;
            }

            else
            {
                audioSource.PlayOneShot(hitAudio, 10f);
            }
        }
    }

    void DeactivateHitImage()
    {
        hitImage.gameObject.SetActive(false);
    }
}