using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sesKontrol : MonoBehaviour
{

    AudioSource kaynak;
    public AudioClip uzerinde;
    public AudioClip ayri;

    // Start is called before the first frame update
    void Start()
    {
        kaynak = GetComponent<AudioSource>();
    }

    bool dur = false;
    //mouse üzerine gelince ve ayrılınca ses oynat
    private void OnMouseOver()
    {
        //if(kaynak.isPlaying==true)
        if (dur == false)
        {
            kaynak.Stop();
            kaynak.PlayOneShot(uzerinde);
            dur = true;
        }
    }
    private void OnMouseExit()
    {
        kaynak.Stop();
        kaynak.PlayOneShot(ayri);
        dur = false;
    }
    
}
