using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Transform playerTransform;
    private BoxCollider2D _boxCollider;

    
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _boxCollider = GetComponent<BoxCollider2D>();
    }

   
    void Update()
    {
        if (transform.position.y < playerTransform.position.y)
            _boxCollider.enabled = true;
        else
        {
            _boxCollider.enabled = false;
        }
    }
}
