using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraTracker : MonoBehaviour
{
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        if (playerTransform.position.y >= 11f)
        {
            transform.DOMoveY(21.5f, 0.25f);
        }
        else
        {
            transform.DOMoveY(0.5f, 0.25f);
        }
    }
}
