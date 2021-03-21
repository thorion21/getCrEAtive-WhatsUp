using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private BotController2D controller;
    private PirateController player;

    public void Awake()
    {
        controller = gameObject.GetComponentInParent<BotController2D>();
        player = GameObject.Find("Player2").GetComponent<PirateController>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (controller.currentState == EnemyState.Dead
            && collision.gameObject.tag == "Player"
            && player.isReincarnated)
        {
            Debug.Log("By my will, you will be ressurected");
        }
    }
}
