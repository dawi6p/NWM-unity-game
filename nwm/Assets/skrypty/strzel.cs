using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strzel : MonoBehaviour
{
    public Transform punktpocisku;
    public GameObject pocisk;
    public int czestotliwosc = 7;
    public float silapocisku = 30f;

    private int nwm = 0;

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1")) trzel();
        else
        {
            nwm++;
            if (czestotliwosc == nwm) nwm--;
        }
    }

    void trzel()
    {
        if (nwm % (czestotliwosc) == 0)
        {
            Rigidbody2D cos = Instantiate(pocisk, punktpocisku.position, punktpocisku.rotation).GetComponent<Rigidbody2D>();
            cos.AddForce(punktpocisku.up * silapocisku, ForceMode2D.Impulse);
            nwm = 0;
            FindObjectOfType<AudioManager>().Play("strzel");
        }
        nwm++;
    }
}
