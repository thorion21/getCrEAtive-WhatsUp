using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Idle,
    Hunt,
    Patrol
}

public enum Direction
{
    Left, Right
}

public class BotController2D : MonoBehaviour
{
    [Range(1.0f, 50.0f)]
    public float speed;

    bool canFire = true;
    public EnemyState currentState;
    public Direction previousDirection;

    [SerializeField]
    private int health;

    private StageContext context;

    public Rigidbody2D rb;
    private GameObject playerEntity;
    public GameObject huntObj, idleObj, patrolObj;

    private HuntPlayer huntPlayerStrategy;
    private EnemyIdle enemyIdleStrategy;
    private PatrolZone patrolZoneStrategy;

    void Awake()
    {
        context = new StageContext();
        speed = 2.0f;

        playerEntity = GameObject.FindGameObjectsWithTag("Player")[0];
        
        huntPlayerStrategy = huntObj.GetComponent<HuntPlayer>();
        enemyIdleStrategy = idleObj.GetComponent<EnemyIdle>();
        patrolZoneStrategy = patrolObj.GetComponent<PatrolZone>();
        huntPlayerStrategy.setPlayerAndRigidBody(playerEntity, rb);
        enemyIdleStrategy.setPlayerAndRigidBody(playerEntity, rb);
        patrolZoneStrategy.setPlayerAndRigidBody(playerEntity, rb);

        currentState = EnemyState.Patrol;
        context.setStrategy(enemyIdleStrategy);
        context.executeStrategy();
    }

    void Start()
    {
        speed = 2.0f;
        health = 100;
        previousDirection = Direction.Right;
    }

    public void updateStateEnter(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                currentState = EnemyState.Hunt;
                break;
            case "Hole":
                currentState = EnemyState.Patrol;
                break;
        }
    }

    public void updateStateExit(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                currentState = EnemyState.Patrol;
                break;
            case "Hole":
                currentState = EnemyState.Patrol;
                break;
        }
    }

    public void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}
