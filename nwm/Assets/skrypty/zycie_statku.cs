using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class zycie_statku : MonoBehaviour
{
    public int zdrowie = 3;
    private int maxzdrowie;
    private bool nic = true;
    public float czasNieznisczalnosci = 0.1f;
    //private int uszkodzenia = 1;

    public Image[] Serca;
    public Sprite Serce;
    public Sprite nieSerce;
    public GameObject prefabTekstu;
    //public GameObject pusty;
    public int scoreZaUszkodzenie = -50;
    public GameObject pusty;

    private void Start()
    {
        maxzdrowie = 16;

        for(int i = 0; i < Serca.Length; i++)
        {
            if (i < zdrowie) Serca[i].enabled = true;
            else Serca[i].enabled = false;

            if (i < zdrowie) Serca[i].sprite = Serce;
            else Serca[i].sprite = nieSerce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (nic == true)
        {
            zdrowie--;
            Serca[zdrowie].sprite = nieSerce;
            Serca[zdrowie].enabled = false;
            nic = false;
            FindObjectOfType<score>().zmienScore(scoreZaUszkodzenie);
            GameObject nico = Instantiate(prefabTekstu) as GameObject;
            nico.transform.position = collision.transform.position;
            nico.GetComponent<fadeText>().zmienScore(scoreZaUszkodzenie);
            StartCoroutine(czekaj());
            if (zdrowie <= 0)
            {
                Destroy(gameObject);
                FindObjectOfType<AudioManager>().Play("zniszczenie_statku");
                FindObjectOfType<score>().resetScore();
                Instantiate(pusty);
            }
            else FindObjectOfType<AudioManager>().Play("demage");
        }
    }


    IEnumerator czekaj()
    {
        yield return new WaitForSeconds(czasNieznisczalnosci);
        nic = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        zdrowie++;
        if (zdrowie > maxzdrowie || collision.name != "serce(Clone)") zdrowie--;
        else
        {
            Serca[zdrowie - 1].sprite = Serce;
            Serca[zdrowie - 1].enabled = true;
        }

        if (nic == true && collision.name != "serce(Clone)")
        {
            zdrowie--;
            Serca[zdrowie].sprite = nieSerce;
            Serca[zdrowie].enabled = false;
            nic = false;
            FindObjectOfType<score>().zmienScore(scoreZaUszkodzenie);
            GameObject nico = Instantiate(prefabTekstu) as GameObject;
            nico.transform.position = collision.transform.position;
            nico.GetComponent<fadeText>().zmienScore(scoreZaUszkodzenie);
            StartCoroutine(czekaj());
            if (zdrowie <= 0)
            {
                Destroy(gameObject);
                FindObjectOfType<AudioManager>().Play("zniszczenie_statku");
                FindObjectOfType<score>().resetScore();
                Instantiate(pusty);
            }
            else FindObjectOfType<AudioManager>().Play("demage");
        }
    }
}
