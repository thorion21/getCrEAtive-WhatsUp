using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntPlayer : MonoBehaviour, IStrategy
{
    private BotController2D controller;

    private Rigidbody2D rb;
    private GameObject playerEntity;

    public void Awake()
    {
        controller = gameObject.GetComponentInParent<BotController2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (controller.currentState == EnemyState.Hunt)
        {
            float horizontal = (playerEntity.transform.position.x - rb.transform.position.x) < 0 ? -1.0f : 1.0f;
            bool goingRight = horizontal > 0;
            bool goingLeft = horizontal < 0;

            Vector2 movement = new Vector3(horizontal, 0.0f);

            rb.velocity = movement.normalized * controller.speed + new Vector2(0.0f, rb.velocity.y);

            if (goingRight && controller.previousDirection != Direction.Right)
            {
                controller.Flip();
                controller.previousDirection = Direction.Right;
            }

            if (goingLeft && controller.previousDirection != Direction.Left)
            {
                controller.Flip();
                controller.previousDirection = Direction.Left;
            }
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
