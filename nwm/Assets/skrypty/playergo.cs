using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playergo : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    private Vector3 mPoz;

    Vector2 go;

    // Update is called once per frame
    void Update()
    {
        go.x = Input.GetAxisRaw("Horizontal");
        go.y = Input.GetAxisRaw("Vertical");
        mPoz = Input.mousePosition;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + go * speed * Time.fixedDeltaTime);
 
        mPoz = Camera.main.ScreenToWorldPoint(mPoz);
        Vector3 kierunek = new Vector3(mPoz.x - transform.position.x, mPoz.y - transform.position.y);
        transform.up = kierunek ;
    }
}
