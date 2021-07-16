using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Camera FPCamera;
    public float range = 100f;
    public float damage = 1f;
    public GameObject crosshair;
    public ParticleSystem muzzleFlash;
    public GameObject hitEffect;
    public GameObject shootHole;
    public Ammo ammoSlot;
    public AmmoType ammoType;
    public float timeBetweenShots = 2f;
    public bool canShoot = true;

    public AudioClip shootAudio;
    AudioSource audioSource;

    public TextMeshProUGUI ammoText;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        DisplayAmmo();

        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }

        BringCrosshair();
    }

    private void DisplayAmmo()
    {
        int displayedAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = displayedAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            ProcessRaycast();
            PlayMuzzleFlash();
            ammoSlot.ReduceCurrentAmmo(ammoType);
            PlayShootAudio();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayShootAudio()
    {
        audioSource.PlayOneShot(shootAudio);
    }

    public void ProcessRaycast()
    {
        RaycastHit hit; //'RaycastHit' is a variable type which is used to store information about what we hit with our ray.
                        // Variables of type 'RaycastHit' represents the game object which we hit with our raycast
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            ammoSlot.GetCurrentAmmo(ammoType);
            CreateHitImpact(hit);
            // If bullet does not hits Enemy
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)
            {
                return;
            }
            target.TakeDamage(damage);
        }
        else { return; }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        //var impactHole = Instantiate(shootHole, hit.point, Quaternion.LookRotation(hit.normal));
        //Destroy(impactHole, 3f);

        var impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        //Can also use - 'Quaternion.identity', in place of 'Quaternion.LookRotation(hit.normal)'
        Destroy(impact, 0.1f);
    }
    void BringCrosshair()
    {
        if (Input.GetKey(KeyCode.Mouse1))//Down
        {
            crosshair.SetActive(true);
        }
        else { crosshair.SetActive(false); }
        //if (Input.GetKeyUp(KeyCode.Mouse1))
        //{
        //    crosshair.SetActive(false);
        //}
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
}