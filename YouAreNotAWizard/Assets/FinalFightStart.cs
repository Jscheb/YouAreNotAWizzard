using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFightStart : MonoBehaviour
{
    private AudioSource source;
    [SerializeField]
    private AudioSource finalMusic;
    public Boss boss;
    public GameObject haraldHB;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterController>() != null)
        {
            boss.startTheFightAkaBob = true;
            haraldHB.SetActive(true);
            source = GameObject.Find("/Music").GetComponent<AudioSource>();
            if (source.isPlaying)
            {
                source.Stop();
            }
            finalMusic.Play();

            GetComponent<BoxCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
        }
        


    }

}
