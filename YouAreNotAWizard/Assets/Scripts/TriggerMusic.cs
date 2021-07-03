using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMusic : MonoBehaviour
{
    private AudioSource source;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CharacterController>() != null)
        {
            source = GameObject.Find("/Music").GetComponent<AudioSource>();
            if (!source.isPlaying)
            {
                source.Play();
            }

        }

    }

}
