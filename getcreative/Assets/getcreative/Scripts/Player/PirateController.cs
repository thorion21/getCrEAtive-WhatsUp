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

    bool canFire = false;
    Direction previousDirection;

    [SerializeField]
    private int health;
    public Animator animator;
    public GameObject violin;
    public Tracker tracker;

    private bool isDead = false;
    public bool isReincarnated = false;

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
        tracker = GameObject.Find("PlayerTracker").GetComponent<Tracker>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isDead)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetMouseButton(0) && canFire && !isDead)
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
        if (isDead)
            return;

        if (tracker.getCurrentState() != State.Demolish)
        {
            ManualMovement();
        }
        else
        {
            AutoMovement();
        }
    }

    void ManualMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector3(horizontal, 0.0f);

        rb.velocity = movement.normalized * speed + new Vector2(0.0f, rb.velocity.y);

        bool goingRight = horizontal > 0;
        bool goingLeft = horizontal < 0;

        animator.SetFloat("jumping", rb.velocity.y);
        animator.SetBool("isMoving", goingLeft || goingRight);

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

    void AutoMovement()
    {
        Vector2 movement = new Vector3(1.0f, 0.0f);

        rb.velocity = movement.normalized * speed + new Vector2(0.0f, rb.velocity.y);
        animator.SetBool("isMoving", true);
    }

    public void InflictDamage(int amount)
    {
        health = Mathf.Clamp(health - amount, 0, 100);
        if (health == 0)
        {
            Debug.Log("Hello from inflict:)");
            if (isReincarnated)
            {
                // Game over
                //Destroy(gameObject);
            }
            // Start Reanimate if in reanimate zone
            animator.SetBool("isDead", true);
            Debug.Log("S-a terminat inflict");
            isDead = true;
            StartCoroutine("Reincarnate");
        }
    }

    IEnumerator Reincarnate()
    {
        Debug.Log("You have 1 more chance!");
        yield return new WaitForSeconds(0.1f);

        animator.SetBool("isReincarnated", true);
        animator.SetBool("isDead", false);
        isReincarnated = true;
        health = 100;
        isDead = false;
        Debug.Log("Finish of reincarnate");
    }

    public void Heal(int amount)
    {
        health = Mathf.Clamp(health + amount, 0, 100);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            canFire = true;
            Debug.Log("Picked up item");
            violin.SetActive(true);
            Destroy(collision.gameObject);
        }
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
