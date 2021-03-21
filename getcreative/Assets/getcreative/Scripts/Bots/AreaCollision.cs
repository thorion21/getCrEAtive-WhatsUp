using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCollision : MonoBehaviour
{
    private BotController2D controller;
    private GameObject entity;

    public Animator animator;
    private bool canHit = true;

    public void Awake()
    {
        controller = gameObject.GetComponentInParent<BotController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.currentState != EnemyState.Dead)
            attackEntity();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            entity = other.gameObject;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            entity = null;
        }
    }

    public void attackEntity()
    {
        if (entity == null)
            return;

        if (canHit)
            StartCoroutine("Hit");
    }

    public void Kill()
    {
        if (entity)
            entity.gameObject.GetComponent<PirateController>().InflictDamage(20);
    }

    IEnumerator Hit()
    {
        canHit = false;
        animator.SetTrigger("isAttacking");
        yield return new WaitForSeconds(0.5f);
        canHit = true;
    }
}
