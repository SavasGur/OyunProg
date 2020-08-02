using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class oyuncuKontrol : MonoBehaviour
{
    Rigidbody rb;
    public int hiz;
    float yatay;
    float dikey;
    int sayac = 0;
    public Text skorTxt;
    public Text hataTxt;
    [Tooltip("Tebrikler Değişkeni")]
        public Text tebrikTxt;

    Renderer rend;

    //Materyal
    public Material mat;
    
    //Audiolar
    public AudioClip roll;
    public AudioClip hit;
    public AudioClip clap;
    public AudioClip point;
    public AudioClip boing;
    AudioSource kaynak;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Sahne çalıştı.");
        rb = GetComponent<Rigidbody>();

        kaynak = GetComponent<AudioSource>();
        rend = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            //input acc/gyro
            yatay = Input.acceleration.x;
            dikey = Input.acceleration.y;

        } else if (Application.platform == RuntimePlatform.WindowsPlayer)
        {   
            //input klavye
            yatay = Input.GetAxis("Horizontal");
            dikey = Input.GetAxis("Vertical");

        } else
        {
            //input klavye
            yatay = Input.GetAxis("Horizontal");
            dikey = Input.GetAxis("Vertical");
        }
        //zıpzıp
        if (Input.GetKeyDown(KeyCode.Space))
        {
            kaynak.PlayOneShot(boing);
            Vector3 yukari = new Vector3(0f, 200f, 0f);
            rb.AddForce(yukari);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            kaynak.PlayOneShot(boing);
            Vector3 yukari = new Vector3(0f, 200f, 0f);
            rb.AddForce(yukari);
        }

        Vector3 har = new Vector3(yatay, 0f, dikey);

        rb.AddForce(har*hiz);

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit();
        }

        if (kaynak.isPlaying == false && rb.velocity.magnitude > 0.1f) 
        {
            kaynak.PlayOneShot(roll);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        rend.material = other.gameObject.GetComponent<Renderer>().material;

        if (other.gameObject.CompareTag("elmas"))
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            sayac += 10;
            skorTxt.text = "Score: " + sayac.ToString();
            //Debug.Log("SCORE: "+sayac);
            
            kaynak.PlayOneShot(point);

        }
        else if (other.gameObject.CompareTag("sonElmas") && sayac == 90)
        {
            other.gameObject.SetActive(false);
            sayac += 10;
            skorTxt.text = "Score: " + sayac.ToString();
            tebrikTxt.text = "Tebrikler Kazandınız!!!";
            
            StartCoroutine(sahneDegis());
            
            kaynak.PlayOneShot(clap);

        }
        else if (other.gameObject.CompareTag("sonElmas") && sayac != 90)
        {
            kaynak.PlayOneShot(hit);
            hataTxt.text = "Bu elmas en son alınacak!!!";
            StartCoroutine(Beklet());
            
        }
        IEnumerator Beklet()
        {
            yield return new WaitForSeconds(3);
            hataTxt.text = "";
            
        }
        IEnumerator sahneDegis()
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene(1);

        }
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("elmas"))
    //    {
    //        collision.gameObject.SetActive(false);
    //        //Destroy(other.gameObject);
    //    }
    //    Debug.Log(this.gameObject+" nesnesi "+collision.gameObject.name+" nesnesine çarptı! ");
    //    Debug.Log("Dokunduğum koordinat: "+collision.contacts[0].point);

    //    //Find, findWithTag
    //    //GameObject d;
    //    //GameObject d1;
    //    //d = GameObject.Find("duvarlar/solDuvar");
    //    //d1 = GameObject.Find("solDuvar");
    //    //Destroy(d);
    //    //Destroy(d1);


    //}
    
    //Awake startdan önce başlar
    private void Awake()
    {
        //    GameObject duvar = GameObject.Find("solDuvar");
        //    Destroy(duvar);
        Debug.Log("Awake çalıştı.");
    }

    bool matdegis = true;
    public Material mat1;
    public Material mat2;

    private void OnMouseDown()
    {
        if (matdegis)
        {
            rend.material = mat2;
            matdegis = false;
        }
        else
        {
            rend.material = mat1;
            matdegis = true;
        }
    }

}
