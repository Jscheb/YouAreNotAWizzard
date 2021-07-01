using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeuerdracheAnimationController : MonoBehaviour
{
    private Animator animator;

    //Performance boost
    private int isDead;
    private int arHash;
    private int enemyIsDead;


    EnemyAi AiScript;
    Enemy EnemyScript;
    //GameObject PilzEnemy;
    // Start is called before the first frame update
    void Start()
    {
        // PilzEnemy = GameObject.Find("PilzEnemy");
        AiScript = transform.parent.gameObject.GetComponent<EnemyAi>();
        EnemyScript = transform.parent.gameObject.GetComponent<Enemy>();

        //AiScript = GetComponent<EnemyAi>();

        animator = GetComponent<Animator>();
        isDead = Animator.StringToHash("IsDead");
        arHash = Animator.StringToHash("AttackRange");
        enemyIsDead = Animator.StringToHash("EnemyIsDead");


    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool(isDead, AiScript.isDead);
        animator.SetBool(arHash, AiScript.playerInAttackRange);
        animator.SetBool(enemyIsDead, EnemyScript.enemyIsDead);



    }
}
