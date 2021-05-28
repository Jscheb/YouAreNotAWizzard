using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerScript : MonoBehaviour
{
    Camera cam;
    public GameObject hitBox;
    public DetectionScript realOne;
    private DetectionScript clone;
    public VisualEffect flamespell;
    [SerializeField]
    private float maxDistance = 1000f;
    [SerializeField]
    private LayerMask layerMask;

    void Start()
    {
        cam = Camera.main;
        flamespell.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        HitBox();
    }
    void HitBox()
    {
        //Get Raycast at a certain location
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 direction = Vector3.up.normalized;
        Quaternion directionAngle = Quaternion.LookRotation(direction);
        if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
        {
            //Richtungsvektor
            direction = (hit.point - transform.position);
            direction = new Vector3(direction.x, 0.0f, direction.z);
            while (direction.magnitude < 1.3f)
            {
                direction *= 5f;
            }
            direction = direction.normalized;
            //Richtung der Attacke als Winkel
            directionAngle = Quaternion.LookRotation(direction);
            //direction = directionAngle.normalized * new Vector3(1.0f, 1.0f, 1.0f) + direction;
            //direction = direction.normalized;
        }
        
        //Instanzieren dem Hitbox-Collider und starten der VFX-Attacke
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Yes");
            //realOne = Hitbox-Objekt, als Start-Position die Position des Charakters und 
            clone = Instantiate(realOne, transform.GetChild(0).position + direction * 2, directionAngle);
            flamespell.Play();
            //+direction * 2
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //direction = new Vector3(direction.x, 0.0f, direction.z);
            clone.transform.position = transform.GetChild(0).position + direction * clone.transform.localScale.z * 0.6f;
            flamespell.transform.position = transform.GetChild(0).position + direction * 2;
            directionAngle = Quaternion.LookRotation(direction);
            clone.transform.rotation = directionAngle;
            flamespell.transform.rotation = directionAngle;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            clone.DestroyHitBox();
            flamespell.Stop();
        }
    }
}
