using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class HaraldAttack : MonoBehaviour
{
    [SerializeField]
    private HaraldAttackCollision doomBeamRealOne;
    private HaraldAttackCollision doomBeamClone;
    [SerializeField]
    private VisualEffect doomBeam;
    private Vector3 direction;
    private Quaternion directionAngle;
    private float currentTimer;
    public float attackTime = 0.01f;
    public bool attack = false;
    private float currentTimerDuration;
    public float attackDuration = 3f;

    int count = 0;


    // Update is called once per frame
    /*void Update()
    {
        bool spawn = Timer();
        if (attack)
        {
            if (spawn)
            {
                spawnObject();
            }
            AttackDurationTimer();

        }
    }
    bool Timer()
    {
        currentTimer += Time.deltaTime;
        if (currentTimer > attackTime)
        {
            currentTimer = 0.0f;
            return true;
        }
            return false;


    }
    void AttackDurationTimer()
    {
        currentTimerDuration += Time.deltaTime;
        if (currentTimerDuration > attackDuration)
        {
            currentTimerDuration = 0.0f;
            attack = false;

        }
    }
    */

    private void FixedUpdate()
    {
        if (attack)
        {
            doomBeam.Play();

            if (count % 5 == 0) {
                spawnObject();
            }
            count++;

            if (count == 100)
            {
                count = 0;
                attack = false;
                doomBeam.Stop();
            }

        }

        
    }

    private void Awake()
    {
        currentTimer = attackTime;
        currentTimerDuration = attackDuration;
        doomBeam.Stop();
    }
    public void spawnObject()
    {

        direction = (GameObject.Find("/Player").transform.position - transform.position);

        direction = new Vector3(direction.x, 0.0f, direction.z);

        direction = direction.normalized;

        directionAngle = Quaternion.LookRotation(direction);

        doomBeamClone = Instantiate(doomBeamRealOne, transform.position + new Vector3(0.0f, 2.5f, 0.0f), directionAngle);

        doomBeamClone.setMovementDirection(direction);
    }


}
