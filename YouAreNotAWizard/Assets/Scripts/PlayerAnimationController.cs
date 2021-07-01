using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private Vector3 moveDirection;
    private int isDead;
    PlayerScript playerScript;



    //Performance boost
    private int isWalkingHash;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScript = transform.gameObject.GetComponent<PlayerScript>();
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isDead = Animator.StringToHash("IsDead");

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
        
        animator.SetBool(isWalkingHash, moveDirection.magnitude >= 0.1f);
        animator.SetBool(isDead, playerScript.isDead);

    }
}
