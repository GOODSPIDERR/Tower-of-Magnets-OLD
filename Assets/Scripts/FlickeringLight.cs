using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlickeringLight : MonoBehaviour
{
    private Light2D _light2D;
    void Start()
    {
        _light2D = GetComponent<Light2D>();
    }

    
    void Update()
    {
        _light2D.intensity = Random.Range(1f, 2f);
    }
}
