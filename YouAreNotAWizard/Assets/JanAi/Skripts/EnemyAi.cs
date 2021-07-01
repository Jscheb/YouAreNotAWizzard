using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;


public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public int damage;

    PlayerScript PlayerScript;


    public bool isDead = false;

    public bool enemyDead;
    public Enemy enemy;

    //Patrolling
    public Vector3 spawnPoint;
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attack
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    //public GameObject projectile;


    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        enemy = gameObject.GetComponent<Enemy>();

        spawnPoint = transform.position;
        GameObject Enemyplayer = GameObject.Find("Player");


        PlayerScript = Enemyplayer.GetComponent<PlayerScript>();


        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (enemy.GetEnemyIsDead() != true)
        {
            if (!playerInSightRange && !playerInAttackRange) Patrolling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInSightRange && playerInAttackRange) AttackPlayer();
        }

    }

    IEnumerator AttackAmimation()
    {
        yield return new WaitForSecondsRealtime(1);
        yield return null;
        Attack();

    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }


    private void SearchWalkPoint()
    {
        float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(spawnPoint.x + randomX, transform.position.y, spawnPoint.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;


    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        Vector3 lookAtTarget = new Vector3(player.position.x, transform.position.y, player.position.z);
        //transform.LookAt(player);
        transform.LookAt(lookAtTarget);


        if (!alreadyAttacked)
        {
            StartCoroutine(AttackAmimation());


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        } 
       

        

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }


    public void Attack()
    {
        int playerLife = PlayerScript.GetLife();
        if (playerLife > 0)
        {
            PlayerScript.TakeDamage(damage);
        } else
        {
            isDead = true;
            
        }
    }

}