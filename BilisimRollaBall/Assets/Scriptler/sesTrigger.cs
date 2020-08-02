using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sesTrigger : MonoBehaviour
{
    AudioSource kaynak;
    public AudioClip ses;
    // Start is called before the first frame update
    void Start()
    {
        kaynak = GetComponent<AudioSource>();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.name=="panel")
    //    {
    //        kaynak.PlayOneShot(ses);
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "panel")
        {
           kaynak.PlayOneShot(ses);
        }
    }
}
