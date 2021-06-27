using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackBehaviour : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (GameObject.Find("Enemy").GetComponent<EnemyAi>().playerInAttackRange == false)
        {
            animator.SetTrigger("Run");
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}

 
