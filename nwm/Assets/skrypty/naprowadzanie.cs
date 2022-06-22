using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naprowadzanie : MonoBehaviour
{
    public Transform cel;
    public float predkosc = 5f;
    public float predkoscObrotu = 5f;
    //public GameObject Unik;

    [HideInInspector]
    public Rigidbody2D cos;
    private Rigidbody2D rb;
    private float obruc;
    [HideInInspector]
    public bool coll = true;


    // Start is called before the first frame update
    void Start()
    {
        cel = GameObject.Find("statek_big").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.rigidbody.name  == "statek_big")
        {
            Destroy(gameObject);
            GetComponent<zycie>().drop();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Unik.transform.position = transform.position;
        if (cel == null) return;

        Vector2 kierunek;
        if(true)
        {
            kierunek = (Vector2)cel.position - rb.position;
            kierunek.Normalize();
            obruc = -Vector3.Cross(kierunek, transform.up).z;

            rb.angularVelocity = obruc * predkoscObrotu;
        }
        /*else
        {
            kierunek = cos.position - rb.position;
            kierunek.Normalize();
            obruc = Vector3.Cross(kierunek, transform.up).z;

            rb.angularVelocity = obruc * predkoscObrotu * 1.5f;
        }*/

        rb.velocity = transform.up * predkosc;
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "statek_big" || collision.isTrigger == true || collision.name == "serce (Clone)") return;

        cos = collision.GetComponent<Rigidbody2D>();
        coll = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        coll = true;
    }*/
}
