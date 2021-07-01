using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioScript : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioSource dashSound;
    [SerializeField]
    private AudioSource fireSound;


    // Update is called once per frame

    IEnumerator Start()
    {
        source = GetComponent<AudioSource>();
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        while(1 == 1)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            if (moveDirection.magnitude >= 1.0f && !source.isPlaying)
            {
                source.Play();
                yield return new WaitForSeconds(0.3f);
                continue;
            }
            yield return new WaitForSeconds(0.3f);

        }


    }
    public void playDashSound()
    {
        if (!dashSound.isPlaying){
            dashSound.Play();
        }
        
    }
    public void PlayFireSound()
    {
        if (!fireSound.isPlaying)
        {
            fireSound.Play();
        }

    }
    public void StopFireSound()
    {
        if (fireSound.isPlaying)
        {
            fireSound.Stop();
        }

    }

}

