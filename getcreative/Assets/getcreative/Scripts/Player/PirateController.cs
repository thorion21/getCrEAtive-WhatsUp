using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateController : MonoBehaviour
{
    [Range(1.0f, 50.0f)]
    public float speed;

    [Range(1.0f, 50.0f)]
    public float jumpForce;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("Jumpboss");
            rb.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector2 movement = new Vector3(horizontal, 0.0f);
        //Debug.Log("MovementVec3 = " + movement);

        //rb.MovePosition(transform.position + movement * Time.deltaTime * speed);

        rb.velocity = movement.normalized * speed + new Vector2(0.0f, rb.velocity.y);


    }   
}
