using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daytime : MonoBehaviour
{

    public float minutesInDay = 1.0f;

    float timer;
    float dayPercentage;
    float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        checkTime();
        UpdateLights();

        // Move our directional light
        rotationSpeed = 360.0f / (minutesInDay * 6.0f) * Time.deltaTime;
        transform.RotateAround(transform.position, transform.right, rotationSpeed);

        // Debug.Log(dayPercentage);
    }

    void UpdateLights() {
        // Intensity decreases after midday
        Light l = GetComponent<Light> ();
        if (isNight()) {
            if (l.intensity > 0.0f) {
                l.intensity -= 0.05f;
            }
        }
        // Intensity increases after midnight
        else {
            if (l.intensity < 1.0f) {
                l.intensity += 0.05f;
            }
        }
    }

    bool isNight() {
        return dayPercentage > 0.5f;
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
