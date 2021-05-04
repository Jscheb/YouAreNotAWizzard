using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Camera cam;
    public GameObject hitBox;
    public DetectionScript realOne;
    private DetectionScript clone;

    void Start()
    {
        cam = Camera.main;
        clone = Instantiate(realOne, -Vector3.up * 200, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            HitBox();
        }
    }
    void HitBox()
    {
        
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            clone.DestroyHitBox();
            Debug.Log("Yes");
            Vector3 direction = (hit.point - transform.position).normalized;
            Quaternion directionAngle = Quaternion.LookRotation(direction);

            clone = Instantiate(realOne, transform.GetChild(0).position + direction / 2, directionAngle);
        }
        


    }
}
