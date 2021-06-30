using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioScript : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;


    // Update is called once per frame
    
    IEnumerator Start()
    {
        source = GetComponent<AudioSource>();
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        while(1 == 1)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            if (moveDirection.magnitude >= 0.1f && !source.isPlaying)
            {
                source.Play();
                yield return new WaitForSeconds(0.5f);
                continue;
            }
            yield return new WaitForSeconds(0.5f);

        }


    }
}