using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeText : MonoBehaviour
{
    private int z = 0;
    private TextMesh kwadrat;
    public float czestotliwosc = 40;
    public float przyciemninie = 0.2f;
    public float predkosc = 0.1f;
    private Vector3 kierunek;

    // Start is called before the first frame update
    void Start()
    {
        //i = (int)(0.75f * czestotliwosc);
        kwadrat = GetComponent<TextMesh>();
        StartCoroutine(zastepstwo());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(kierunek * predkosc * Time.fixedDeltaTime);
    }

    IEnumerator zastepstwo()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(czestotliwosc);
            kwadrat.color = Color.Lerp(kwadrat.color, Color.black, przyciemninie);
            z++;
            if (z == 8) Destroy(gameObject);
        }
    }

    public void zmienScore(int zmianaScore)
    {
        kwadrat = GetComponent<TextMesh>();
        if (zmianaScore > 0)
        {
            kwadrat.text = "+" + zmianaScore.ToString();
            kierunek = transform.up;
        }
        if (zmianaScore < 0)
        {
            kwadrat.text = zmianaScore.ToString();
            kierunek = -transform.up;
        }
    }
}

