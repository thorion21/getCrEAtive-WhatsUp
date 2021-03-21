using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCollision : MonoBehaviour
{
    private BotController2D controller;
    private GameObject entity;

    public void Awake()
    {
        controller = gameObject.GetComponentInParent<BotController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        attackEntity();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            entity = other.gameObject;
        }
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
        
        
    }
}
