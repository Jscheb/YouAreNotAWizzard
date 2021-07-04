using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anleitung1 : MonoBehaviour
{
    public GameObject anleitung1;
    public GameObject anleitung2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anleitung1.SetActive(false);
            anleitung2.SetActive(true);
        }
    }
}
