using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafienie : MonoBehaviour
{
    private Vector2 granica;

    private void Start()
    {
        granica = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "serce(Clone)" && collision.isTrigger == false) Destroy(gameObject);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 cos = transform.position;
        if (cos.x > granica.x * 1.1f || cos.y > granica.y * 1.1f || cos.x < -granica.x * 1.1f || cos.y < -granica.y * 1.1f) Destroy(gameObject);
    }
}
