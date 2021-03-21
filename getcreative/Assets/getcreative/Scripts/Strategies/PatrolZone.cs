using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolZone : MonoBehaviour
{
    private BotController2D controller;

    private Rigidbody2D rb;
    private GameObject playerEntity;

    public Vector2 startPosition, endPosition;
    float duration;
    float startTime;

    public void Awake()
    {
        controller = gameObject.GetComponentInParent<BotController2D>();
    }

    public void Start()
    {
        this.duration = (endPosition - startPosition).magnitude / controller.speed;
        this.startTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (controller.currentState == EnemyState.Patrol)
        {
            float p = Mathf.InverseLerp(0, duration, Mathf.PingPong(Time.time - startTime, duration));
            Vector3 movement = transform.TransformPoint(Vector2.Lerp(startPosition, endPosition, p));
            rb.velocity = new Vector3(Mathf.Clamp(movement.x - transform.position.x, -1, 1), 0.0f) * controller.speed;
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
