using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonCycle : MonoBehaviour
{

    public float distance = 1000.0f;  // camera clipping far distance should be this value + 100;
    public float scale = 15.0f;
    
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