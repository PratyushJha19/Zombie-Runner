using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchScript : MonoBehaviour
{
    CapsuleCollider colliderHeight;
    float originalHeight;
    public float crouchHeight;

    void Start()
    {
        colliderHeight = GetComponent<CapsuleCollider>();
        originalHeight = colliderHeight.height;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        { 
            Crouch();
        }
        else 
        {
            GoUp(); 
        }
    }
    void Crouch()
    {
        colliderHeight.height = crouchHeight;
    }
    void GoUp()
    {
        colliderHeight.height = originalHeight;
    }
}