using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameraKontrol : MonoBehaviour
{

    public GameObject oyuncu;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //offset = kamerak - oyuncu k (transform position vector)
        offset = this.transform.position - oyuncu.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //kam yeni konum=oyuncunun konumu+offset
        transform.position = oyuncu.transform.position + offset;
    }
}
