using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{
    public GameObject[] prefab;
    public float czasSpawnu = 1.1f;
    public float sila = 0.5f;

    private float NczasSpawnu;
    private Vector2 sgranica;
 
    // Start is called before the first frame update
    void Start()
    {
        NczasSpawnu = czasSpawnu;
        sgranica = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(fala());
    }

    private void spawn()
    {
        GameObject cos = Instantiate(ktory()) as GameObject;
        int rad = Random.Range(0,4);
        switch(rad)
        {
            case 0:
                cos.transform.position = new Vector2(sgranica.x*1.2f, Random.Range(-sgranica.y, sgranica.y));
                break;

            case 1:
                cos.transform.position = new Vector2(-sgranica.x * 1.2f, Random.Range(-sgranica.y, sgranica.y));
                break;

            case 2:
                cos.transform.position = new Vector2(Random.Range(-sgranica.x, sgranica.x), sgranica.y * 1.2f);
                break;

            case 3:
                cos.transform.position= new Vector2(Random.Range(-sgranica.x, sgranica.x), -sgranica.y * 1.2f);
                break;
        }
    }

    private GameObject ktory()
    {
        GameObject cos = prefab[0];
        int score = (int)FindObjectOfType<score>().Score;

        if(score > 900 && Random.Range(0, 9) == 0) cos = prefab[1];

        if (score < 500) NczasSpawnu = 3 * czasSpawnu;
        else if (score < 2000) NczasSpawnu = 1.5f * czasSpawnu;
        else NczasSpawnu = czasSpawnu;

        return cos;
    }

    IEnumerator fala()
    {
        while(true)
        {
            yield return new WaitForSeconds(NczasSpawnu);
            spawn();
        }
    }
}
