using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionScript : MonoBehaviour
{
    public float damageTimer;
    private float currentTimer;
    void Update()
    {
        Timer();
    }
    public void DestroyHitBox()
    {
        Destroy(gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        //Physics.IgnoreCollision(GetComponent<BoxCollider>(), transform.GetComponentInParent<CharacterController>());
        //Debug.Log(other.name);
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(20);
            Debug.Log("Funzt sehr gut");
            ApplyDamage(enemy);
        }
    }
    bool Timer()
    {
        if(currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
        }
        if(currentTimer <= 0)
        {
            currentTimer = 5;
            Debug.Log("Timer funktioniert: " + currentTimer);
            return true;
        }
        return false;
    }
    void ApplyDamage(Enemy enemy)
    {
        enemy.TakeDamage(20);
    }
}
