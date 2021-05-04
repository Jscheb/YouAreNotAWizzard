using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public Vector3 direction;
    public Vector3 offset;

    private void Awake()
    {
        transform.rotation = Quaternion.Euler(direction);
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
