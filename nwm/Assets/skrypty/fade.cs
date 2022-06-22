using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade : MonoBehaviour
{
    private int z = 0;
    public int iloscIteracji = 7;
    private SpriteRenderer kwadrat;
    public float czestotliwosc = 40;
    public float SkalaNastepnego = 0.8f;
    public float przyciemninie = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        kwadrat = GetComponent<SpriteRenderer>();
        StartCoroutine(zastepstwo());
    }

    IEnumerator zastepstwo()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(czestotliwosc);
            transform.localScale *= SkalaNastepnego;
            kwadrat.color = Color.Lerp(kwadrat.color, Color.black, przyciemninie);
            z++;
            if (z == iloscIteracji) Destroy(gameObject);
        }
    }
}
