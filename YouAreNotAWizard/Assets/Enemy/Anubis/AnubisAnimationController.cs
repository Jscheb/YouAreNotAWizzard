using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubisAnimationController : MonoBehaviour
{
    private Animator animator;

    //Performance boost
    private int isDead;
    private int arHash;

    EnemyAi AiScript;
    // Start is called before the first frame update
    void Start()
    {
        // PilzEnemy = GameObject.Find("PilzEnemy");
        AiScript = transform.parent.gameObject.GetComponent<EnemyAi>();
        //AiScript = GetComponent<EnemyAi>();

        animator = GetComponent<Animator>();
        isDead = Animator.StringToHash("IsDead");
        arHash = Animator.StringToHash("AttackRange");

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool(isDead, AiScript.isDead);
        animator.SetBool(arHash, AiScript.playerInAttackRange);


    }
}
