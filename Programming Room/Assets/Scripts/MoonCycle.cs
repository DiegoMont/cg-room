using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Apariencia de la Luna */
public class MoonCycle : MonoBehaviour
{

    public float distance = 10000.0f;  // distancia de entre la luna y el origen; debe ser menor al camera clipping
    public float scale = 1.0f;   // tamaño de la Luna
    
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, distance);
        transform.localScale = new Vector3(scale, scale, scale);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
