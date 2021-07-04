using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaraldAttackCollision : MonoBehaviour
{
    [SerializeField]
    private float lifeSpan;

    [SerializeField]
    private int doomDamage;

    //Die Richtung der Flammen
    Vector3 moveForward;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveForward * Time.deltaTime * 28;
        if (Timer())
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerScript e = other.GetComponent<PlayerScript>();
        if (e != null)
        {
            e.TakeDamage(doomDamage);
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
