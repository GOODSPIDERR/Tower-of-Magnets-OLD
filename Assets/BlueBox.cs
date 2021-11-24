using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBox : MonoBehaviour
{
    private bool magnetized;
    private Rigidbody2D rb;
    private Vector2 difference;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (magnetized)
        {
            var mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            difference = mousePosition - new Vector2(transform.position.x, transform.position.y);
        }

        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private void FixedUpdate()
    {
        if (magnetized)
        {
            rb.AddForce(difference * 25f);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Blue box clicked.");
        magnetized = true;
        rb.gravityScale = 0f;
    }
    
    private void OnMouseUp()
    {
        Debug.Log("Blue box unclicked.");
        magnetized = false;
        rb.gravityScale = 1f;
    }
}
