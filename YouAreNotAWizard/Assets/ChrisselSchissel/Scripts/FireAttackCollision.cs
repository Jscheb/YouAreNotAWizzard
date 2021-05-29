using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAttackCollision : MonoBehaviour
{
    [SerializeField]
    private float lifeSpan;

    [SerializeField]
    private int flameDamage;
    //Die Richtung der Flammen
    Vector3 moveForward;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(1.0f, 0.0f, 0.0f) * Time.deltaTime * 5;
        transform.position += moveForward * Time.deltaTime * 28;
        if (Timer())
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Enemy e = other.GetComponent<Enemy>();
        if(e != null)
        {
            e.TakeDamage(flameDamage);
        }


    }
    bool Timer()
    {
        if (lifeSpan > 0)
        {
            lifeSpan -= Time.deltaTime;
            return false;
        }
        else
        {
            return true;
        }
        
    }
    public void setMovementDirection(Vector3 vec)
    {
        moveForward = vec;
    }
}
