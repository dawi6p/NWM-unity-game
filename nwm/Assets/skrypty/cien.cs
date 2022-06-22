using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cien : MonoBehaviour
{
    public GameObject prefab;
    public Transform punktCos;
    public float czasSpawnu = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    void cos()
    {
        GameObject nic = Instantiate(prefab) as GameObject;
        nic.transform.position = punktCos.transform.position;
        nic.transform.rotation = transform.rotation;
        nic.transform.localScale = transform.localScale;
    }

    IEnumerator spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(czasSpawnu);
            cos();
        }
    }
}
