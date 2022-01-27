using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*

*/

public class Daytime : MonoBehaviour
{

    public float minutesInDay = 1.0f;
    float timer;
    float dayPercentage;
    float rotationSpeed;
    float intensityDelta = 0.05f;

    void Start()
    {
        // Amanecer representa 0% del día
        timer = 0.0f;  // para trackear la duración del día
    }

    void Update()
    {
        if (Input.GetKey("space"))
        {
            UpdateTime();  // actualiza el avance del día
            UpdateLights();  // actualizar la intensidad de la luz según se acerca el atardecer o el amanecer

            // Mover la Directional Light en órbita (360 grados)
            rotationSpeed = 360.0f / (minutesInDay * 60.0f) * Time.deltaTime;
            transform.RotateAround(transform.position, transform.right, rotationSpeed);
        }

    }

    void UpdateLights() {
        Light l = GetComponent<Light> ();

        // Atardecer
        if (isNight()) {
            // Reducir intensidad del día hasta que llegue a 0.0
            if (l.intensity > 0.0f) {
                l.intensity -= intensityDelta;
            }
        // Amanecer
        } else {
            // Incrementar intensidad del día hasta regresar a 1.0
            if (l.intensity < 1.0f) {
                l.intensity += intensityDelta;
            }
        }
        

    }

    bool isNight() {
        // Queremos que empiece a anochecer cuando ha tenido 45% de avance el día
        return dayPercentage > 0.45;
    }

    void UpdateTime() {
        // Actualizar el avance porcentual del día
        // de acuerdo al tiempo transcurrido
        timer += Time.deltaTime;
        dayPercentage = timer / (minutesInDay * 60.0f);
        
        // Reiniciar el día cuando llegamos al 100%
        if (timer > (minutesInDay * 60.0f)) {
            timer = 0.0f;
        }
    }
}
