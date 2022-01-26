using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daytime : MonoBehaviour
{

    public float minutesInDay = 1.0f;

    float timer;
    float dayPercentage;
    float rotationSpeed;
    float intensityDelta = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        // Rising sun is 0% of day
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        checkTime();
        UpdateLights();

        // Move our directional light
        rotationSpeed = 360.0f / (minutesInDay * 60.0f) * Time.deltaTime;
        transform.RotateAround(transform.position, transform.right, rotationSpeed);

    }

    void UpdateLights() {
        // Intensity decreases after midday
        Light l = GetComponent<Light> ();

        if (isNight()) {
            // start decreasing sunlight while intensity is > 0.0f
            if (l.intensity > 0.0f) {
                l.intensity -= intensityDelta;
            }
        } else {
            if (l.intensity < 1.0f) {
                l.intensity += intensityDelta;
            }
        }
        
        Debug.Log(dayPercentage);
        Debug.Log(l.intensity);

    }

    bool isNight() {
        return dayPercentage > 0.45;
    }

    void checkTime() {
        // call this in the update method
        timer += Time.deltaTime;
        dayPercentage = timer / (minutesInDay * 60.0f);
        
        // Restart after day ends
        if (timer > (minutesInDay * 60.0f)) {
            timer = 0.0f;
        }
    }
}
