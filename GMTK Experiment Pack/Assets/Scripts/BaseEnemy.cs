using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseEnemy : MonoBehaviour
{
    private Transform playerLocation;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 fakeMovement;

    private float moveSpeed = 2.5f;
    private float idleSpeed = 2.5f;

    private float chaseRadius;
    public float attackRadius;
    public bool shouldRotate;
    public LayerMask whatIsPlayer;

    private bool isInChaseRange;
    private bool isInAttackRange;

    private float time; 

    public EnemySO enemySO;

    private GameObject[] fakeTargets;
    private GameObject oneFakeTarget;

    public static event Action OnEnemyAttck; 
   
    // Start is called before the first frame update
    void Start()
    {
        fakeTargets = GameObject.FindGameObjectsWithTag("FakeTarget");
        oneFakeTarget = fakeTargets[UnityEngine.Random.Range(0, fakeTargets.Length)];


        time = 0; 
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform; 
        rb = GetComponent<Rigidbody2D>();

        //enemy SO stats 
        moveSpeed = enemySO.chaseSpeed;
        idleSpeed = enemySO.idleSpeed;
        chaseRadius = enemySO.chaseRadius;  

    }

    // Update is called once per frame
    void Update()
    {
        isInChaseRange = Physics2D.OverlapCircle(transform.position, chaseRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        //Vector3 direction = playerLocation.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        //direction.Normalize();
        //movement = direction;
        CalculateDirection(oneFakeTarget.gameObject.transform.position, false);
        CalculateDirection(playerLocation.position, true);
    }

    void CalculateDirection(Vector3 pos, bool isPlayer)
    {
        Vector3 direction = pos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        if(isPlayer)
        movement = direction;
        else
            fakeMovement = direction;
    }


    private void FixedUpdate()
    {
        time += Time.deltaTime; 

        if(isInChaseRange && !isInAttackRange)
              MoveCharacter(movement);

        if (isInAttackRange)
        {
            rb.velocity = Vector2.zero;
            if(time > ((1/enemySO.attackSpeed) * 5))
            {
                Debug.Log("Attack");
                OnEnemyAttck?.Invoke();
                FindObjectOfType<BaseHealth>().TakeDamage(15);
                FindObjectOfType<BaseHealth>().GetEnemyPositionAndSendToUI(transform.position);
                time = 0;
            }
           
        }

        if (!isInChaseRange && !isInAttackRange)
        {
          
            MoveCharacterSlow(fakeMovement);
            time = 0;
        }
           
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (moveSpeed * Time.deltaTime * direction));
    }

    void MoveCharacterSlow(Vector2 direction)
    {     
        rb.MovePosition((Vector2)transform.position + ((idleSpeed) * Time.deltaTime * direction));
    }
}
