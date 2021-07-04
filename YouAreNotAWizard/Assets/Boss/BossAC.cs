using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAC : MonoBehaviour
{
    private Animator animator;

    //Performance boost
    private int die;
    private int attack;
    private int idle;
    private int run;



    Boss BossScript;
    // Start is called before the first frame update
    void Start()
    {
        BossScript = transform.parent.gameObject.GetComponent<Boss>();

        animator = GetComponent<Animator>();

        die = Animator.StringToHash("Die");
        attack = Animator.StringToHash("Attack");
        idle = Animator.StringToHash("Idle");
        run = Animator.StringToHash("Run");


    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool(die, BossScript.die);
        animator.SetBool(attack, BossScript.attack);
        animator.SetBool(idle, BossScript.idle);
        animator.SetBool(run, BossScript.run);
    }
}

