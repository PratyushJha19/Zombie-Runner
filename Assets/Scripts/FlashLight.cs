using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public float lightDecay = .1f;
    public float angleDeacay = 1f;
    public float minimumAngleDecay = 50f;

    Light myLight;

    private void Start()
    {
        myLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseIntensityAndSpotAngle();
    }

    private void DecreaseIntensityAndSpotAngle()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
        myLight.spotAngle -= angleDeacay * Time.deltaTime;
        myLight.spotAngle = Mathf.Clamp(myLight.spotAngle, minimumAngleDecay, 80f);
    }

    public void RestoreBattery()
    {
        myLight.intensity = 2f;
        myLight.spotAngle = 80f;
    }
}
