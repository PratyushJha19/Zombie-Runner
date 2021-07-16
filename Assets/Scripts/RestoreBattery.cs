using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreBattery : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            FindObjectOfType<FlashLight>().RestoreBattery();
        }
    }
}
