using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAttackCollision : MonoBehaviour
{
    [SerializeField]
    private int waveDamage;

    [SerializeField]
    private float damageTimer = 0.3f;
    private float currentTimer = 0.3f;

    private bool applyDamage = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DestroyWaveSpell()
    {
        Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        Enemy e = other.GetComponent<Enemy>();
        if (e != null && Timer())
        {
            e.TakeDamage(waveDamage);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        currentTimer = 0.3f;
    }

    private bool Timer()
    {
        currentTimer += Time.deltaTime;
        if (currentTimer >= damageTimer)
        {
            currentTimer = 0.0f;
            return true;
        }
        else
        {
            return false;
        }
    }
}
