using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderMove : MonoBehaviour
{
    private Tracker tracker;
    private Rigidbody2D rb;
    private float speed = 8.0f;

    void Start()
    {
        tracker = GameObject.Find("PlayerTracker").GetComponent<Tracker>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (tracker.getCurrentState() == State.Demolish)
        {
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 movement = new Vector3(0.0f, vertical, 0f);

            transform.position += movement * Time.deltaTime * speed;
        }
        
    }
}
