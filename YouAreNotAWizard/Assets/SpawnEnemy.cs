using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private float x;
    [SerializeField]
    private float z;

    private Vector3 position;

    [SerializeField]
    private GameObject enemy;
    public GameObject wall;



    void Start()
    {
        position = new Vector3(x, 1.55f, z);
    }


    public void createEnemy()
    {
        wall.SetActive(false);
        Instantiate(enemy, position, new Quaternion(0,0,0,0));
    }
}
