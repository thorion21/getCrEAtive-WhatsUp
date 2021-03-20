using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(1.0f, 20.0f)]
    public float bulletSpeed;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = 10.0f;
        StartCoroutine(SelfDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Wall"))
            Destroy(gameObject);
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
