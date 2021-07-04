using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFightStart : MonoBehaviour
{
    private AudioSource source;
    [SerializeField]
    private AudioSource finalMusic;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            source = GameObject.Find("/Music").GetComponent<AudioSource>();
            if (!source.isPlaying)
            {
                source.Stop();
            }
            finalMusic.Play();

            GetComponent<BoxCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
        }
        


    }

}
