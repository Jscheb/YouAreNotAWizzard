using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerScript : MonoBehaviour
{
    //Collision Detection
        //Shock
    public DetectionScript shockRealOne;
    private DetectionScript shockClone;
    public GameObject hitBox;
        //Fire
    public FireAttackCollision fireRealOne;
    private FireAttackCollision fireClone;
    [SerializeField]
    private GameObject fireHitBox;


    //VisualEffects
    public VisualEffect flamespell;

    //Raycast Variablen
    Camera cam; //Unsere Spielkamera
    [SerializeField]
    private float maxDistance = 1000f; //Raycastlänge
    [SerializeField]
    private LayerMask layerMask; //GroundLayer, damit nur RayCasts auf dem Boden gemacht werden

    //Timer Variablen
    public float flameSpawnTimer;
    private float currentTimer = 0f;

    void Start()
    {
        cam = Camera.main;
        flamespell.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        FlameHitBox();
    }
    
    
    void FlameHitBox()
    {
        bool spawn = FlameHitBoxTimer();
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 direction = Vector3.up;
        Quaternion directionAngle = Quaternion.LookRotation(direction);

        if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
        {
            //Richtungsvektor
            direction = (hit.point - transform.position);
            //Für das Normalisieren ist es wichtig, dass nur x und z Achse beachtet wird
            direction = new Vector3(direction.x, 0.0f, direction.z);
            //direction wird normalisiert
            direction = direction.normalized;
            //Richtung der Attacke als Winkel
            directionAngle = Quaternion.LookRotation(direction);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {         
            //VFX Attacke starten
            flamespell.Play();
        }
        if (Input.GetKey(KeyCode.Mouse0)){
            if (FlameHitBoxTimer())
            {
                fireClone = Instantiate(fireRealOne, transform.GetChild(0).position + direction * 2, directionAngle);
                fireClone.setMovementDirection(direction);
            }
            flamespell.transform.position = transform.GetChild(0).position + direction * 2;
            flamespell.transform.rotation = directionAngle;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            flamespell.Stop();
        }
        
    }
    bool FlameHitBoxTimer()
    {
        currentTimer += Time.deltaTime;
        if (currentTimer > flameSpawnTimer)
        {
            currentTimer = 0f;
            return true;
        }
        else
        {
            return false;
        }
        
    }

    void HitBox()
    {
        //Get Raycast at a certain location
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 direction = Vector3.up;
        Quaternion directionAngle = Quaternion.LookRotation(direction);
        if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
        {
            //Richtungsvektor
            direction = (hit.point - transform.position);
            //Für das Normalisieren ist es wichtig, dass nur x und z Achse beachtet wird
            direction = new Vector3(direction.x, 0.0f, direction.z);

            direction = direction.normalized;
            //Richtung der Attacke als Winkel
            directionAngle = Quaternion.LookRotation(direction);

        }

        //Instanzieren dem Hitbox-Collider und starten der VFX-Attacke
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Yes");
            //realOne = Hitbox-Objekt, als Start-Position die Position des Charakters + Richtungvektor * 2, also als Länge 2
            shockClone = Instantiate(shockRealOne, transform.GetChild(0).position + direction * 2, directionAngle);

            //VFX Attacke starten
            flamespell.Play();
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            shockClone.transform.position = transform.GetChild(0).position + direction * shockClone.transform.localScale.z * 0.6f;
            flamespell.transform.position = transform.GetChild(0).position + direction * 2;
            directionAngle = Quaternion.LookRotation(direction);
            shockClone.transform.rotation = directionAngle;
            flamespell.transform.rotation = directionAngle;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            shockClone.DestroyHitBox();
            flamespell.Stop();
        }
    }

}
