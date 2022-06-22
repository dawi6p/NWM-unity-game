using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graj : MonoBehaviour
{
    public string nazwaMuzyki;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play(nazwaMuzyki);
    }
}
