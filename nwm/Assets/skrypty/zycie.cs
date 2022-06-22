using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zycie : MonoBehaviour
{
    public short zdrowie = 2;
    public short uszkodzenia = 1;
    public int SzansaNaDrop = 1;
    public int scoreZaZniszczenie = 100;
    public GameObject prefab;
    public GameObject prefabTekstu;
    private bool nic = true;
    public float czasBezglosnosci = 0.3f;

    private Vector2 sgranica;

    void Start()
    {
        sgranica = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "pocisk(Clone)")
        {
            zdrowie -= uszkodzenia;
            if (zdrowie <= 0)
            {
                drop();
                FindObjectOfType<AudioManager>().Play("zniszczenie");
                FindObjectOfType<score>().zmienScore(scoreZaZniszczenie);
                Destroy(gameObject);
                GameObject nic = Instantiate(prefabTekstu) as GameObject;
                nic.transform.position = collision.transform.position;
                nic.GetComponent<fadeText>().zmienScore(scoreZaZniszczenie);
            }
        }

        if (collision.name == "pierscien(Clone)")
        {
            zdrowie -= (short)(uszkodzenia * 2);
            if (zdrowie <= 0)
            {
                FindObjectOfType<AudioManager>().Play("zniszczenie");
                Destroy(gameObject);
            }
        }
    }

    public void drop()
    {
        if (Random.Range(1, 100) <= SzansaNaDrop)
        {
            GameObject cos = Instantiate(prefab) as GameObject;
            cos.transform.position = transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "nwm2 (1)(Clone)" && nic == true)
        {
            FindObjectOfType<AudioManager>().Play("zderzenie");
            nic = false;
        }
        StartCoroutine(czekaj());
    }

    IEnumerator czekaj()
    {
        yield return new WaitForSeconds(czasBezglosnosci);
        nic = true;
    }

    void LateUpdate()
    {
        Vector2 ncos = transform.position;
        if (ncos.x > sgranica.x * 1.4f || ncos.y > sgranica.y * 1.4f || ncos.x < -sgranica.x * 1.4f || ncos.y < -sgranica.y * 1.4f) Destroy(gameObject);
    }
}
