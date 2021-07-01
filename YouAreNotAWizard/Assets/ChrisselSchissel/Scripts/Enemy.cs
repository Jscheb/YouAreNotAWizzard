using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public bool enemyIsDead = false;
    public float animationTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        if (health <= 0)
        {
            enemyIsDead = true;
            StartCoroutine(DestroyEnemy());
            
        }
    }
    public bool GetEnemyIsDead()
    {
        return enemyIsDead;
    }
    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSecondsRealtime(animationTimer);
        yield return null;
        Destroy(gameObject);


    }
}
