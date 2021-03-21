using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : MonoBehaviour, IStrategy
{
    private BotController2D controller;

    private Rigidbody2D rb;
    private GameObject playerEntity;

    public void Awake()
    {
        controller = gameObject.GetComponentInParent<BotController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.currentState == EnemyState.Idle)
        {

        }
    }

    public void setPlayerAndRigidBody(GameObject playerEntity, Rigidbody2D rb)
    {
        this.playerEntity = playerEntity;
        this.rb = rb;
    }

    public void execute()
    {

    }
}
