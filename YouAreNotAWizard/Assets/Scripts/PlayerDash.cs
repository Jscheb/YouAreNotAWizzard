using System.Collections;
using System.Collections.Generic;
using UnityEngine.VFX;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    PlayerMovement movementScript;
    public float dashSpeed;
    public float dashTime;
    public float dashBreakTime;
    private float currentTimer = 0f;
    private bool dashActive = true;
    [SerializeField]
    private VisualEffect dashEffect;


    void Start()
    {
        movementScript = GetComponent<PlayerMovement>();
        dashEffect.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dashActive)
        {
            DashTimer();
            
        }
        
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dashEffect.Play();
            dashActive = false;
            GetComponent<PlayerAudioScript>().playDashSound();
            StartCoroutine(Dash());
        }

    }


    private void DashTimer()
    {
        currentTimer += Time.deltaTime;
        if (currentTimer > dashBreakTime)
        {
            currentTimer = 0f;
            dashActive = true;
            

        }

    }

    IEnumerator Dash()
    {
        float startTime = Time.time;
        while(Time.time < startTime + dashTime)
        {
            movementScript.controller.Move(movementScript.moveDir * dashSpeed * Time.deltaTime);

            yield return null;
        }
        dashEffect.Stop();
    }
}
