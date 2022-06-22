using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granica : MonoBehaviour
{
    private Vector2 sgranica;
    private float a;
    private float b;
    public float przyciecie = 0.5f;
    
    void Start()
    {
        sgranica = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        a = transform.GetComponent<SpriteRenderer>().bounds.size.x / (2 + przyciecie);
        b = transform.GetComponent<SpriteRenderer>().bounds.size.y / (2 + przyciecie);
    }

    void LateUpdate()
    {
        Vector2 cos = transform.position;
        cos.x = Mathf.Clamp(cos.x, sgranica.x*-1 + a, sgranica.x - a);
        cos.y = Mathf.Clamp(cos.y, sgranica.y*-1 + b, sgranica.y - b);
        transform.position = cos;
    }
}
