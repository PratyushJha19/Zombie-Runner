using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip walkAudio;
    public AudioClip jumpAudio;
    AudioSource audioSource;
    [SerializeField] private bool isMoving = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(jumpAudio);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            isMoving = true;
        }

        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            isMoving = true;
        }

        else
        {
            isMoving = false;
        }

        if (isMoving == true)
        {
            if (audioSource.isPlaying == false)
            {
                audioSource.PlayOneShot(walkAudio);
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}
