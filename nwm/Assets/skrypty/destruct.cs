using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruct : MonoBehaviour
{
    private Vector2 granica;
    public float czasZniszczenia = 5f;

    private void Start()
    {
        granica = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(czas());
    }

    IEnumerator czas()
    {
        yield return new WaitForSeconds(czasZniszczenia);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "statek_big")
        {
            Destroy(gameObject);
        }
    }
    void LateUpdate()
    {
        Vector2 cos = transform.position;
        if (cos.x > granica.x || cos.y > granica.y || cos.x < -granica.x || cos.y < -granica.y) Destroy(gameObject);
    }
}
