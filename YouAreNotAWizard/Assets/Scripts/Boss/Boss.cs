using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.VFX;

public class Boss : Enemy
{
    public bool startTheFightAkaBob = true;
    public int damage;
    PlayerScript PlayerScript;
    public bool enemyDead;
    public Enemy enemy;
    public Vector3 spawnPoint;

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
            if (!enemyIsDead)
            {
                FacePlayer();
                //if (!idle && !attack) 
                if (!playerInAttackRange && !freezeAfterAttack)
                {
                    ChasePlayer();
                }else if (playerInAttackRange)
                {
                    //ResetAcStates();
                    AttackPlayer();
                }
                else
                {
                    ResetAcStates();
                    SetIdle(true);
                }
                

            }
        }
    }

    public void Attack()
    {
        int playerLife = PlayerScript.GetLife();
        if (playerLife > 0)
        {
            GetComponent<HaraldAttack>().attack = true;
        }
        else
        {
            SetIdle(true);
            startTheFightAkaBob = false;
        }
    }



    private void AttackPlayer()
    {
        if (!alreadyAttacked)
        {
            Debug.Log("Attacke");
            agent.SetDestination(transform.position);
            ResetAcStates();
            SetAttack(true);

            StartCoroutine(AttackAnimation());
            //Attack();

            freezeAfterAttack = true;
            alreadyAttacked = true;
            //ResetAcStates();
            //SetIdle(true);
            StartCoroutine(ResetFreeze());
            StartCoroutine(ResetAttack());
        }
        
    }



    private void AcStateCheck()
    {
        if (enemyIsDead) SetDie(true);
       // if ( ) SetAttack();
        if (freezeAfterAttack || !startTheFightAkaBob) SetIdle(true);
        //if ( ) SetRun();
    }

    private void SetDie(bool x)
    {
        die = x;
        animator.SetBool(dieAC, die);

    }

    private void SetAttack(bool x)
    {
        attack = x;
        animator.SetBool(attackAC, attack);
    }

    private void SetIdle(bool x)
    {
        idle = x;

            animator.SetBool(idleAC, idle);


    }

    private void SetRun(bool x)
    {
        run = x;

            animator.SetBool(runAC, run);



    }


    IEnumerator AttackAnimation()
    {
        yield return new WaitForSecondsRealtime(attackAnimationTimer);
        yield return null;
        SetAttack(false);
        Attack();

    }


    private void ChasePlayer()
    {
        ResetAcStates();
        SetRun(true);
        agent.SetDestination(player.position);


    }

    IEnumerator ResetFreeze()
    {
        
        yield return new WaitForSecondsRealtime(2f);
        yield return null;
        ResetAcStates();
        SetIdle(true);
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


    
    private void AnimatorStart()
    {
        animator = GetComponent<Animator>();
        dieAC = Animator.StringToHash("Die");
        attackAC = Animator.StringToHash("Attack");
        idleAC = Animator.StringToHash("Idle");
        runAC = Animator.StringToHash("Run");
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
    private void FacePlayer()
    {
        agent.SetDestination(transform.position);
        Vector3 lookAtTarget = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(lookAtTarget);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    private void deleteHB()
    {
        UI.SetActive(false); ;
    }
    private void ResetAcStates()
    {
        SetAttack(false);
        SetDie(false);
        SetIdle(false);
        SetRun(false);
    }

}

