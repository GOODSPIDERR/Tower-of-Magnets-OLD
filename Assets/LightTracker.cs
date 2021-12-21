using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightTracker : MonoBehaviour
{
    public bool on;
    public BlueBox blueBox;
    public Light2D light;
    void Start()
    {
        light = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        on = blueBox.on;

        if (on)
        {
            light.enabled = true;
        }
        else
        {
            light.enabled = false;
        }
    }
}
