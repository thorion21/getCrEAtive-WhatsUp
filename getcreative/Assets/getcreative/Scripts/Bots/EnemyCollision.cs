using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private BotController2D controller;

    public void Awake()
    {
        controller = gameObject.GetComponentInParent<BotController2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hole"))
        {
            controller.updateStateEnter(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Hole"))
        {
            controller.updateStateExit(other);
        }
    }
}
