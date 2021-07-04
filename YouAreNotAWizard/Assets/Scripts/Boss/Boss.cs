using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.VFX;

public class Boss : Enemy
{
    public bool startTheFightAkaBob = false;
    public int damage;
    PlayerScript PlayerScript;
    public bool isDead = false;
    public bool enemyDead;
    public Enemy enemy;
    public Vector3 spawnPoint;
    public float startTimer = 5f;

    //animator
    private Animator animator;
    private int dieAC;
    private int attackAC;
    private int idleAC;
    private int runAC;

    //UI
    public Slider healthBar;
    public Image HaraldPic;
    public GameObject UI;

    //NavMesh
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //Attack
    public float timeBetweenAttacks;
    public bool alreadyAttacked = false;
    public float attackAnimationTimer;
    
    //freeze
    public float freezeTimer;
    public bool freezeAfterAttack = false;

    //States
    public float attackRange;
    public bool  playerInAttackRange;

    //AC
    public bool die = false;
    public bool idle = false;
    public bool run = false;
    public bool attack = false;


    private void Awake()
    {
        spawnPoint = transform.position;
        GameObject Enemyplayer = GameObject.Find("Player");
        PlayerScript = Enemyplayer.GetComponent<PlayerScript>();
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        AnimatorStart();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HealthBarCheck();
        PlayerInAttackRangeCheck();
        AcStateCheck();
        if (startTheFightAkaBob)
        {
            Invoke(nameof(ResetAttack), startTimer);
            if (!enemyIsDead)
            {
                startTimer = 0f;
                FacePlayer();
                //if (!idle && !attack) 
                ChasePlayer();
               if (playerInAttackRange)
                    AttackPlayer();
            }
        }
        ResetAcStates();
    }

 
    private void AnimatorStart()
    {
        animator = GetComponent<Animator>();
        dieAC = Animator.StringToHash("Die");
        attackAC = Animator.StringToHash("Attack");
        idleAC = Animator.StringToHash("Idle");
        runAC = Animator.StringToHash("Run");
    }

    private void AcStateCheck()
    {
        if (enemyIsDead) SetDie(true);
       // if ( ) SetAttack();
        if (freezeAfterAttack | !startTheFightAkaBob) SetIdle(true);
        //if ( ) SetRun();
    }

    private void ResetAcStates()
    {
        die = false;
        attack = false;
        idle = false;
        run = false;
    }
    private void HealthBarCheck()
    {
        healthBar.value = health;
        if (health <= 0)
        {
            deleteHB();
        }
    }
    private void PlayerInAttackRangeCheck()
    {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
    }
    private void SetDie(bool x)
    {
        die = x;
        if (die)
        {
            animator.SetBool(dieAC, die);
            Debug.Log("die true");
        }
    }

    private void SetAttack(bool x)
    {
        attack = x;
        if (attack)
        {
            animator.SetBool(attackAC, attack);
            Debug.Log("attack true");
        }
    }

    private void SetIdle(bool x)
    {
        idle = x;
        if (idle)
        {
            animator.SetBool(idleAC, idle);
            Debug.Log("idle true");
        }
    }


    private void SetRun(bool x)
    {
        run = x;
        if (run)
        {
            animator.SetBool(runAC, run);

            Debug.Log("run true");
        }
    }

    IEnumerator AttackAnimation()
    {
        yield return new WaitForSecondsRealtime(attackAnimationTimer);
        yield return null;
        Attack();

    }


    
    private void ChasePlayer()
    {
        ResetAcStates();
        SetRun(true);
        agent.SetDestination(player.position);

    }
    private void FacePlayer()
    {
        agent.SetDestination(transform.position);
        Vector3 lookAtTarget = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(lookAtTarget);
    }


    private void AttackPlayer()
    {
        
        FacePlayer();

        if (!alreadyAttacked)
        {
            
            ResetAcStates();
            SetAttack(true);

            //StartCoroutine(AttackAnimation());
            Attack();

            freezeAfterAttack = true;
            alreadyAttacked = true;
            SetAttack(false);
            SetIdle(true);
            StartCoroutine(ResetFreeze());
            StartCoroutine(ResetAttack());
            //Invoke(nameof(ResetAttack), timeBetweenAttacks);
            //Invoke(nameof(ResetFreeze), freezeTimer);
            

        }




    }

    IEnumerator ResetFreeze()
    {
        yield return new WaitForSecondsRealtime(freezeTimer);
        yield return null;
        freezeAfterAttack = false;
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSecondsRealtime(timeBetweenAttacks);
        yield return null;
        alreadyAttacked = false;
    }
   /* private void ResetFreeze()
    {
        freezeAfterAttack = false;
        
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
   */
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


    public void Attack()
    {
        int playerLife = PlayerScript.GetLife();
        if (playerLife > 0)
        {
            //Chris hier attacklogic pls
            PlayerScript.TakeDamage(damage);
            Debug.Log(playerLife);
        }
        else
        {
            isDead = true;
            idle = true;
        }
    }

    private void deleteHB()
    {
        UI.SetActive(false); ;
    }

}

