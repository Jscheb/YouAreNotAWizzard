using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilzAnimationController : MonoBehaviour
{
    private Animator animator;

    //Performance boost
    private int aaHash;
    private int arHash;
    EnemyAi AiScript;
    //GameObject PilzEnemy;
    // Start is called before the first frame update
    void Start()
    {
        // PilzEnemy = GameObject.Find("PilzEnemy");
        AiScript = transform.parent.gameObject.GetComponent<EnemyAi>();
        //AiScript = GetComponent<EnemyAi>();
        
        animator = GetComponent<Animator>();
      //  aaHash = Animator.StringToHash("AlreadyAttacked");
        arHash = Animator.StringToHash("AttackRange");

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool(arHash, AiScript.playerInAttackRange);
        animator.SetBool(aaHash, AiScript.alreadyAttacked);

    }
}
