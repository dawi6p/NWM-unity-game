using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startkwadrat : MonoBehaviour
{
    private Vector2 sgranica;
    public float sila = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        sgranica = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        Vector2 mPoz = Camera.main.transform.position;
        Vector2 poz = mPoz * 2;

        if (sgranica.x < transform.position.x || -sgranica.x > transform.position.x)
        {
            mPoz = new Vector2(Camera.main.transform.position.x, Random.Range(-sgranica.y * 0.9f, sgranica.y * 0.9f));
        }
        else
        {
            mPoz = new Vector2(Random.Range(-sgranica.x * 0.9f, sgranica.x * 0.9f), Camera.main.transform.position.y);
        }

        Vector2 kierunek = new Vector2(mPoz.x - transform.position.x, mPoz.y - transform.position.y);

        GetComponent<Rigidbody2D>().AddForce(kierunek * sila, ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().angularVelocity = 180 + Random.Range(-90, 90);
    }
}
