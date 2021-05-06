using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
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
        Debug.Log("The enemy took damage.");
        if (health <= 0)
        {
            DestroyEnemy();
        }
    }
    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
