using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateController : MonoBehaviour
{
    [Range(1.0f, 50.0f)]
    public float speed = 3.0f;

    [Range(1.0f, 50.0f)]
    public float jumpForce = 1.0f;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    public GameObject weaponPoint;
    public GameObject bulletPrefab;

    bool canFire = true;
    Direction previousDirection;

    [SerializeField]
    private int health;

    enum Direction
    {
        Left, Right
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5.5f;
        jumpForce = 4.5f;
        health = 100;
        previousDirection = Direction.Right;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //Debug.Log("Jumpboss");
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetMouseButtonDown(0) && canFire)
        {
            StartCoroutine("Fire");
        }
    }

    void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    IEnumerator Fire()
    {
        canFire = false;
        GameObject firedBullet = Instantiate(bulletPrefab, weaponPoint.transform.position, weaponPoint.transform.rotation) as GameObject;
        yield return new WaitForSeconds(0.5f);
        canFire = true;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector3(horizontal, 0.0f);

        rb.velocity = movement.normalized * speed + new Vector2(0.0f, rb.velocity.y);

        bool goingRight = horizontal > 0;
        bool goingLeft = horizontal < 0;

        if (goingRight && previousDirection != Direction.Right)
        {
            Flip();
            previousDirection = Direction.Right;
        }

        if (goingLeft && previousDirection != Direction.Left)
        {
            Flip();
            previousDirection = Direction.Left;
        }
    }

    public void InflictDamage(int amount)
    {
        health = Mathf.Clamp(health - amount, 0, 100);
        if (health == 0)
        {
            // Start Reanimate if in reanimate zone
        }
        // if no reanimation found => game over
    }

    public void Heal(int amount)
    {
        health = Mathf.Clamp(health + amount, 0, 100);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }
}
